namespace CurrencyConvertor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CurrencyExchangeLabel1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CurrencyValueBox1 = new System.Windows.Forms.ComboBox();
            this.CurrencyValueBox2 = new System.Windows.Forms.ComboBox();
            this.CurrencyExchangeLabel2 = new System.Windows.Forms.Label();
            this.CurrencyValue1 = new System.Windows.Forms.TextBox();
            this.CurrencyValue2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CurrencyExchangeLabel1
            // 
            this.CurrencyExchangeLabel1.AutoSize = true;
            this.CurrencyExchangeLabel1.Location = new System.Drawing.Point(38, 50);
            this.CurrencyExchangeLabel1.Name = "CurrencyExchangeLabel1";
            this.CurrencyExchangeLabel1.Size = new System.Drawing.Size(184, 17);
            this.CurrencyExchangeLabel1.TabIndex = 1;
            this.CurrencyExchangeLabel1.Text = "Enter Currency to exchange";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(41, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CurrencyValueBox1
            // 
            this.CurrencyValueBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyValueBox1.FormattingEnabled = true;
            this.CurrencyValueBox1.Location = new System.Drawing.Point(41, 70);
            this.CurrencyValueBox1.Name = "CurrencyValueBox1";
            this.CurrencyValueBox1.Size = new System.Drawing.Size(220, 44);
            this.CurrencyValueBox1.TabIndex = 4;
            // 
            // CurrencyValueBox2
            // 
            this.CurrencyValueBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyValueBox2.FormattingEnabled = true;
            this.CurrencyValueBox2.Location = new System.Drawing.Point(339, 70);
            this.CurrencyValueBox2.Name = "CurrencyValueBox2";
            this.CurrencyValueBox2.Size = new System.Drawing.Size(220, 44);
            this.CurrencyValueBox2.TabIndex = 5;
            // 
            // CurrencyExchangeLabel2
            // 
            this.CurrencyExchangeLabel2.AutoSize = true;
            this.CurrencyExchangeLabel2.Location = new System.Drawing.Point(336, 50);
            this.CurrencyExchangeLabel2.Name = "CurrencyExchangeLabel2";
            this.CurrencyExchangeLabel2.Size = new System.Drawing.Size(200, 17);
            this.CurrencyExchangeLabel2.TabIndex = 6;
            this.CurrencyExchangeLabel2.Text = "Enter Currency to exchange to";
            // 
            // CurrencyValue1
            // 
            this.CurrencyValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyValue1.Location = new System.Drawing.Point(41, 129);
            this.CurrencyValue1.Name = "CurrencyValue1";
            this.CurrencyValue1.Size = new System.Drawing.Size(119, 41);
            this.CurrencyValue1.TabIndex = 7;
            // 
            // CurrencyValue2
            // 
            this.CurrencyValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrencyValue2.Location = new System.Drawing.Point(339, 129);
            this.CurrencyValue2.Name = "CurrencyValue2";
            this.CurrencyValue2.Size = new System.Drawing.Size(119, 41);
            this.CurrencyValue2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 338);
            this.Controls.Add(this.CurrencyValue2);
            this.Controls.Add(this.CurrencyValue1);
            this.Controls.Add(this.CurrencyExchangeLabel2);
            this.Controls.Add(this.CurrencyValueBox2);
            this.Controls.Add(this.CurrencyValueBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CurrencyExchangeLabel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CurrencyExchangeLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CurrencyValueBox1;
        private System.Windows.Forms.ComboBox CurrencyValueBox2;
        private System.Windows.Forms.Label CurrencyExchangeLabel2;
        private System.Windows.Forms.TextBox CurrencyValue1;
        private System.Windows.Forms.TextBox CurrencyValue2;
    }

}

