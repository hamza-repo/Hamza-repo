
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
    public partial class Form1 : Form
    {
        public static UserDb guser { get; internal set; }

        public Form1()
        {
            InitializeComponent();
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var cont = new NEWdbEntities();
            var newuser = new UserDb();
            if (passwordBox.Text != passwordBox2.Text)
                passwordBox.Text = "Passowrds dont match";
            else
            {
                newuser.Name = textBox1.Text;
                newuser.password = crypt.hash(passwordBox.Text);
                newuser.father_median_name = crypt.hash(fatherBox.Text);
                newuser.primary_school_name = crypt.hash(scoolBox.Text);
                newuser.mother_s_day_of_birth = crypt.hash(numericUpDown1.Value.ToString());
                cont.UserDbs.Add(newuser);
                int returnvalue = cont.SaveChanges();



                string massage = "did not store correctly";
                if (returnvalue == 0)
                    MessageBox.Show(massage);
                else
                {
                    massage = "stored correctly";
                    MessageBox.Show(massage);
                }
            }
            


            }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Username = richTextBox1.Text;
            var cont = new NEWdbEntities();
             guser = cont.UserDbs.Where(x => x.Name == Username).FirstOrDefault();
            if (guser == null)
                richTextBox1.Text = "User not found ";
            else { 
            var myForm = new Form2();
            myForm.Show();
                
        }
            




        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
        
        }
    
                

            

        
    

