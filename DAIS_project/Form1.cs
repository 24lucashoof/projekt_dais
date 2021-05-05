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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //List<Student> students = Student.Find();
            //foreach(Student s in students)
            //    listBox1.Items.Add(s);

            //List<Info> info = Info.Find();
            //foreach (Info i in info)
            //    listBox1.Items.Add(i);

            List<Ucitel> teachers = Ucitel.Find();
            foreach (Ucitel u in teachers)
                listBox1.Items.Add(u);

            listBox1.Items.Add(Ucitel.test());

            //List<Predmet> subjects = Predmet.Find();
            //foreach(Predmet p in subjects)
            //    listBox1.Items.Add(p);

            //List<Mistnost> rooms = Mistnost.Find();
            //foreach(Mistnost m in rooms)
            //    listBox1.Items.Add(m);

            //List<Zkousky> exams = Zkousky.Find();
            //foreach (Zkousky z in exams)
            //    listBox1.Items.Add(z);

            //List<cas_vyucovani> study_times = cas_vyucovani.Find();
            //foreach (cas_vyucovani cv in study_times)
            //    listBox1.Items.Add(cv);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void zapsat_znamku_button_Click(object sender, EventArgs e)
        {
            ZapsatZnamkuForm form = new ZapsatZnamkuForm(this);
            form.Show();
            this.Hide();
        }

        // button_vysveceni
        private void button_vysveceni_Click(object sender, EventArgs e)
        {
            VysveceniForm form = new VysveceniForm(this);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentEditace form = new StudentEditace(this);
            this.Hide();
            form.Show();

        }
    }
}
