using Newtonsoft.Json;
using System.Text;

namespace appww1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string url = "https://localhost:44374/api/employees";
        private List<Employee> emp_list;
        private async void button1_Click(object sender, EventArgs e)
        {
            emp_list = await webservices.Get_api(url);
            richTextBox1.Text = "";
            for (int i = 0; i < emp_list.Count; i++)
            {

                richTextBox1.Text = richTextBox1.Text + "\n\n\n  name is :" + emp_list[i].name + "\n";
                richTextBox1.Text = richTextBox1.Text + " id is :" + emp_list[i].id + "\n";
                richTextBox1.Text = richTextBox1.Text + " Address is:" + emp_list[i].address + "\n";
                richTextBox1.Text = richTextBox1.Text + " phone number is :" + emp_list[i].phone_number;



            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Employee emp_new = new Employee();
            emp_new.name = textBox1.Text;
            emp_new.address = textBox2.Text;
            emp_new.phone_number = textBox3.Text;
            emp_new.id = Guid.NewGuid().ToString();

            var json = JsonConvert.SerializeObject(emp_new);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await webservices.post_To_api(url, data);
            emp_list = await webservices.Get_api(url);

            richTextBox1.Text = "";
            for (int i = 0; i < emp_list.Count; i++)
            {
                if (emp_list[i].name == emp_new.name)
                {

                    richTextBox1.Text = richTextBox1.Text + "\n\n\n  name is :" + emp_list[i].name + "\n";
                    richTextBox1.Text = richTextBox1.Text + " id is :" + emp_list[i].id + "\n";
                    richTextBox1.Text = richTextBox1.Text + " Address is:" + emp_list[i].address + "\n";
                    richTextBox1.Text = richTextBox1.Text + " phone number is :" + emp_list[i].phone_number;
                    break;
                }
                else if (i == emp_list.Count - 1)
                {
                    richTextBox1.Text = "record was not posted";
                }



            }


        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string enquery = textBox1.Text;
            emp_list = await webservices.Get_api(url);
            for (int i = 0; i < emp_list.Count; i++)
            {
                if (emp_list[i].name == enquery)
                {
                    richTextBox1.Text = "";
                    richTextBox1.Text = "record found";
                    richTextBox1.Text = richTextBox1.Text + "\n\n\n  name is :" + emp_list[i].name + "\n";
                    richTextBox1.Text = richTextBox1.Text + " id is :" + emp_list[i].id + "\n";
                    richTextBox1.Text = richTextBox1.Text + " Address is:" + emp_list[i].address + "\n";
                    richTextBox1.Text = richTextBox1.Text + " phone number is :" + emp_list[i].phone_number;
                    i = i + emp_list.Count;
                    break;
                }
                else if (i == emp_list.Count - 1 && emp_list[i - 1].name != enquery)
                {
                    richTextBox1.Text = "record not found";
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            emp_list = await webservices.Get_api(url);
            string id = "";

            for (int i = 0; i < emp_list.Count; i++)
            {
                if (emp_list[i].name == name)
                {
                    id = emp_list[i].id;
                    webservices.Delete(url, id);
                    richTextBox1.Text = "deleted succesfully ";

                    break;
                }
                else if (i == emp_list.Count - 1 && emp_list[i - 1].name != name)
                {
                    richTextBox1.Text = "record not found";
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            emp_list = await webservices.Get_api(url);
            for (int i = 0; i < emp_list.Count; i++)
            {
                if (emp_list[i].name == name)
                {
                    DBcon.store(emp_list[i].id, emp_list[i].name, emp_list[i].address, emp_list[i].phone_number);
                    richTextBox1.Text = "stored to the database";


                }

                else if (i == emp_list.Count - 1 && emp_list[i - 1].name != name)
                {
                    richTextBox1.Text = "record not found";
                }

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}