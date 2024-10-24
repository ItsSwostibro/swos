using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace sss_form
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("data source=DESKTOP-VAR2TVJ;Initial catalog=studentrecords;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd = new SqlCommand("INSERT INTO student (UserName, UserAddress, UserPhone) VALUES (@UserName, @UserAddress, @UserPhone)", conn);
            cmd.Parameters.AddWithValue("@UserName", txtName.Text);
            cmd.Parameters.AddWithValue("@UserAddress", txtAddress.Text);
            cmd.Parameters.AddWithValue("@UserPhone", txtPhone.Text);
            cmd.ExecuteNonQuery();
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            LoadData();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd = new SqlCommand("DELETE FROM student WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", txtId.Text);
            cmd.ExecuteNonQuery();
            LoadData();
            conn.Close();
        }

        private void LoadData()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd = new SqlCommand("SELECT * FROM student", conn);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
