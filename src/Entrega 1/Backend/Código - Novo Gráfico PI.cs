using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataVisualization
{
    public class MainForm : Form
    {
        private Chart consumptionChart;

        public MainForm()
        {
            InitializeComponent();
            InitializeChart();
            LoadMockData();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dashboard de Consumo - Casa Inteligente";
        }

        private void InitializeChart()
        {
            // Instancia o gráfico e configura layout
            consumptionChart = new Chart();
            consumptionChart.Dock = DockStyle.Fill;

            // Cria a área do gráfico
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Mês";
            chartArea.AxisY.Title = "Consumo";
            consumptionChart.ChartAreas.Add(chartArea);

            // Cria as séries de dados
            Series energySeries = new Series("Energia (kWh)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Orange,
                ChartArea = "MainArea"
            };

            Series waterSeries = new Series("Água (Litros)")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue,
                ChartArea = "MainArea"
            };

            // Adiciona as séries ao gráfico
            consumptionChart.Series.Add(energySeries);
            consumptionChart.Series.Add(waterSeries);

            // Adiciona o gráfico ao formulário
            this.Controls.Add(consumptionChart);
        }

        private void LoadMockData()
        {
            var mockData = new Dictionary<string, (double energia, double agua)>
            {
                { "Jan", (150, 1200) },
                { "Fev", (130, 1100) },
                { "Mar", (160, 1250) },
                { "Abr", (140, 1150) },
                { "Mai", (155, 1180) },
                { "Jun", (165, 1220) },
            };

            foreach (var entry in mockData)
            {
                consumptionChart.Series["Energia (kWh)"].Points.AddXY(entry.Key, entry.Value.energia);
                consumptionChart.Series["Água (Litros)"].Points.AddXY(entry.Key, entry.Value.agua);
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
