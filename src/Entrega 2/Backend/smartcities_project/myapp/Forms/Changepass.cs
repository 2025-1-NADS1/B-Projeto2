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
        // Constantes para movimentar a janela ao arrastar o painel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        // Importação de funções da API do Windows para arrastar o formulário sem borda
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Changepass()
        {
            InitializeComponent();

            // Evento para permitir que o painel mova a janela
            panel1.MouseDown += Panel1_MouseDown;
        }

        // Lógica para mover a janela ao clicar e arrastar no painel superior
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // Evento de clique no botão para envio do e-mail
        private void button1_Click(object sender, EventArgs e)
        {
            SendEMail(
                "victorcamargo0130@gmail.com",            // E-mail remetente
                "tmkdtlywxoldvezw",                        // Senha ou AppPassword do remetente
                "victorcamargo0302@gmail.com",            // E-mail destinatário
                "Recuperação de senha",                   // Assunto do e-mail
                "Olá,\nIsso é um Email de teste!"         // Corpo do e-mail
            );
        }

        // Método para envio de e-mail usando SMTP com autenticação
        public static void SendEMail(string YourEmail, string EmailPassword, string ReceiverEmail, string EmailSubject, string EmailText)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(YourEmail, EmailPassword)
                };

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(YourEmail),
                    Subject = EmailSubject,
                    Body = EmailText
                };
                message.To.Add(ReceiverEmail);

                smtpClient.Send(message);

                MessageBox.Show("Email Enviado");
            }
            catch (SmtpException smtpEx)
            {
                // Captura erros específicos do SMTP
                MessageBox.Show("Erro SMTP: " + smtpEx.Message + "\nDetalhes: " + smtpEx.InnerException?.Message);
            }
            catch (Exception ex)
            {
                // Captura outros erros
                MessageBox.Show("Erro geral: " + ex.Message);
            }
        }

        // Eventos de carregamento do formulário (podem ser utilizados para inicializações)
        private void Changepass_Load(object sender, EventArgs e) { }

        private void Changepass_Load_1(object sender, EventArgs e) { }

        // Eventos de clique em componentes visuais (sem lógica implementada ainda)
        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void pictureBox3_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void button2_Click_1(object sender, EventArgs e) { }

        private void Button3_Click(object sender, EventArgs e) { }

        private void pictureBox8_Click(object sender, EventArgs e) { }

        // Fecha completamente a aplicação
        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimiza a janela atual
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Evento de pintura do painel (sem lógica atualmente)
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        // Alterna da tela de recuperação de senha para a tela de login
        private void button4_Click_1(object sender, EventArgs e)
        {
            Login trocar = new Login
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }
    }
}
