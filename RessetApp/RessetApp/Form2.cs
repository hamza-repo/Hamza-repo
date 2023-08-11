using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RessetApp
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            label1.Text = Form1.guser.Name + " "+ label1.Text + " Enter:";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {






            if (crypt.hash(fath.Text) == Form1.guser.father_median_name  && crypt.hash(scho.Text) == Form1.guser.primary_school_name  && crypt.hash(moth.Value.ToString()) == Form1.guser.mother_s_day_of_birth )
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                string massage = "wrong information";
                MessageBox.Show(massage);
            }
            this.Close();


        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
