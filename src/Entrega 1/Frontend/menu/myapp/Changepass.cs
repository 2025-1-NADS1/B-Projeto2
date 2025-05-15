using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myapp
{
    public partial class Changepass : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Changepass()
        {
            InitializeComponent();
            panel1.MouseDown += Panel1_MouseDown;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Substitua pelos seus dados
            SendEMail(
                "victorcamargo0130@gmail.com",

                "tmkdtlywxoldvezw",

                "victorcamargo0302@gmail.com",

                "Recuperação de senha",

                "Olá,\nIsso é um Email de teste!"
            );
        }

        public static void SendEMail(string YourEmail, string EmailPassword, string ReceiverEmail, string EmailSubject, string EmailText)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(YourEmail, EmailPassword);

                MailMessage message = new MailMessage();
                message.To.Add(ReceiverEmail);
                message.From = new MailAddress(YourEmail);
                message.Subject = EmailSubject;
                message.Body = EmailText;

                smtpClient.Send(message);
                MessageBox.Show("Email Enviado");
            }
            catch (SmtpException smtpEx)
            {
                MessageBox.Show("Erro SMTP: " + smtpEx.Message + "\nDetalhes: " + smtpEx.InnerException?.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro geral: " + ex.Message);
            }
        }

        private void Changepass_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Changepass_Load_1(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha completamente o aplicativo
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Login trocar = new Login();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear(); // Limpa a tela de recuperação de senha
            this.Controls.Add(trocar);
            trocar.Show();
        }
    }
}
