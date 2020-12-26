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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            homePage f1 = new homePage();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
            connection.Open();
            
            string gen = null;
            if (radioButton1.Checked)
            {
                gen = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                gen = radioButton2.Text;
            }
            else
                gen = radioButton3.Text;
            SqlCommand command = new SqlCommand(@"INSERT INTO Users(Name,Username,Password,DateOfBirth,Gender,BloodGroup) VALUES('" + textBox1.Text +"','"+ textBox2.Text+ "','"+ textBox3.Text + "','"+ dateTimePicker1.Text + "','"+gen+"','"+comboBox1.Text+"')",connection);
           //SqlCommand command = new SqlCommand(sql, connection);
            //int result=command.ExecuteNonQuery();
            //if (result > 0)
            //{
                //MessageBox.Show("Signing up Successful");
            //}
            //else
               // MessageBox.Show("Error in signing up");
        }
    }

      
    
}
