namespace DES
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_encrText = new System.Windows.Forms.TextBox();
            this.textBox_decrText = new System.Windows.Forms.TextBox();
            this.textBox_basisText = new System.Windows.Forms.TextBox();
            this.textBox_decKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_encrKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDecipher = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Расшифрованный текст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Зашифрованный текст";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Оригинальный текст";
            // 
            // textBox_encrText
            // 
            this.textBox_encrText.Location = new System.Drawing.Point(64, 296);
            this.textBox_encrText.MaxLength = 99999999;
            this.textBox_encrText.Name = "textBox_encrText";
            this.textBox_encrText.Size = new System.Drawing.Size(649, 22);
            this.textBox_encrText.TabIndex = 24;
            // 
            // textBox_decrText
            // 
            this.textBox_decrText.Location = new System.Drawing.Point(63, 395);
            this.textBox_decrText.MaxLength = 99999999;
            this.textBox_decrText.Name = "textBox_decrText";
            this.textBox_decrText.Size = new System.Drawing.Size(650, 22);
            this.textBox_decrText.TabIndex = 23;
            // 
            // textBox_basisText
            // 
            this.textBox_basisText.Location = new System.Drawing.Point(64, 191);
            this.textBox_basisText.MaxLength = 99999999;
            this.textBox_basisText.Name = "textBox_basisText";
            this.textBox_basisText.Size = new System.Drawing.Size(649, 22);
            this.textBox_basisText.TabIndex = 22;
            this.textBox_basisText.Text = "hello my friend anton";
            // 
            // textBox_decKey
            // 
            this.textBox_decKey.Location = new System.Drawing.Point(555, 62);
            this.textBox_decKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_decKey.Name = "textBox_decKey";
            this.textBox_decKey.Size = new System.Drawing.Size(148, 22);
            this.textBox_decKey.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ключ расшифровки";
            // 
            // textBox_encrKey
            // 
            this.textBox_encrKey.Location = new System.Drawing.Point(63, 62);
            this.textBox_encrKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_encrKey.Name = "textBox_encrKey";
            this.textBox_encrKey.Size = new System.Drawing.Size(148, 22);
            this.textBox_encrKey.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ключ шифровки";
            // 
            // buttonDecipher
            // 
            this.buttonDecipher.Location = new System.Drawing.Point(555, 107);
            this.buttonDecipher.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDecipher.Name = "buttonDecipher";
            this.buttonDecipher.Size = new System.Drawing.Size(149, 28);
            this.buttonDecipher.TabIndex = 17;
            this.buttonDecipher.Text = "Расшифровать";
            this.buttonDecipher.UseVisualStyleBackColor = true;
            this.buttonDecipher.Click += new System.EventHandler(this.buttonDecipher_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(64, 107);
            this.buttonEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(147, 28);
            this.buttonEncrypt.TabIndex = 16;
            this.buttonEncrypt.Text = "Зашифровать";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_encrText);
            this.Controls.Add(this.textBox_decrText);
            this.Controls.Add(this.textBox_basisText);
            this.Controls.Add(this.textBox_decKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_encrKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDecipher);
            this.Controls.Add(this.buttonEncrypt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_encrText;
        private System.Windows.Forms.TextBox textBox_decrText;
        private System.Windows.Forms.TextBox textBox_basisText;
        private System.Windows.Forms.TextBox textBox_decKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_encrKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDecipher;
        private System.Windows.Forms.Button buttonEncrypt;
    }
}

