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
    public partial class ZapsatZnamkuForm : Form
    {
        public Form1 form;

        public ZapsatZnamkuForm(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            combobox_studentid.DataSource = Student.Find();
            combobox_predmet.DataSource = Predmet.Find();
        }

        private void ZapsatZnamkuForm_Load(object sender, EventArgs e)
        {
            
        }

        // submit_button
        private void submit_button_Click(object sender, EventArgs e)
        {
            bool correct = true;
            string znamka = textbox_znamka.Text;
            if (znamka == "A" || znamka == "B" || znamka == "C" || znamka == "D" || znamka == "FX")
            {
                // check student
                int _studentID;
                if (!Int32.TryParse(combobox_studentid.Text, out _studentID))
                    _studentID = -1;
               
                Student s = Student.FindByID(_studentID);
                if (s.jmeno == "ERROR")
                    correct = false;

                // check predmet
                int _predmetID;
                if (!Int32.TryParse(combobox_predmet.Text, out _predmetID))
                    _predmetID = -1;
                Predmet p = Predmet.FindByID(_predmetID);
                if (p.jmeno == "ERROR")
                    correct = false;

                // zapsat znamku
                if (correct)
                { 
                    Ucitel u = Ucitel.FindByID(1);
                    u.zapsat_znamku(s.studentID, p.predmetID, znamka);
                }
                else
                    MessageBox.Show("Nespravny format dat");
            }
            else
            {
                MessageBox.Show("Nespravny format znamky");
            }


            this.Hide();
            form.Show();
        }

        // combobox_studentid
        private void combobox_studentid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void combobox_studentid_TextChanged(object sender, EventArgs e)
        {

            int _studentID;
            if (!Int32.TryParse(combobox_studentid.Text, out _studentID))
            {
                _studentID = -1;
                MessageBox.Show("Nespravny typ dat");
            }

            Student s = Student.FindByID(_studentID);
            label4.Text = s.jmeno;
            label5.Text = s.prijmeni;

        }

        // combobox_predmet
        private void combobox_predmet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combobox_predmet_TextChanged(object sender, EventArgs e)
        {
            int _predmetID;
            if (!Int32.TryParse(combobox_predmet.Text, out _predmetID))
            {
                _predmetID = -1;
                MessageBox.Show("Nespravny typ dat");
            }

            Predmet p = Predmet.FindByID(_predmetID);
            label9.Text = p.jmeno;
            label10.Text = p.zkratka;
        }

        private void textbox_znamka_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
