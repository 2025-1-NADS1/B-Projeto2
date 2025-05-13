using System;
using System.Windows.Forms;

namespace myapp
{
    public partial class main : Form
    {
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
            // Esconde todos os labels
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

            // Esconde todos os botões
            comodos.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

            // Mostra o label vinculado
            labelParaMostrar.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
