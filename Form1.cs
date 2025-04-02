using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace StudentDBApp
{
    public partial class Form1 : Form
    {
        private string connectionString = "server=localhost;database=studentdb;user=root;password=12345";


        public Form1()
        {
            InitializeComponent();
        }

        private void LoadStudentData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM studentdb";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.Columns["studentId"].HeaderText = "Student ID";
                    dataGridView1.Columns["firstName"].HeaderText = "First Name";
                    dataGridView1.Columns["lastName"].HeaderText = "Last Name";
                    dataGridView1.Columns["age"].HeaderText = "Age";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }
    }
}