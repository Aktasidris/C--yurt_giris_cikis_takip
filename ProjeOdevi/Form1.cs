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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EFPC7M7\\SQLEXPRESS01;Initial Catalog=Savedİnformation;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)//Entery
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your Student Number.");
            }
            else
            {
                string sorgu = "SELECT * FROM Student where No=@No";//varmi?
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@No", textBox1.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    string kayit = "update Student set Operation = '" + button1.Text + "',Date= '" + DateTime.Now + "' where No = '" + textBox1.Text + "'";
                    SqlCommand komut = new SqlCommand(kayit, con);
                    komut.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sucsesfull");
                }
                else
                {
                    MessageBox.Show("Student not found");
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)//Exit
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your Student Number.");
            }
            else
            {
                string sorgu = "SELECT * FROM Student where No=@No";//varmi?
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@No", textBox1.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    string kayit = "update Student set Operation = '" + button2.Text + "',Date= '" + DateTime.Now + "' where No = '" + textBox1.Text + "'"; 
                    SqlCommand komut = new SqlCommand(kayit, con);
                    komut.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Sucsesfull");
                }
                else
                {
                    MessageBox.Show("Student not found");
                }
                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TarihveSaat();
        }
        private void TarihveSaat()
        {
            label3.Text = DateTime.Now.Minute.ToString(); // sadece dakika
            label2.Text = DateTime.Now.Hour.ToString(); // sadece saat

            label7.Text = DateTime.Now.Day.ToString(); // sadece gün
            label6.Text = DateTime.Now.Month.ToString(); // sadece ay
            label5.Text = DateTime.Now.Year.ToString(); // sadece yıl
        }
    }
}
