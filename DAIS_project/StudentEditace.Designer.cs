
namespace DAIS_project
{
    partial class StudentEditace
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
            this.button_submit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_jmeno = new System.Windows.Forms.TextBox();
            this.textbox_prijmeni = new System.Windows.Forms.TextBox();
            this.textbox_adresa = new System.Windows.Forms.TextBox();
            this.textbox_telefon = new System.Windows.Forms.TextBox();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_submit
            // 
            this.button_submit.Location = new System.Drawing.Point(417, 314);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(75, 23);
            this.button_submit.TabIndex = 0;
            this.button_submit.Text = "Submit";
            this.button_submit.UseVisualStyleBackColor = true;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(161, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Zpet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jmeno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prijmeni";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Adresa";
            // 
            // textbox_jmeno
            // 
            this.textbox_jmeno.Location = new System.Drawing.Point(202, 41);
            this.textbox_jmeno.Name = "textbox_jmeno";
            this.textbox_jmeno.Size = new System.Drawing.Size(181, 20);
            this.textbox_jmeno.TabIndex = 5;
            this.textbox_jmeno.TextChanged += new System.EventHandler(this.textbox_jmeno_TextChanged);
            // 
            // textbox_prijmeni
            // 
            this.textbox_prijmeni.Location = new System.Drawing.Point(202, 68);
            this.textbox_prijmeni.Name = "textbox_prijmeni";
            this.textbox_prijmeni.Size = new System.Drawing.Size(181, 20);
            this.textbox_prijmeni.TabIndex = 6;
            this.textbox_prijmeni.TextChanged += new System.EventHandler(this.textbox_prijmeni_TextChanged);
            // 
            // textbox_adresa
            // 
            this.textbox_adresa.Location = new System.Drawing.Point(202, 95);
            this.textbox_adresa.Name = "textbox_adresa";
            this.textbox_adresa.Size = new System.Drawing.Size(181, 20);
            this.textbox_adresa.TabIndex = 7;
            this.textbox_adresa.TextChanged += new System.EventHandler(this.textbox_adresa_TextChanged);
            // 
            // textbox_telefon
            // 
            this.textbox_telefon.Location = new System.Drawing.Point(202, 122);
            this.textbox_telefon.Name = "textbox_telefon";
            this.textbox_telefon.Size = new System.Drawing.Size(181, 20);
            this.textbox_telefon.TabIndex = 8;
            this.textbox_telefon.TextChanged += new System.EventHandler(this.textbox_telefon_TextChanged);
            // 
            // textbox_email
            // 
            this.textbox_email.Location = new System.Drawing.Point(202, 149);
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(181, 20);
            this.textbox_email.TabIndex = 9;
            this.textbox_email.TextChanged += new System.EventHandler(this.textbox_email_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Telefon";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Email";
            // 
            // StudentEditace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.textbox_telefon);
            this.Controls.Add(this.textbox_adresa);
            this.Controls.Add(this.textbox_prijmeni);
            this.Controls.Add(this.textbox_jmeno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_submit);
            this.Name = "StudentEditace";
            this.Text = "StudentEditace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_jmeno;
        private System.Windows.Forms.TextBox textbox_prijmeni;
        private System.Windows.Forms.TextBox textbox_adresa;
        private System.Windows.Forms.TextBox textbox_telefon;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}