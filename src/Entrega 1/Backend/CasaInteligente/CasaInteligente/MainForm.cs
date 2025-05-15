using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasaInteligente
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuartoForm quarto = new QuartoForm();
            quarto.Show();
            this.Hide(); // Esconde o MainForm
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SalaForm sala = new SalaForm();
            sala.Show();
            this.Hide(); // Esconde o MainForm
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BanheiroForm banheiro = new BanheiroForm();
            banheiro.Show();
            this.Hide(); // Esconde o MainForm

        }

        private void button4_Click(object sender, EventArgs e)
        {

            CozinhaForm cozinha = new CozinhaForm();
            cozinha.Show();
            this.Hide(); // Esconde o MainForm
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Fecha o aplicativo

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ComodosForm comodos = new ComodosForm();
            comodos.Show();
            this.Hide(); // Esconde o MainForm
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConsumoForm consumo = new ConsumoForm();
            consumo.Show();
            this.Hide(); // Esconde o MainForm
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RankingForm ranking = new RankingForm();
            ranking.Show();
            this.Hide(); // Esconde o MainForm
        }
    }
}
