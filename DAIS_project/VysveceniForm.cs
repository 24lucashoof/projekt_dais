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
    public partial class VysveceniForm : Form
    {
        public Form1 form;
        public VysveceniForm(Form1 form)
        {
            int STUDENT_ID = 5;


            this.form = form;
            InitializeComponent();
            Student s = Student.FindByID(STUDENT_ID);
            label1.Text = s.vysveceni();

            List<Zkousky> zkousky = Zkousky.Find();
            List<Zkousky> _zkousky = new List<Zkousky>();

            foreach (Zkousky z in zkousky)
            {
                if (z.studentID.studentID == STUDENT_ID)
                    _zkousky.Add(z);
            }

            // sort by date
            List<Zkousky> new__  = _zkousky.OrderBy(o => o.datum_zkousky).ToList();


            Dictionary<int, string> __zkousky = new Dictionary<int, string>();

            foreach (Zkousky z in new__)
            {
                if (!__zkousky.ContainsKey(z.predmetID.predmetID))
                { 
                    __zkousky.Add(z.predmetID.predmetID, z.znamka);
                    string _z = z.predmetID.zkratka + "\t\t" + z.znamka;
                    listbox_znamky.Items.Add(_z);
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        // button_zpet
        private void button_zpet_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        // listbox_znamky
        private void listbox_znamky_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
