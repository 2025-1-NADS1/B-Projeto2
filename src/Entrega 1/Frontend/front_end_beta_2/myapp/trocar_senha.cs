using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myapp
{
    public partial class trocar_senha : Form
    {
        public trocar_senha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Substitua pelos dados reais
            SendEMail("victorcamargo0130@gmail.com", "tmkdtlywxoldvezw", "victorcamargo0302@gmail.com", "Recuperação de senha", "Olá,\nIsso é um Email de teste!");
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

        private void trocar_senha_Load(object sender, EventArgs e)
        {

        }
    }
}
