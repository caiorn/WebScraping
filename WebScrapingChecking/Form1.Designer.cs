namespace WebScrapingChecking
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDataHora = new System.Windows.Forms.Button();
            this.lblData = new System.Windows.Forms.Label();
            this.btnSimulateProductKey = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCheckVersion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetHWIDserialNumber = new System.Windows.Forms.Button();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDataHora
            // 
            this.btnDataHora.Location = new System.Drawing.Point(12, 100);
            this.btnDataHora.Name = "btnDataHora";
            this.btnDataHora.Size = new System.Drawing.Size(133, 23);
            this.btnDataHora.TabIndex = 0;
            this.btnDataHora.Text = "Obter Hora online";
            this.btnDataHora.UseVisualStyleBackColor = true;
            this.btnDataHora.Click += new System.EventHandler(this.btnDataHora_Click);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(9, 84);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(33, 13);
            this.lblData.TabIndex = 1;
            this.lblData.Text = "Data:";
            // 
            // btnSimulateProductKey
            // 
            this.btnSimulateProductKey.Location = new System.Drawing.Point(15, 268);
            this.btnSimulateProductKey.Name = "btnSimulateProductKey";
            this.btnSimulateProductKey.Size = new System.Drawing.Size(130, 23);
            this.btnSimulateProductKey.TabIndex = 2;
            this.btnSimulateProductKey.Text = "Verificar Chave";
            this.btnSimulateProductKey.UseVisualStyleBackColor = true;
            this.btnSimulateProductKey.Click += new System.EventHandler(this.btnSimulateProductKey_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 3;
            // 
            // btnCheckVersion
            // 
            this.btnCheckVersion.Location = new System.Drawing.Point(12, 29);
            this.btnCheckVersion.Name = "btnCheckVersion";
            this.btnCheckVersion.Size = new System.Drawing.Size(133, 23);
            this.btnCheckVersion.TabIndex = 4;
            this.btnCheckVersion.Text = "Verificar Versão";
            this.btnCheckVersion.UseVisualStyleBackColor = true;
            this.btnCheckVersion.Click += new System.EventHandler(this.btnCheckVersion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chave:";
            // 
            // btnGetHWIDserialNumber
            // 
            this.btnGetHWIDserialNumber.Location = new System.Drawing.Point(12, 175);
            this.btnGetHWIDserialNumber.Name = "btnGetHWIDserialNumber";
            this.btnGetHWIDserialNumber.Size = new System.Drawing.Size(75, 23);
            this.btnGetHWIDserialNumber.TabIndex = 6;
            this.btnGetHWIDserialNumber.Text = "Serial Hard Disk";
            this.btnGetHWIDserialNumber.UseVisualStyleBackColor = true;
            this.btnGetHWIDserialNumber.Click += new System.EventHandler(this.btnGetHWIDserialNumber_Click);
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(12, 149);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.ReadOnly = true;
            this.txtSerialNumber.Size = new System.Drawing.Size(205, 20);
            this.txtSerialNumber.TabIndex = 8;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(12, 13);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(75, 13);
            this.lblVersao.TabIndex = 9;
            this.lblVersao.Text = "Ultima Versão:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(183, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "part2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 311);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.btnGetHWIDserialNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheckVersion);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSimulateProductKey);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.btnDataHora);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDataHora;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button btnSimulateProductKey;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnCheckVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetHWIDserialNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button button1;
    }
}

