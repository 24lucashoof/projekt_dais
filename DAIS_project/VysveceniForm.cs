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
            this.form = form;
            InitializeComponent();
            Student s = Student.FindByID(1);
            label1.Text = s.vysveceni();
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
    }
}
