using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace myapp
{
    public partial class consumo : Form
    {
        // Construtor do formulário de consumo
        public consumo()
        {
            InitializeComponent();
            // Ativar otimização de renderização para melhorar o desempenho da interface
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();  // Aplica as mudanças de estilo
        }

        // Evento que é chamado quando o formulário é carregado
        private void consumo_Load(object sender, EventArgs e)
        {
            // Carregar os gráficos assim que o formulário for carregado
            CarregarGraficos();

            // Ajustar a posição dos botões ao carregar o formulário
            AjustarPosicaoBotoes();
        }

        // Método responsável por carregar os gráficos com base nos dados de consumo
        private void CarregarGraficos()
        {
            // Limpar o FlowLayoutPanel, mas sem limpar os botões
            flowPanelGraficos.Controls.Clear();

            // Verificar se o arquivo de dados dos cômodos existe
            if (!File.Exists("comodos.txt"))
            {
                MessageBox.Show("Arquivo comodos.txt não encontrado.");
                return;
            }

            // Ler todos os nomes de cômodos do arquivo "comodos.txt"
            List<string> comodos = File.ReadAllLines("comodos.txt").ToList();

            // Configurações do FlowLayoutPanel para disposição dos gráficos
            flowPanelGraficos.FlowDirection = FlowDirection.LeftToRight;
            flowPanelGraficos.WrapContents = false;
            flowPanelGraficos.AutoScroll = true;

            // Para cada cômodo, criar um gráfico e adicioná-lo ao painel
            foreach (string comodo in comodos)
            {
                // Gerar dados aleatórios para consumo de luz e água
                var dadosLuz = GerarDadosAleatorios();
                var dadosAgua = GerarDadosAleatorios();

                // Criar um novo gráfico para o cômodo
                GraficoComodo grafico = new GraficoComodo();
                grafico.DefinirTitulo(comodo.Trim());  // Definir título com o nome do cômodo
                grafico.DefinirDados(dadosLuz, dadosAgua);  // Definir dados de consumo

                // Adicionar o gráfico ao FlowLayoutPanel
                flowPanelGraficos.Controls.Add(grafico);
            }
        }

        // Método que gera dados aleatórios para consumo de luz e água
        private Dictionary<string, double> GerarDadosAleatorios()
        {
            Dictionary<string, double> dados = new Dictionary<string, double>();
            Random rnd = new Random();

            // Gerar dados para 3 meses de consumo
            for (int i = 1; i <= 3; i++)
            {
                string mes = $"Mês {i}";
                dados[mes] = rnd.Next(50, 300);  // Geração de valores entre 50 e 300 para o consumo
            }

            return dados;
        }

        // Evento de clique no botão "Calcular" para calcular os totais de consumo
        private void btnCaucular_Click(object sender, EventArgs e)
        {
            // Inicializar variáveis para armazenar os totais
            double totalGastoLuz = 0;
            double totalGastoAgua = 0;
            double totalGastoGeral = 0;

            // Evitar calcular mais de uma vez se já tiver calculado
            var controlesGrafico = flowPanelGraficos.Controls.Cast<Control>().Where(c => c is GraficoComodo);

            // Iterar sobre todos os gráficos no FlowLayoutPanel
            foreach (var controle in controlesGrafico)
            {
                if (controle is GraficoComodo grafico)
                {
                    // Obter os consumos do "Mês 3" de Luz e Água
                    double gastoLuz = grafico.ObterConsumoMes3Luz();
                    double gastoAgua = grafico.ObterConsumoMes3Agua();

                    // Somar os gastos aos totais
                    totalGastoLuz += gastoLuz;
                    totalGastoAgua += gastoAgua;
                    totalGastoGeral += gastoLuz + gastoAgua;
                }
            }

            // Criar uma mensagem formatada para exibir os totais de consumo
            string mensagem = "Resumo de Consumo:\n\n";
            mensagem += "Consumo de Luz total:\n";
            mensagem += $"Total Luz: R${totalGastoLuz:F2}\n\n";
            mensagem += "Consumo de Água total:\n";
            mensagem += $"Total Água: R${totalGastoAgua:F2}\n\n";
            mensagem += "Resumo Geral:\n";
            mensagem += $"Total Geral (Luz + Água): R${totalGastoGeral:F2}\n";

            // Exibir a mensagem de resumo em um MessageBox
            MessageBox.Show(mensagem, "Resumo de Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento de clique no botão "Voltar" para retornar ao formulário principal
        private void button2_Click(object sender, EventArgs e)
        {
            main trocar = new main();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            // Limpa o formulário atual e exibe o formulário principal
            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        // Método para ajustar manualmente a posição dos botões na parte inferior do formulário
        private void AjustarPosicaoBotoes()
        {
            // Obter a largura de cada botão
            int larguraBotao2 = button2.Width;
            int larguraBotao3 = button3.Width;
            int larguraBotao4 = button4.Width;

            // Definir o espaçamento entre os botões
            int espacoEntreBotoes = 50;

            // Calcular a largura total ocupada pelos botões e espaçamento
            int totalLarguraBotoes = larguraBotao2 + larguraBotao3 + larguraBotao4 + espacoEntreBotoes * 2;

            // Calcular a posição inicial dos botões para que fiquem centralizados
            int posicaoInicialX = (this.ClientSize.Width - totalLarguraBotoes) / 2;

            // Posicionar os botões no centro da parte inferior do formulário
            button2.Location = new System.Drawing.Point(posicaoInicialX, this.ClientSize.Height - button2.Height + 35);
            button3.Location = new System.Drawing.Point(posicaoInicialX + larguraBotao2 + espacoEntreBotoes, this.ClientSize.Height - button3.Height + 35);
            button4.Location = new System.Drawing.Point(posicaoInicialX + larguraBotao2 + larguraBotao3 + espacoEntreBotoes * 2, this.ClientSize.Height - button4.Height + 35);
        }

        // Evento de clique no botão "Fechar" para sair da aplicação
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Encerra a aplicação
        }

        // Evento de clique no botão "Ranking" para navegar para o formulário de ranking
        private void button4_Click(object sender, EventArgs e)
        {
            ranking trocar = new ranking();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            // Limpa o formulário atual e exibe o formulário de ranking
            this.Controls.Clear();
            this.Controls.Add(trocar);
            trocar.Show();
        }

        // Evento de clique no botão de menu (não implementado)
        private void button_menu_Click(object sender, EventArgs e) { }

        // Evento de clique no pictureBox1 (não implementado)
        private void pictureBox1_Click(object sender, EventArgs e) { }

        // Evento de clique no botão "Calcular" para cálculo de consumos (não implementado)
        private void button3_Click(object sender, EventArgs e) { }
    }
}
