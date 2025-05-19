using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace myapp
{
    public partial class Login : Form
    {
        // Variável para controlar se a senha é visível ou não
        private bool senhaVisivel = false;

        // Constantes para manipulação da janela (drag)
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        // Importação de funções para manipulação da janela
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Função para criar bordas arredondadas no formulário
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // Construtor do formulário de Login
        public Login()
        {
            InitializeComponent();

            // Permitir o "arraste" do formulário pela área do painel superior (panel1)
            panel1.MouseDown += Panel1_MouseDown;

            // Remover a borda padrão do formulário e aplicar bordas arredondadas
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 20, 20)  // Definir o raio para arredondar as bordas
            );
        }

        // Evento para permitir o arraste do formulário ao clicar e arrastar o painel superior
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Libera a captura do mouse e envia a mensagem para a janela para permitir o arraste
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // Evento de clique no botão de login (sem implementação no momento)
        private void button1_Click_1(object sender, EventArgs e)
        {
            // Código para login será implementado aqui
        }

        // Evento de clique no botão de mostrar/ocultar senha
        private void button4_Click(object sender, EventArgs e)
        {
            // Alternar o estado de visibilidade da senha
            senhaVisivel = !senhaVisivel;
            // Mostrar ou ocultar a senha no campo de texto dependendo do estado
            textBox2.UseSystemPasswordChar = !senhaVisivel;
        }

        // Evento de clique no botão para fechar a aplicação
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Encerra a aplicação
        }

        // Evento de clique no botão para minimizar a janela
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  // Minimiza a janela
        }

        // Evento de clique no botão para ir para a tela de registro
        private void button5_Click_1(object sender, EventArgs e)
        {
            // Abre o formulário de registro
            registro formRegistro = new registro();
            formRegistro.TopLevel = false;
            formRegistro.FormBorderStyle = FormBorderStyle.None;
            formRegistro.Dock = DockStyle.Fill;

            // Substitui o conteúdo atual pela tela de registro
            this.Controls.Clear();
            this.Controls.Add(formRegistro);
            formRegistro.Show();
        }

        // Evento de clique no botão para ir para a tela de alteração de senha
        private void button6_Click(object sender, EventArgs e)
        {
            // Abre o formulário de alteração de senha
            Changepass trocar = new Changepass();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            // Substitui o conteúdo atual pela tela de alteração de senha
            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        // Evento de clique no botão de login (com validação de credenciais)
        private void registrar_Click(object sender, EventArgs e)
        {
            // Recuperar as informações digitadas nos campos de e-mail e senha
            string email = textBox1.Text.Trim();
            string senha = textBox2.Text.Trim();

            // Verificar se os campos não estão vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            string caminhoArquivo = "usuarios.txt";  // Caminho do arquivo que armazena os usuários cadastrados

            // Verificar se o arquivo de usuários existe
            if (!File.Exists(caminhoArquivo))
            {
                MessageBox.Show("Arquivo de usuários não encontrado.");
                return;
            }

            // Ler todas as linhas do arquivo
            string[] linhas = File.ReadAllLines(caminhoArquivo);
            bool credenciaisValidas = false;

            // Verificar se as credenciais fornecidas estão corretas
            foreach (string linha in linhas)
            {
                var partes = linha.Split(' ');
                if (partes.Length >= 3 && partes[1] == email && partes[2] == senha)
                {
                    credenciaisValidas = true;
                    break;
                }
            }

            // Se as credenciais forem válidas, exibir a tela principal
            if (credenciaisValidas)
            {
                main telaPrincipal = new main();
                telaPrincipal.Show();
                this.Hide();  // Esconder o formulário de login
                telaPrincipal.FormClosed += (s, args) => this.Close();  // Fechar a aplicação quando a tela principal for fechada
            }
            else
            {
                // Se as credenciais forem inválidas, mostrar mensagem de erro e limpar os campos
                MessageBox.Show("Email ou senha incorretos.");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        // Evento que é chamado quando o formulário de login é carregado (sem implementação no momento)
        private void Login_Load(object sender, EventArgs e) { }
    }
}
