using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace myapp
{
    public partial class registro : Form
    {
        private string caminhoArquivo = "usuarios.txt"; // Arquivo local

        public registro()
        {
            InitializeComponent();

            // Garante que o arquivo exista
            if (!File.Exists(caminhoArquivo))
            {
                File.Create(caminhoArquivo).Close();
            }
        }

        private void registro_Load(object sender, EventArgs e)
        {
            // Pode deixar vazio
        }

        private void voltar_Click(object sender, EventArgs e)
        {
            Login trocar = new Login();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        private void email_TextChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio
        }

        private void senha_TextChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio
        }

        private void registrar_Click(object sender, EventArgs e)
        {

        }

        private void registrar_Click_1(object sender, EventArgs e)
        {
            string emailInserido = email.Text.Trim();
            string senhaInserida = senha.Text.Trim();

            if (string.IsNullOrEmpty(emailInserido) || string.IsNullOrEmpty(senhaInserida))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            string[] linhas = File.ReadAllLines(caminhoArquivo);
            bool emailExiste = linhas.Any(l =>
            {
                var partes = l.Split(' ');
                return partes.Length >= 3 && partes[1] == emailInserido;
            });

            if (emailExiste)
            {
                MessageBox.Show("Este email já está cadastrado!");
                return;
            }

            int novoId = linhas.Length + 1;
            string novaConta = $"{novoId} {emailInserido} {senhaInserida}";
            File.AppendAllText(caminhoArquivo, novaConta + Environment.NewLine);

            MessageBox.Show("Conta criada com sucesso!");

            // Abre o form Login
            Login trocar = new Login();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void voltar_Click_1(object sender, EventArgs e)
        {
            Login trocar = new Login();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }
    }
}
