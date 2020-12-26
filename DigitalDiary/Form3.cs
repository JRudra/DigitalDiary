using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace DigitalDiary
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO DiaryLogs (Username,Date,Entry,Importance) 
VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "')", connection1);

            cmd.ExecuteNonQuery();
            connection1.Close();

            string message = "Log added successfully";
            string title = "Confirmation";
            MessageBox.Show(message, title);

        }

        //void Display()
        //{
           // SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM DiaryLogs", connection1);
           // DataTable dt = new DataTable();
           // sda.Fill(dt);

       // }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digitalDiaryDataSet.DiaryLogs' table. You can move, or remove it, as needed.
            this.diaryLogsTableAdapter.Fill(this.digitalDiaryDataSet.DiaryLogs);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
    
}
