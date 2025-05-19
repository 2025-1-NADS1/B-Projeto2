using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using myapp.Controls;

namespace myapp
{
    public partial class main : Form
    {
        private Controls.menu menuControl; // Controles de Menu
        private int contadorComodos = 1; // Contador para os cômodos
        private Dictionary<Button, Form> comodosForms = new Dictionary<Button, Form>(); // Armazena os cômodos e seus formulários associados
        private readonly string comodosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comodos.txt"); // Caminho para salvar os cômodos

        // Construtor principal
        public main()
        {
            InitializeComponent();

            // Definir estilos para renderização do formulário
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            // Configurar o botão de adicionar cômodo
            btnAdicionar.Click -= btnAdicionar_Click;
            btnAdicionar.Click += btnAdicionar_Click;

            btnAdicionar.Text = "";
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.FlatAppearance.BorderSize = 0;
            btnAdicionar.Margin = new Padding(10);
            btnAdicionar.Height = 100;

            // Verificar e carregar a imagem de fundo para o botão de adicionar cômodo
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "button_add_room.png");
            if (File.Exists(imagePath))
            {
                btnAdicionar.BackgroundImage = Image.FromFile(imagePath);
                btnAdicionar.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Imagem button_add_room.png não encontrada no caminho:\n" + imagePath, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Habilitar o duplo buffer no painel para melhor desempenho gráfico
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, flowLayoutPanel1, new object[] { true });
        }

        // Evento de carregamento do formulário principal
        private void main_Load(object sender, EventArgs e)
        {
            panel_menu.Visible = false; // Inicialmente, o menu está oculto

            // Adicionar o botão de adicionar cômodo no painel se ainda não estiver presente
            if (!flowLayoutPanel1.Controls.Contains(btnAdicionar))
                flowLayoutPanel1.Controls.Add(btnAdicionar);

            // Carregar os cômodos do arquivo
            CarregarComodos();
            AjustarLarguraBotoes(); // Ajusta a largura dos botões conforme o tamanho do painel
        }

