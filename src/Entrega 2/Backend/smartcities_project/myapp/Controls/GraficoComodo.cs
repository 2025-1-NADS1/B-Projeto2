using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace myapp
{
    public partial class GraficoComodo : UserControl
    {
        public Dictionary<string, double> DadosLuz { get; private set; }
        public Dictionary<string, double> DadosAgua { get; private set; }

        public GraficoComodo()
        {
            InitializeComponent();
            SetupGraficos();

            // Ativar DoubleBuffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        public void DefinirTitulo(string titulo)
        {
            lblTitulo.Text = titulo;
        }

        public void DefinirDados(Dictionary<string, double> dadosLuz, Dictionary<string, double> dadosAgua)
        {
            DadosLuz = dadosLuz;
            DadosAgua = dadosAgua;

            // Gráfico geral
            AdicionarGraficoGeral(dadosLuz, dadosAgua);

            // Gráficos separados
            PreencherGrafico(chartLuz, "Consumo de Luz", dadosLuz, System.Drawing.ColorTranslator.FromHtml("#FFF2A1"));  // Amarelo pastel
            PreencherGrafico(chartAgua, "Consumo de Água", dadosAgua, System.Drawing.ColorTranslator.FromHtml("#A8D8FF"));  // Azul pastel
        }

        private void SetupGraficos()
        {
            SetupGrafico(chartLuz);
            SetupGrafico(chartAgua);
        }

        private void SetupGrafico(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            ChartArea area = new ChartArea("MainArea");

            // Estética
            chart.BackColor = System.Drawing.Color.Transparent;
            area.BackColor = System.Drawing.Color.Transparent;
            area.AxisX.LineColor = System.Drawing.Color.White;
            area.AxisY.LineColor = System.Drawing.Color.White;
            area.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            area.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;

            // Grade
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;

            // Eixos
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            // Remover título redundante
            area.AxisX.Title = "";

            // Unidades
            if (chart.Name.Contains("Luz"))
                area.AxisY.LabelStyle.Format = "{0}W";
            else if (chart.Name.Contains("Agua"))
                area.AxisY.LabelStyle.Format = "{0}L";

            chart.ChartAreas.Add(area);
        }

        private void PreencherGrafico(Chart chart, string titulo, Dictionary<string, double> dados, System.Drawing.Color corLinha)
        {
            Series serie = new Series
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = corLinha
            };

            foreach (var item in dados)
                serie.Points.AddXY(item.Key, item.Value);

            chart.Series.Clear();
            chart.Series.Add(serie);
            chart.Titles.Clear();
            chart.Titles.Add(titulo);
            chart.Titles[0].ForeColor = System.Drawing.Color.White;
            chart.Titles[0].Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
        }

        // Método para obter as estatísticas (mas não exibi-las)
        public (double media, double minimo, double maximo) ObterEstatisticas(Dictionary<string, double> dados)
        {
            double media = dados.Values.Average();
            double minimo = dados.Values.Min();
            double maximo = dados.Values.Max();

            return (media, minimo, maximo);
        }

        private void AdicionarGraficoGeral(Dictionary<string, double> dadosLuz, Dictionary<string, double> dadosAgua)
        {
            Dictionary<string, double> dadosGeral = new Dictionary<string, double>();

            foreach (var mes in dadosLuz.Keys)
            {
                double total = dadosLuz[mes] + (dadosAgua.ContainsKey(mes) ? dadosAgua[mes] : 0);
                dadosGeral[mes] = total;
            }

            // Pode usar chartLuz ou chartAgua para exibir o gráfico geral também, se quiser
            // Aqui só armazenamos se precisar exibir fora
        }

        // Métodos para obter os consumos do Mês 3
        public double ObterConsumoMes3Luz()
        {
            return DadosLuz.ContainsKey("Mês 3") ? DadosLuz["Mês 3"] : 0;
        }

        public double ObterConsumoMes3Agua()
        {
            return DadosAgua.ContainsKey("Mês 3") ? DadosAgua["Mês 3"] : 0;
        }

        // Evento opcional - Clique no gráfico de água
        private void chartAgua_Click(object sender, EventArgs e)
        {
            // Evento opcional - pode ser removido se não for necessário
        }
    }
}
