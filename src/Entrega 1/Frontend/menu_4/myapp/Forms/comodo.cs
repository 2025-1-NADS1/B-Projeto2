using System;
using System.Drawing;
using System.Windows.Forms;

namespace myapp
{
    public partial class comodo : Form
    {
        public event Action<string> OnDeleteRequested; // Evento para notificar a main
        private string nomeComodo;

        public comodo(string nome)
        {
            InitializeComponent();
            this.nomeComodo = nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }

            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Dispara o evento para o main saber que este form foi deletado
            OnDeleteRequested?.Invoke(nomeComodo);

            if (this.Parent != null)
            {
                // Remove este form
                this.Parent.Controls.Remove(this);

                // Adiciona o form principal (main)
                main trocar = new main();
                trocar.TopLevel = false;
                trocar.FormBorderStyle = FormBorderStyle.None;
                trocar.Dock = DockStyle.Fill;

                this.Parent.Controls.Add(trocar);
                trocar.Show();
            }

            this.Dispose();
        }

        private void comodo_Load(object sender, EventArgs e)
        {
            // Pode deixar vazio
        }
    }
}
