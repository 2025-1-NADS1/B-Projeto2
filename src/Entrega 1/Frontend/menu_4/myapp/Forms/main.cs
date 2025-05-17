using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using myapp.Controls;

namespace myapp
{
    public partial class main : Form
    {
        private menu menuControl;
        private int contadorComodos = 1;
        private Dictionary<Button, Form> comodosForms = new Dictionary<Button, Form>();
        private readonly string comodosPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comodos.txt");

        public main()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            btnAdicionar.Click -= btnAdicionar_Click;
            btnAdicionar.Click += btnAdicionar_Click;

            btnAdicionar.Text = "";
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.FlatAppearance.BorderSize = 0;
            btnAdicionar.Margin = new Padding(10);
            btnAdicionar.Height = 100;

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

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, flowLayoutPanel1, new object[] { true });
        }

        private void main_Load(object sender, EventArgs e)
        {
            panel_menu.Visible = false;

            if (!flowLayoutPanel1.Controls.Contains(btnAdicionar))
                flowLayoutPanel1.Controls.Add(btnAdicionar);

            CarregarComodos();
            AjustarLarguraBotoes();
        }

        private void AjustarLarguraBotoes()
        {
            int margemTotal = 10 * 2 * 3;
            int larguraDisponivel = flowLayoutPanel1.ClientSize.Width - margemTotal;
            int larguraBotao = larguraDisponivel / 3;

            btnAdicionar.Width = larguraBotao;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is Button btn && btn != btnAdicionar)
                {
                    btn.Width = larguraBotao;
                    btn.Height = 100;
                    btn.Margin = new Padding(10);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = $"COMODO {contadorComodos++}";
            CriarBotaoComodo(nome);
            SalvarComodos();
        }

        private void CriarBotaoComodo(string nome)
        {
            Button novoComodo = new Button
            {
                Text = nome,
                Height = 100,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(255, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };

            comodo comodoForm = new comodo(nome);
            comodoForm.OnDeleteRequested += (string comodoNome) =>
            {
                // Encontrar e remover o botão correspondente
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
                    comodosForms.Remove(botao);
                    flowLayoutPanel1.Controls.Remove(botao);
                    AjustarLarguraBotoes();
                    SalvarComodos();
                }

                // Voltar para a tela principal
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

            comodosForms[novoComodo] = comodoForm;

            novoComodo.Click += (s, ev) =>
            {
                this.Controls.Clear();

                comodoForm.TopLevel = false;
                comodoForm.FormBorderStyle = FormBorderStyle.None;
                comodoForm.Dock = DockStyle.Fill;

                this.Controls.Add(comodoForm);
                comodoForm.Show();
            };

            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Remove(btnAdicionar);
            flowLayoutPanel1.Controls.Add(novoComodo);
            flowLayoutPanel1.Controls.Add(btnAdicionar);
            AjustarLarguraBotoes();
            flowLayoutPanel1.ResumeLayout();
        }

        private void SalvarComodos()
        {
            try
            {
                List<string> nomes = new List<string>();
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is Button btn && btn != btnAdicionar)
                        nomes.Add(btn.Text);
                }
                File.WriteAllLines(comodosPath, nomes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar cômodos: " + ex.Message);
            }
        }

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
                MessageBox.Show("Erro ao carregar cômodos: " + ex.Message);
            }
        }

        private void button_menu_Click_1(object sender, EventArgs e)
        {
            if (menuControl == null)
            {
                menuControl = new menu
                {
                    Dock = DockStyle.Fill
                };
                panel_menu.Controls.Add(menuControl);
            }
            else
            {
                panel_menu.Controls.Remove(menuControl);
                menuControl.Dispose();
                menuControl = null;
            }

            panel_menu.Visible = !panel_menu.Visible;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel_menu_Paint(object sender, PaintEventArgs e) { }

        private void label5_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void pictureBox3_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
