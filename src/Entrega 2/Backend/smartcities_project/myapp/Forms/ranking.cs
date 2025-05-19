using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace myapp
{
    public partial class ranking : Form
    {
        public ranking()
        {
            InitializeComponent();
        }

        private void ranking_Load(object sender, EventArgs e)
        {
            // Carrega os e-mails do arquivo
            List<string> emails = CarregarEmails("usuarios.txt");

            // Inicializa o gráfico
            ConfigurarGrafico(emails);
        }

        private List<string> CarregarEmails(string caminho)
        {
            List<string> emails = new List<string>();

            try
            {
                if (File.Exists(caminho))
                {
                    string[] linhas = File.ReadAllLines(caminho);

                    foreach (string linha in linhas)
                    {
                        var partes = linha.Split(' ');
                        if (partes.Length >= 2)
                        {
                            emails.Add(partes[1]); // Segundo campo é o e-mail
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Arquivo usuarios.txt não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao ler o arquivo: " + ex.Message);
            }

            return emails;
        }

        private void ConfigurarGrafico(List<string> emails)
        {
            // Exemplo de como configurar o gráfico com os dados de e-mails
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;
            this.Controls.Add(chart);

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            Series series = new Series("E-mails");
            series.Points.DataBindY(emails);
            chart.Series.Add(series);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void AjustarPosicaoBotoes()
        {
            int larguraBotao2 = button2.Width;
            int larguraBotao3 = button3.Width;
            int larguraBotao4 = button4.Width;

            // Aumente o valor do espaçamento entre os botões. Alterei para 50.
            int espacoEntreBotoes = 50;  // Definir o espaçamento entre os botões

            // Calcular o total de largura dos botões e o espaçamento entre eles
            int totalLarguraBotoes = larguraBotao2 + larguraBotao3 + larguraBotao4 + espacoEntreBotoes * 2; // *2 porque teremos dois espaçamentos (dois intervalos)

            int posicaoInicialX = (this.ClientSize.Width - totalLarguraBotoes) / 2;

            // Posicionar os botões no centro inferior com o espaçamento aumentado de forma igual
            button2.Location = new System.Drawing.Point(posicaoInicialX, this.ClientSize.Height - button2.Height + 65); // Posição fixa para o botão 2
            button3.Location = new System.Drawing.Point(posicaoInicialX + larguraBotao2 + espacoEntreBotoes, this.ClientSize.Height - button3.Height + 65); // Posição fixa para o botão 3
            button4.Location = new System.Drawing.Point(posicaoInicialX + larguraBotao2 + larguraBotao3 + espacoEntreBotoes * 2, this.ClientSize.Height - button4.Height + 65); // Posição fixa para o botão 4
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main trocar = new main();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // Método para estilizar botões
        private void EstilizarBotao(Button botao)
        {
            botao.FlatStyle = FlatStyle.Flat;
            botao.FlatAppearance.BorderSize = 0;
            botao.BackColor = Color.FromArgb(255, 60, 60);
            botao.ForeColor = Color.White;
            botao.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            botao.TextAlign = ContentAlignment.MiddleCenter;
            botao.Cursor = Cursors.Hand;
            botao.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, botao.Width, botao.Height, 30, 30));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
    }
}
