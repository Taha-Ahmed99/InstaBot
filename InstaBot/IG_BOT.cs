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
using SocialMediaBot;

namespace TestAppBot
{
    public partial class IG_BOT : Form
    {
        public IG_BOT()
        {
            InitializeComponent();
        }
        int a = 0;
        
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "YmwNw7ft4HUveo4Z0JBbsGtqLNxWoBfauIUDz6GH",
            BasePath = "https://botapp-5f701-default-rtdb.firebaseio.com"
        };
        IFirebaseClient client;

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterForm Rf = new RegisterForm();
            this.Hide();
            Rf.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            notify notify = new notify();
            notify.Show();
            label5.Hide();
            try
            {
                client = new FireSharp.FirebaseClient(config);

                if (client != null)
                {
                    this.CenterToScreen();
                    textBox2.UseSystemPasswordChar = true;

                }
            }
            catch
            {
                MessageBox.Show("Connection is not established");
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //---------------------BUTTON CODE--------------------//

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    errorProvider1.SetError(textBox1, "Enter User Name");
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Enter User Password");
                }
            }
            else
            {
             FirebaseResponse response = client.Get("Users/");
             IDictionary<string, Register> result = response.ResultAs<Dictionary<string, Register>>();

                foreach (var get in result)
                {
                    if (textBox1.Text == get.Value.username && textBox2.Text == get.Value.password)
                    {
                        a = 1;
                    }
                    
                }
                if (a == 1)
                {
                    APP app = new APP();
                    this.Hide();
                    app.Show();

                }
                else if (a == 0)
                {
                    label5.Show();
                    label5.Text = "Incorrect Credentials!";
                }

            }
        
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegisterForm Rf = new RegisterForm();
            this.Hide();
            Rf.Show();
        }//Button 2 CODE END

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Enter Username & User ID");
                }
                else
                {
                    FirebaseResponse response = client.Get("Users/");
                    IDictionary<string, Register> result = response.ResultAs<Dictionary<string, Register>>();

                    foreach (var get in result)
                    {
                        if (textBox1.Text == get.Value.username && textBox2.Text == get.Value.password)
                        {
                            a = 1;
                        }

                        
                    }
                    if (a == 1)
                    { 
                        APP app = new APP();
                        this.Hide();
                        app.Show();
                    }
                    else if (a == 0)
                    {
                        label5.Show();
                        label5.Text = "Incorrect Credentials!";
                    }

                }
            }
        }
    }


}//NameSpace End

