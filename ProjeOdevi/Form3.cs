using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjeOdevi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EFPC7M7\\SQLEXPRESS01;Initial Catalog=Savedİnformation;Integrated Security=True");
        DataSet dtst = new DataSet();
        SqlDataAdapter adtr = new SqlDataAdapter();
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void grid()
        {
            con.Open();
            dataGridView1.Columns.Clear();
            dtst.Tables.Clear();
            dataGridView1.Refresh();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From Student", con);
            adtr.Fill(dtst, "Student");
            dataGridView1.DataSource = dtst.Tables["Student"];
            adtr.Dispose();
            con.Close();
        }
        private void Form3_Load(object sender, EventArgs e)//Tablo gosterme
        {
            grid();
            Clear();
            TarihveSaat();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//m
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)//Add
        {
            if (textBox1.Text=="" || textBox2.Text == ""|| textBox3.Text == "")
            {        
                  MessageBox.Show("Fill in the blanks");
            }
            else       
            {
                string sorgu = "SELECT * FROM Student where No=@No";//varmi?
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@No", textBox3.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Student no available");
                    dr.Close();
                }
                else
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                        con.Open();
                        string kayit = "insert into Student(Name,Surname,No,Operation,Date) values (@Name,@Surname,@No,@Operation,@Date)";
                        SqlCommand komut = new SqlCommand(kayit, con);
                        komut.Parameters.AddWithValue("@Name", textBox1.Text);
                        komut.Parameters.AddWithValue("@Surname", textBox2.Text);
                        komut.Parameters.AddWithValue("@No", textBox3.Text);
                        komut.Parameters.AddWithValue("@Operation", "");
                        komut.Parameters.AddWithValue("@Date", "");
                        komut.ExecuteNonQuery();
                        con.Close();
                        grid();
                        Clear();
                        MessageBox.Show("Sucsesfull");
                }
            }               
        }
        private void button2_Click(object sender, EventArgs e)//delete
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter student no");
            }
            else
            {
                string sorgu = "SELECT * FROM Student where No=@No";//varmi?
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@No", textBox3.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())//SİLME KODLARI
                {
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                    con.Open();
                    SqlCommand delete = new SqlCommand
                    ("DELETE FROM Student WHERE [No]=@No", con);
                    delete.Parameters.AddWithValue("@No", textBox3.Text);
                    delete.ExecuteNonQuery();
                    con.Close();
                    Clear();
                    grid();
                }
                else
                {
                    MessageBox.Show("Student not found");
                }
            }
        }
        private void button3_Click_1(object sender, EventArgs e)//update
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) 
            {
                string sql = "update Student set Name = '" + textBox1.Text + "',Surname = '" + textBox2.Text + "', No = '" + textBox3.Text + "' where No = '" + textBox3.Text + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);

                if (con.State != ConnectionState.Open) 
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                con.Close();
                grid();
                Clear();
            }
            else
            {
                MessageBox.Show("Fill in the blanks");
            }
        }      
        private void button4_Click(object sender, EventArgs e)
        {
            string aranan = textBox4.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
        private void TarihveSaat()
        {
            label11.Text = DateTime.Now.Minute.ToString(); // sadece dakika
            label13.Text = DateTime.Now.Hour.ToString(); // sadece saat

            label7.Text = DateTime.Now.Day.ToString(); // sadece gün
            label6.Text = DateTime.Now.Month.ToString(); // sadece ay
            label10.Text = DateTime.Now.Year.ToString(); // sadece yıl

        }
    }
}
