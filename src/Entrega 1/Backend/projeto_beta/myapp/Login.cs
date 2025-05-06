using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myapp
{
    public partial class Login : Form
    {
        private bool resizingInternally = false;

        public Login()
        {
            InitializeComponent();

            this.ResizeBegin += Login_ResizeBegin;
            this.ResizeEnd += Login_ResizeEnd;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Login_ResizeBegin(object sender, EventArgs e)
        {
            resizingInternally = true;
        }

        private void Login_ResizeEnd(object sender, EventArgs e)
        {
            resizingInternally = false;

            int newWidth = this.Width;
            int newHeight = (int)(newWidth * 9.0 / 16.0);

            this.Size = new Size(newWidth, newHeight);
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String Email = textBox1.Text;
            String Senha = textBox2.Text;

            if (Email == "usuario@gmail.com" && Senha == "senha123")
            {
                new index().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário não encontrado");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void pictureBox3_Click(object sender, EventArgs e) { }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
