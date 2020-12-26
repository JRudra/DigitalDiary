using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalDiary;

namespace DigitalDiary
{
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
            string query = "SELECT * FROM Users WHERE UserName = '"+ usernameTextBox.Text.Trim() + "' AND Password='"+ passwordTextBox.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection2);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Form3 objForm3 = new Form3();
                this.Hide();
                objForm3.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
            //this.Hide();
            //Form3 ft = new Form3();
            //ft.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void homePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void signUpLinkLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration ab = new Registration();
            ab.Show();
        }
    }
}
