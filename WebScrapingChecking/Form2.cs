using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;


/*
 Exemplo de captura de dados de uma pagina web.
 neste exemplo é demonstrado a captura de informações do forum da msdn.
 aula do canal Coding Night, ministrada pelo MSP André Secco     
 */

namespace WebScrapingChecking
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            var wc = new WebClient();
            //faz o download do html para string
            string pagina = wc.DownloadString("https://social.msdn.microsoft.com/Forums/pt-BR/home?forum=vscsharppt");
            //baixar via nugget para manipulação do html
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            //passa a pagina para o objeto para poder manipular
            htmlDocument.LoadHtml(pagina);

            string id = string.Empty;
            string titulo = string.Empty;
            string postagem = string.Empty;
            string exibicao = string.Empty;
            string resposta = string.Empty;
            string link = string.Empty;

            //para cada item <li> dentro da lista <ul id="threadList">
            foreach (HtmlNode node in htmlDocument.GetElementbyId("threadList").ChildNodes)
            {
                //se o <li> tiver atributos
                if (node.Attributes.Count > 0)
                {
                    id = node.Attributes["data-threadid"].Value;
                    link = "https://social.msdn.microsoft.com/Forums/pt-BR/" + id;
                    //busca nos filhos qual o primeiro item onde o id="threadTitle_...."
                    titulo = node.Descendants().First(x => x.Id.Equals("threadTitle_" + id)).InnerText;
             
                    postagem = WebUtility.HtmlDecode(node.Descendants("span").First(o => o.GetAttributeValue("class", "") == "lastpost").InnerText.Replace("\n", "").Replace("  ", ""));
                    exibicao = WebUtility.HtmlDecode(node.Descendants().First(o => o.GetAttributeValue("class", "") == "viewcount").InnerText);
                    resposta = WebUtility.HtmlDecode(node.Descendants().First(o => o.GetAttributeValue("class", "") == "replycount").InnerText);
                    if (!string.IsNullOrEmpty(titulo))
                    {
                        dataGridView1.Rows.Add(titulo, postagem, exibicao, resposta, link);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //abrir o link apos clicar
            if (e.ColumnIndex == 4) {
                Process.Start(new ProcessStartInfo(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));
            }
        }
    }
}
