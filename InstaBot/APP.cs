using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAppBot
{
    public partial class APP : Form
    {
        private static UserSessionData user;
        

        public APP()
        {
            InitializeComponent();
        }
        int index;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private async void button2_Click(object sender, EventArgs e)
        {
           
            var fs = await APIclass.api.UserProcessor.GetUserFollowingAsync(textBox1.Text, PaginationParameters.MaxPagesToLoad(1));

            dataGridView1.Rows.Clear();
            foreach (var item in fs.Value)
            {
                dataGridView1.Rows.Add(item.FullName,item.UserName);
            }
            dataGridView1.Show();
            
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                var user = await APIclass.api.UserProcessor.GetUserAsync(item.Cells[0].Value.ToString());
                var f = await APIclass.api.UserProcessor.FollowUserAsync(user.Value.Pk);
                if (f.Succeeded)
                {
                    MessageBox.Show("User Followed");
                }
                else
                {
                    MessageBox.Show("User Not Followed");
                }
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var fs = await APIclass.api.UserProcessor.GetCurrentUserFollowersAsync(PaginationParameters.MaxPagesToLoad(1));

            dataGridView2.Rows.Clear();
            foreach (var item in fs.Value)
            {
                dataGridView2.Rows.Add(item.FullName, item.UserName);
            }
            dataGridView2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label12.Hide();
            richTextBox1.Hide();
            button3.Hide();
            textBox5.Hide();
            b_dm.Hide();
            button2.Hide();
            button3.Hide();
            button7.Hide();
            Updat.Hide();
            button5.Hide();
            button6.Hide();
            dataGridView3.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            label2.Hide();
            label3.Hide();
            label7.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label2.Hide();
            label1.Hide();
            label6.Hide();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView3.Rows)
            {
                //var user = await APIclass.api.UserProcessor.GetUserAsync(item.Cells[0].Value.ToString());
                //var desireUsername = textBox4.Text;
                var user = await APIclass.api.UserProcessor.GetUserAsync(item.Cells[0].Value.ToString());
                var userId = user.Value.Pk.ToString();
                var directText = await APIclass.api.MessagingProcessor
                    .SendDirectTextAsync(userId, null, richTextBox1.Text + "\ngenerated using igbot_z");
                if (directText.Succeeded)
                {
                    MessageBox.Show("Send Sucessfully");

                }
                else
                {
                    MessageBox.Show("Send Failed");
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Text = "PROFILE PIC"+textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            label12.Show();
            pictureBox2.Show();
            this.label3.Text = textBox1.Text;
            user = new UserSessionData();
            user.UserName = textBox1.Text;
            user.Password = textBox2.Text;
            APIclass.api = InstaApiBuilder.CreateBuilder()
                .SetUser(user)
                .UseLogger(new DebugLogger(LogLevel.All))
                .SetRequestDelay(RequestDelay.FromSeconds(0, 1))
                .Build();

            var IsLog = await APIclass.api.LoginAsync();
            if (IsLog.Succeeded)
            {
                pictureBox1.Load(APIclass.api.GetLoggedUser().LoggedInUser.ProfilePicture);
                pictureBox1.Show();
                label3.Show();
                dataGridView3.Show();
                textBox5.Show();
                Updat.Show();
                label9.Show();
                button7.Show();
                label7.Show();
                label1.Show();
                button2.Show();
                button5.Show();
                label11.Show();
                label10.Show();
                button6.Show();
                label8.Hide();
                label4.Hide();
                label5.Hide();
                checkBox1.Hide();
                textBox1.Hide();
                textBox2.Hide();
                button1.Hide();
                pictureBox2.Hide();
                label12.Hide();
                button3.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Credentials"+"  "+"\nTryAgain");
                label12.Hide();
                pictureBox2.Hide();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.button6.Hide();
            b_dm.Show();
            label7.Show();
            label6.Show();
            richTextBox1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int row = dataGridView3.Rows.Add();
            dataGridView3.Rows[row].Cells[0].Value = textBox5.Text;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView3.Rows[index];
            textBox5.Text = row.Cells[0].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            index = dataGridView3.CurrentCell.RowIndex;
            dataGridView3.Rows.RemoveAt(index);

        }

        private async void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                pictureBox2.Show();
                label12.Show();
                this.label3.Text = textBox1.Text;
                user = new UserSessionData();
                user.UserName = textBox1.Text;
                user.Password = textBox2.Text;
                APIclass.api = InstaApiBuilder.CreateBuilder()
                    .SetUser(user)
                    .UseLogger(new DebugLogger(LogLevel.All))
                    .SetRequestDelay(RequestDelay.FromSeconds(0, 1))
                    .Build();

                var IsLog = await APIclass.api.LoginAsync();
                if (IsLog.Succeeded)
                {
                    pictureBox1.Load(APIclass.api.GetLoggedUser().LoggedInUser.ProfilePicture);
                    pictureBox1.Show();
                    label3.Show();
                    pictureBox2.Hide();
                    dataGridView3.Show();
                    textBox5.Show();
                    Updat.Show();
                    checkBox1.Hide();
                    label9.Show();
                    button7.Show();
                    label7.Show();
                    label1.Show(); 
                    button2.Show();
                    button5.Show();
                    label11.Show();
                    label10.Show();
                    button6.Show();
                    label8.Hide();
                    label4.Hide();
                    label5.Hide();
                    textBox1.Hide();
                    textBox2.Hide();
                    button1.Hide();
                    label12.Hide();
                    



                }
                else
                {
                    MessageBox.Show("Incorrect Credentials" + "  " + "\nTryAgain");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
