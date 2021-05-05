using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataLayer;

namespace DAIS_project
{
    public partial class StudentEditace : Form
    {
        public Form1 form;
        public Student s;

        public StudentEditace(Form1 form)
        {
            this.form = form;
            InitializeComponent();

            s = Student.FindByID(1);
            textbox_jmeno.Text = s.jmeno;
            textbox_prijmeni.Text = s.prijmeni;
            textbox_adresa.Text = s.infoID.adresa;
            textbox_telefon.Text = s.infoID.telefon;
            textbox_email.Text = s.infoID.email;
        }

        // button_submit
        private void button_submit_Click(object sender, EventArgs e)
        {
            bool correctEmail = false;
            foreach (char c in textbox_email.Text)
            {
                if (c == '@')
                    correctEmail = true;
            }

            if (correctEmail && textbox_telefon.Text.Length == 9)
            {
                s.infoID.email = textbox_email.Text;
                s.infoID.telefon = textbox_telefon.Text;
                s.Update();
            }
            else
            { 
                MessageBox.Show("Spatny email, nebo telefon");
                textbox_email.Text = s.infoID.email;
                textbox_telefon.Text = s.infoID.telefon;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void textbox_jmeno_TextChanged(object sender, EventArgs e)
        {
            if (textbox_jmeno.Text.Any(char.IsDigit))
                MessageBox.Show("Spatne zadane jmeno");
            else
                s.jmeno = textbox_jmeno.Text;


            textbox_jmeno.Text = s.jmeno;
        }

        private void textbox_prijmeni_TextChanged(object sender, EventArgs e)
        {
            if (textbox_prijmeni.Text.Any(char.IsDigit))
                MessageBox.Show("Spatne zadane prijmeni");
            else
                s.prijmeni = textbox_prijmeni.Text;


            textbox_prijmeni.Text = s.prijmeni;
        }

        private void textbox_adresa_TextChanged(object sender, EventArgs e)
        {
            s.infoID.adresa = textbox_adresa.Text;
        }

        private void textbox_telefon_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textbox_email_TextChanged(object sender, EventArgs e)
        {
            

        }
    }
}
