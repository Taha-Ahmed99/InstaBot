using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;
using TestAppBot;

namespace SocialMediaBot
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "YmwNw7ft4HUveo4Z0JBbsGtqLNxWoBfauIUDz6GH",
            BasePath = "https://botapp-5f701-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            label4.Hide();
            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {
                    this.CenterToScreen();

                }
            }
            catch
            {
                MessageBox.Show("Connection is not established");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("Users/");
            IDictionary<string, Register> getsameid = response.ResultAs<Dictionary<string, Register>>();
            foreach (var SameId in getsameid)
            {
                string getsame = SameId.Value.id;
                if (textBox1.Text == getsame)
                {
                    MessageBox.Show("Id Already Taken");
                    textBox1.Text = string.Empty;
                    break;
                }
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please fill all the fields!");
            }
            else
            {
                var Register = new Register
                {
                    username = textBox2.Text,
                    password = textBox3.Text,
                    id = textBox1.Text

                };

                FirebaseResponse response = client.Set("Users/" + textBox1.Text, Register);

                Register res = response.ResultAs<Register>();
                label4.Show();
                label4.Text = ("Account Registered Successfully!");

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            IG_BOT f1 = new IG_BOT();
            f1.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Please fill all the fields!");
                }
                else
                {
                    var Register = new Register
                    {
                        username = textBox2.Text,
                        password = textBox3.Text,
                        id = textBox1.Text

                    };

                    FirebaseResponse response = client.Set("Users/" + textBox1.Text, Register);

                    Register res = response.ResultAs<Register>();
                    label4.Show();
                    label4.Text = ("Account Registered Successfully!");

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Please fill all the fields!");
                }
                else
                {
                    var Register = new Register
                    {
                        username = textBox2.Text,
                        password = textBox3.Text,
                        id = textBox1.Text

                    };

                    FirebaseResponse response = client.Set("Users/" + textBox1.Text, Register);

                    Register res = response.ResultAs<Register>();
                    label4.Show();
                    label4.Text = ("Account Registered Successfully!");

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("Users/");
            IDictionary<string, Register> getsameid = response.ResultAs<Dictionary<string, Register>>();
            foreach (var SameId in getsameid)
            {
                string getsame = SameId.Value.id;
                if (textBox1.Text == getsame)
                {
                    MessageBox.Show("Id Already Taken");
                    textBox1.Text = string.Empty;
                    break;
                }
            }
        }
    }
}

