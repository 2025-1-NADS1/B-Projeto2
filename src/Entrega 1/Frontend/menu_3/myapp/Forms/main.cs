using System;
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

        public main()
        {
            InitializeComponent();

            // Remove o event handler caso já exista para evitar duplicidade
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
        }

        private void main_Load(object sender, EventArgs e)
        {
            panel_menu.Visible = false;

            if (!flowLayoutPanel1.Controls.Contains(btnAdicionar))
            {
                flowLayoutPanel1.Controls.Add(btnAdicionar);
            }

            AjustarLarguraBotoes();
        }

        private void AjustarLarguraBotoes()
        {
            int margemTotal = 10 * 2 * 3; // margem 10px esquerda e direita para 3 botões
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
            Button novoComodo = new Button();
            novoComodo.Text = $"COMODO {contadorComodos++}";
            novoComodo.Height = 100;
            novoComodo.Margin = new Padding(10);
            novoComodo.BackColor = Color.FromArgb(255, 50, 50);
            novoComodo.ForeColor = Color.White;
            novoComodo.FlatStyle = FlatStyle.Flat;
            novoComodo.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            flowLayoutPanel1.Controls.Remove(btnAdicionar);
            flowLayoutPanel1.Controls.Add(novoComodo);
            flowLayoutPanel1.Controls.Add(btnAdicionar);

            AjustarLarguraBotoes();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void panel_menu_Paint(object sender, PaintEventArgs e) { }

        private void button_menu_Click_1(object sender, EventArgs e)
        {
            if (menuControl == null)
            {
                menuControl = new menu();
                menuControl.Dock = DockStyle.Fill;
                panel_menu.Controls.Add(menuControl);
            }
            else
            {
                panel_menu.Controls.Remove(menuControl);
                menuControl.Dispose();
                menuControl = null;
            }

            panel_menu.Visible = !panel_menu.Visible;
            this.Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
    }
}
