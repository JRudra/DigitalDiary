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
using System.IO;

namespace DigitalDiary
{
    public partial class Form3 : Form
    {
        string fileName="";
        
        SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
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
            //SqlConnection connection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DigitalDiary"].ConnectionString);
            connection1.Open();
            byte[] img = null;
            FileStream fs = new FileStream(fileName, FileMode.Open,FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);
            SqlCommand cmd = new SqlCommand(@"INSERT INTO DiaryLogs (Username,Date,Entry,Importance,Image) 
VALUES ('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','"+img+"')", connection1);

            cmd.ExecuteNonQuery();
            connection1.Close();

            string message = "Log added successfully";
            string title = "Confirmation";
            MessageBox.Show(message, title);
            this.diaryLogsTableAdapter.Fill(this.digitalDiaryDataSet.DiaryLogs);

        }

 

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'digitalDiaryDataSet1.DiaryLogs' table. You can move, or remove it, as needed.
            this.diaryLogsTableAdapter1.Fill(this.digitalDiaryDataSet1.DiaryLogs);
            // TODO: This line of code loads data into the 'digitalDiaryDataSet.DiaryLogs' table. You can move, or remove it, as needed.
            this.diaryLogsTableAdapter.Fill(this.digitalDiaryDataSet.DiaryLogs);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM DiaryLogs WHERE (Username = '" + textBox1.Text + "')", connection1);
            cmd.ExecuteNonQuery();
            connection1.Close();
            MessageBox.Show("Deleted Successfully!");
            this.diaryLogsTableAdapter.Fill(this.digitalDiaryDataSet.DiaryLogs);
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

        private void button4_Click(object sender, EventArgs e)
        {
            connection1.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE DiaryLogs SET Username='"+textBox1.Text+"',Date='"+ dateTimePicker1.Text + "',Entry ='"+ textBox2.Text + "',Importance ='"+ comboBox1.Text + "'WHERE (Username = '" + textBox1.Text + "')", connection1); ;

            cmd.ExecuteNonQuery();
            connection1.Close();

            string message = "Log modified successfully";
            string title = "Confirmation";
            MessageBox.Show(message, title);
            this.diaryLogsTableAdapter.Fill(this.digitalDiaryDataSet.DiaryLogs);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM DiaryLogs WHERE Username like'"+textBox3.Text+"%'",connection1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach(DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                //dataGridView1.Rows[n].Cells[0].Value = item["Username"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Username"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG FIles (*.jpg)|*jpg|GIF Files(*.gif|*.gif|All Files (*.*)|*.*";
                dlg.Title = "Select Image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName.ToString();
                    pictureBox1.ImageLocation = fileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
