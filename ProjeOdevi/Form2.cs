using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//Manager Login
        {
           
                    if (textBox1.Text==""||textBox2.Text=="")
                    {
                        MessageBox.Show("Please write manager User name and Password");
                    }
                    else
                    {

                        if (textBox1.Text == "admin" && textBox2.Text == "123456")
                        {
                            Form3 frm = new Form3();
                            frm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("User Name And Password incorrect");
                        }

                    }
                    
                
        }
        private void TarihveSaat()
        {
            label3.Text = DateTime.Now.Minute.ToString(); // sadece dakika
            label10.Text = DateTime.Now.Hour.ToString(); // sadece saat

            label7.Text = DateTime.Now.Day.ToString(); // sadece gün
            label6.Text = DateTime.Now.Month.ToString(); // sadece ay
            label5.Text = DateTime.Now.Year.ToString(); // sadece yıl
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TarihveSaat();
        }
    }
}