        // Ajusta a largura dos botões no painel
        private void AjustarLarguraBotoes()
        {
            int margemTotal = 10 * 2 * 3;
            int larguraDisponivel = flowLayoutPanel1.ClientSize.Width - margemTotal;
            int larguraBotao = larguraDisponivel / 3;

            // Ajuste do botão de adicionar cômodo
            btnAdicionar.Width = larguraBotao;

            // Ajusta os botões dos cômodos já criados
            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Button btn && btn != btnAdicionar)
                {
                    btn.Width = larguraBotao;
                    btn.Height = 100;
                    btn.Margin = new Padding(10);
                    EstilizarBotaoComodo(btn); // Reaplica o estilo ao botão do cômodo
                }
            }
        }

        // Evento para adicionar um novo cômodo ao clicar no botão de adicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = $"COMODO {contadorComodos++}"; // Nome do novo cômodo
            CriarBotaoComodo(nome); // Cria o botão para o novo cômodo
            SalvarComodos(); // Salva a lista de cômodos no arquivo
        }

        // Cria um botão para representar um cômodo
        private void CriarBotaoComodo(string nome)
        {
            Button novoComodo = new Button
            {
                Text = nome,
                Height = 100,
                Margin = new Padding(10)
            };

            EstilizarBotaoComodo(novoComodo); // Aplica o estilo ao botão

            // Criação do formulário do cômodo, passando o nome
            comodo comodoForm = new comodo(nome);

            // Define os comportamentos de exclusão do cômodo
            comodoForm.OnDeleteRequested += (string comodoNome) =>
            {
                Button botao = null;
                foreach (var par in comodosForms)
                {
                    if (par.Key.Text == comodoNome)
                    {
                        botao = par.Key;
                        break;
                    }
                }

                if (botao != null)
                {
                    // Remove o botão do cômodo e o formulário
                    comodosForms.Remove(botao);
                    flowLayoutPanel1.Controls.Remove(botao);
                    AjustarLarguraBotoes(); // Reajusta a largura dos botões
                    SalvarComodos(); // Salva a lista de cômodos
                }

                // Volta para a tela principal após a exclusão
                main voltar = new main();
                voltar.TopLevel = false;
                voltar.FormBorderStyle = FormBorderStyle.None;
                voltar.Dock = DockStyle.Fill;

                Form currentForm = Application.OpenForms["comodo"];
                if (currentForm?.Parent != null)
                {
                    Control parent = currentForm.Parent;
                    parent.Controls.Clear();
                    parent.Controls.Add(voltar);
                    voltar.Show();
                }
            };

            // Define o comportamento de renomeação do cômodo
            comodoForm.OnRenameRequested += (string nomeAntigo, string novoNome) =>
            {
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Button btn && btn.Text == nomeAntigo)
                    {
                        btn.Text = novoNome;
                        break;
                    }
                }

                SalvarComodos(); // Salva os cômodos após renomeação
            };

            comodosForms[novoComodo] = comodoForm;

            // Define o comportamento ao clicar no botão do cômodo
            novoComodo.Click += (s, ev) =>
            {
                this.Controls.Clear();

                comodoForm.TopLevel = false;
                comodoForm.FormBorderStyle = FormBorderStyle.None;
                comodoForm.Dock = DockStyle.Fill;

                this.Controls.Add(comodoForm);
                comodoForm.Show();
            };

            // Atualiza o painel para incluir o novo botão de cômodo
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Remove(btnAdicionar);
            flowLayoutPanel1.Controls.Add(novoComodo);
            flowLayoutPanel1.Controls.Add(btnAdicionar);
            AjustarLarguraBotoes();
            flowLayoutPanel1.ResumeLayout();
        }

        // Salva os nomes dos cômodos no arquivo
        private void SalvarComodos()
        {
            try
            {
                List<string> nomes = new List<string>();
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Button btn && btn != btnAdicionar)
                        nomes.Add(btn.Text); // Adiciona o nome do cômodo à lista
                }
                File.WriteAllLines(comodosPath, nomes); // Salva os nomes no arquivo
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar cômodos: " + ex.Message); // Exibe mensagem de erro
            }
        }

        // Carrega os cômodos do arquivo e os exibe
        private void CarregarComodos()
        {
            try
            {
                if (File.Exists(comodosPath))
                {
                    string[] nomes = File.ReadAllLines(comodosPath);
                    foreach (string nome in nomes)
                    {
                        CriarBotaoComodo(nome);

                        if (nome.StartsWith("COMODO"))
                        {
                            if (int.TryParse(nome.Replace("COMODO", "").Trim(), out int numero))
                            {
                                contadorComodos = Math.Max(contadorComodos, numero + 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cômodos: " + ex.Message); // Exibe mensagem de erro
            }
        }

        // Aplica estilo visual ao botão de cômodo
        private void EstilizarBotaoComodo(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.BackColor = Color.FromArgb(255, 60, 60);
            botao.ForeColor = Color.White;
            botao.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            botao.TextAlign = ContentAlignment.MiddleCenter;
            botao.Cursor = Cursors.Hand;
            botao.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, botao.Width, botao.Height, 30, 30)); // Cantos arredondados
        }

        // Função para criar bordas arredondadas
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        // Outros eventos de controle do formulário
        private void button_menu_Click_1(object sender, EventArgs e)
        {
            if (menuControl == null)
            {
                // Instancia e exibe o menu
                menuControl = new Controls.menu() { Dock = DockStyle.Fill };
                panel_menu.Controls.Add(menuControl);
            }
            else
            {
                // Remove e destrói o menu existente
                panel_menu.Controls.Remove(menuControl);
                menuControl.Dispose();
                menuControl = null;
            }

            // Alterna a visibilidade do menu
            panel_menu.Visible = !panel_menu.Visible;
        }

        // Outros eventos de controle de navegação
        private void button1_Click_1(object sender, EventArgs e) { Application.Exit(); }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            consumo trocar = new consumo();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ranking trocar = new ranking();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        // Eventos de pintura e outros controles
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel_menu_Paint(object sender, PaintEventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
