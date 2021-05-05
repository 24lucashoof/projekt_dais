
namespace DAIS_project
{
    partial class VysveceniForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_zpet = new System.Windows.Forms.Button();
            this.listbox_znamky = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_zpet
            // 
            this.button_zpet.Location = new System.Drawing.Point(78, 351);
            this.button_zpet.Name = "button_zpet";
            this.button_zpet.Size = new System.Drawing.Size(75, 23);
            this.button_zpet.TabIndex = 1;
            this.button_zpet.Text = "Zpet";
            this.button_zpet.UseVisualStyleBackColor = true;
            this.button_zpet.Click += new System.EventHandler(this.button_zpet_Click);
            // 
            // listbox_znamky
            // 
            this.listbox_znamky.FormattingEnabled = true;
            this.listbox_znamky.Location = new System.Drawing.Point(78, 71);
            this.listbox_znamky.Name = "listbox_znamky";
            this.listbox_znamky.Size = new System.Drawing.Size(533, 212);
            this.listbox_znamky.TabIndex = 2;
            this.listbox_znamky.SelectedIndexChanged += new System.EventHandler(this.listbox_znamky_SelectedIndexChanged);
            // 
            // VysveceniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listbox_znamky);
            this.Controls.Add(this.button_zpet);
            this.Controls.Add(this.label1);
            this.Name = "VysveceniForm";
            this.Text = "VysveceniForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_zpet;
        private System.Windows.Forms.ListBox listbox_znamky;
    }
}