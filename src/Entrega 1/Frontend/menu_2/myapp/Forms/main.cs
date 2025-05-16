using System;
using System.Windows.Forms;
using myapp.Controls; // Importa o UserControl "menu"

namespace myapp
{
    public partial class main : Form
    {
        private menu menuControl; // Referência ao UserControl

        public main()
        {
            InitializeComponent();

            // Vincula os eventos de clique aos botões
            comodos.Click += (s, e) => MostrarLabel(label1);
            button2.Click += (s, e) => MostrarLabel(label2);
            button3.Click += (s, e) => MostrarLabel(label3);
        }

        private void MostrarLabel(Label labelParaMostrar)
        {
            // Primeiro, esconde todos os labels
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            // Depois, mostra só o label passado como parâmetro
            labelParaMostrar.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Esconde todos os labels
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;

            // Mostra todos os botões
            comodos.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void main_Load(object sender, EventArgs e)
        {
            // Oculta o panel_menu no início (opcional)
            panel_menu.Visible = false;

            // Inicializa labels como invisíveis, se quiser
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
        }

        private void comodos_Click(object sender, EventArgs e)
        {
            // Mostra os labels
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            // Mostra os botões
            comodos.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void panel_menu_Paint(object sender, PaintEventArgs e)
        {
            // Desnecessário aqui, pode deixar vazio mesmo
        }

        private void button_menu_Click(object sender, EventArgs e)
        {
            // Se o menu ainda não foi criado, cria e adiciona ao painel
            if (menuControl == null)
            {
                menuControl = new menu();
                menuControl.Dock = DockStyle.Fill;
                panel_menu.Controls.Add(menuControl);
            }

            // Mostra o menu
            panel_menu.BringToFront();
            panel_menu.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Vazio, pode implementar depois
        }
    }
}
