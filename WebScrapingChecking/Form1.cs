using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

//necessário para obter o HWID(Serial Number) do hawrdware
//Referencias > Adicionar Referencia
using System.Management;


/*
    neste formulário e demonstrado como fazer uma validação/autenticação online simples
    sem a necessidade de hospedagem de servidor, utilizando uma simples página web (pastebin)
 */

namespace WebScrapingChecking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Objetivo: Verificar se o programa é a versão equivalente a um texto em um site.
        private void btnCheckVersion_Click(object sender, EventArgs e)
        {
            string version = getVersionOnline();
            //Projeto > Propriedade > Aplicativo > Informações do Assembly > Versão do arquivo
            string versao_assembly = Application.ProductVersion;
            lblVersao.Text = "Versão: " + version;
            if (versao_assembly == version)
            {
                MessageBox.Show("Versão autorizada!");
            }
            else
            {
                MessageBox.Show("Esta versão é " + versao_assembly + ", atualize para a mais recente ou autorizada");
            }
        }

        //Objetivo: Buscar o Serial Number do Hardware  (HD/SSD)
        private void btnGetHWIDserialNumber_Click(object sender, EventArgs e)
        {
            txtSerialNumber.Text = "Serial: " + getSerialNumber();
        }

        //Objetivo: Buscar data/hora online sem ser da maquina local
        private void btnDataHora_Click(object sender, EventArgs e)
        {
            DateTime a = GetOnlineTime();
            if (a == DateTime.MinValue)
            {
                lblData.Text = "não foi possivel ver a data online";
            }
            else
            {
                lblData.Text = a.ToString();
            }
        }

        //Objetivo: Simular chaves key online, comparar chave inserida com uma lista online de chaves.
        private void btnSimulateProductKey_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            try
            {
                //importante obter o link somente com conteudo "raw" para obter somente o texto
                string pagina = wc.DownloadString("https://pastebin.com/raw/j07dE2rf");
                //obtem a versão do assembly pode ser alterada em
                //Projeto > Propriedade > Aplicativo > Informações do Assembly > Versão do arquivo
                string text = textBox1.Text;
                //patterns
                string p_initLine = "^";
                string p_endLine = "\r?$"; //https://social.msdn.microsoft.com/Forums/en-US/97dc5640-3c46-4246-bbbe-7d785a96a767/multiline-option-does-not-work?forum=regexp
                string p_date = @"\d\d\/\d\d\/\d{4}";
                string p_anyWord = @"\w+";
                string pattern = p_initLine + text + ";" +p_date+ ";"+ p_anyWord + p_endLine;

                //bool contem_na_lista = Regex.IsMatch(pagina, pattern, RegexOptions.Multiline);

                //1º validação, CHAVE
                var matches = Regex.Matches(pagina, pattern, RegexOptions.Multiline);
                if (matches.Count == 1)
                {
                    MessageBox.Show("Chave Válida");

                    string matched = matches[0].Value;
                    string serialNo = getSerialNumber();
                    //2º validação SerialNumber(id unico do hd/ssd)
                    bool serialAutorizado = Regex.IsMatch(matched, serialNo + p_endLine);
                    if (serialAutorizado) {
                        MessageBox.Show("Serial Autorizado.");

                        //3º validação data de expiração
                        Match match = Regex.Match(matched, p_date);
                        if (match.Success) {
                            string date = match.Value;
                            DateTime limit_acess_date = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                            DateTime time_now_online = GetOnlineTime();
                            int days = (limit_acess_date - time_now_online).Days;
                            if (limit_acess_date > time_now_online)
                            {
                                MessageBox.Show("Você pode acessar o sistema por " + days + " dias, vencerá " + limit_acess_date.ToString("dd/MM/yyyy"), "AUTORIZADO");
                            }
                            else {
                                MessageBox.Show("O prazo expirou há" + days + " dias, venceu " + limit_acess_date.ToString("dd/MM/yyyy"), "NEGADO");
                            }

                        }
                    }

                }
                else if (matches.Count > 1)
                {
                    string chave = "";
                    foreach (Match match in matches)
                    {
                        chave += match.Value + "\n";
                    }
                    MessageBox.Show("Chave Dúplicada");
                }
                else {
                    MessageBox.Show("Chave INVÁLIDA");
                }
            }
            catch
            {
                MessageBox.Show("não foi possivel a verificação online.");
            }
        }
        

        /*
         Utilidade: Definir que acesso ao programa seja sempre da versao mais recente do software.
        1º passo: Criar um arquivo no paste bin que colocara a versão, pois neste arquivo 
                   voce mantera a versão atual do programa para comparação dos da versao dos softwares.
        */
        private string getVersionOnline()
        {

            WebClient wc = new WebClient();
            try
            {
                //importante obter o link somente com conteudo "raw" para obter somente o texto
                string pagina = wc.DownloadString("https://pastebin.com/raw/6mjvaLhX");
                //obtem a versão do assembly pode ser alterada em
                return pagina;                
            }
            catch {
                MessageBox.Show("não foi possivel a verificação online.");
                return "";
            }
        }

        /*
         Utilidades: 
         Validar data online, sem ser do computador para dificultar que o usuario burle o sistema
        */
        public DateTime GetOnlineTime()
        {
            DateTime dateTime;
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                dateTime = DateTime.ParseExact
                    (todaysDates,
                    "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                    System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat,
                    System.Globalization.DateTimeStyles.AssumeUniversal);

            }
            catch { dateTime = DateTime.MinValue; };            

            return dateTime;
        }

        /*
            Utilidades: 
            Validar se um computador pode acessar determinado software, ou definir tipos de acessos especificos... 
             
        */
        private string getSerialNumber() {
            var moSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");            
            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                string model = wmi_HD["Model"].ToString();  //Model Number
                string type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                string serialNo = wmi_HD["SerialNumber"].ToString(); //HWID
                return serialNo;
            }
            return "Serial not found";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }
    }
}
