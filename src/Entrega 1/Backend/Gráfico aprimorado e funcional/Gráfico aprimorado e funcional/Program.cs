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
        private Button updateButton;

        private Dictionary<string, (double energia, double agua)> currentData = new Dictionary<string, (double energia, double agua)>();
        private Dictionary<string, (double energia, double agua)> previousData = new Dictionary<string, (double energia, double agua)>();

        public MainForm()
        {
            InitializeComponent();
            InitializeChart();
            LoadMockData();
            InitializeUpdateButton();
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(800, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Dashboard de Consumo - Casa Inteligente";
        }

        private void InitializeChart()
        {
            consumptionChart = new Chart();
            consumptionChart.Dock = DockStyle.Top;
            consumptionChart.Height = 450;

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Mês";
            chartArea.AxisY.Title = "Consumo";
            consumptionChart.ChartAreas.Add(chartArea);

            Series energySeries = new Series("Energia (kWh)");
            energySeries.ChartType = SeriesChartType.Column;
            energySeries.Color = Color.Orange;
            energySeries.ChartArea = "MainArea";

            Series waterSeries = new Series("Água (Litros)");
            waterSeries.ChartType = SeriesChartType.Column;
            waterSeries.Color = Color.Blue;
            waterSeries.ChartArea = "MainArea";

            consumptionChart.Series.Add(energySeries);
            consumptionChart.Series.Add(waterSeries);

            this.Controls.Add(consumptionChart);
        }

        private void InitializeUpdateButton()
        {
            updateButton = new Button();
            updateButton.Text = "Atualizar Dados";
            updateButton.Dock = DockStyle.Bottom;
            updateButton.Height = 40;
            updateButton.Click += UpdateButton_Click;
            this.Controls.Add(updateButton);
        }

        private void LoadMockData()
        {
            currentData = new Dictionary<string, (double energia, double agua)>
            {
                { "Jan", (150, 1200) },
                { "Fev", (130, 1100) },
                { "Mar", (160, 1250) },
                { "Abr", (140, 1150) },
                { "Mai", (155, 1180) },
                { "Jun", (165, 1220) },
            };

            UpdateChart();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            previousData = new Dictionary<string, (double energia, double agua)>(currentData);

            Random rand = new Random();

            Dictionary<string, (double energia, double agua)> updatedData = new Dictionary<string, (double energia, double agua)>();

            foreach (var mes in currentData.Keys)
            {
                double novaEnergia = rand.Next(120, 180);
                double novaAgua = rand.Next(1000, 1300);
                updatedData[mes] = (novaEnergia, novaAgua);
            }

            currentData = updatedData;

            UpdateChart();

            string mensagem = "Consumo do mês passado:\n\n";
            foreach (var item in previousData)
            {
                mensagem += $"{item.Key} - Energia: {item.Value.energia} kWh, Água: {item.Value.agua} L\n";
            }

            MessageBox.Show(mensagem, "Histórico de Consumo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateChart()
        {
            Series energiaSerie = consumptionChart.Series["Energia (kWh)"];
            Series aguaSerie = consumptionChart.Series["Água (Litros)"];

            energiaSerie.Points.Clear();
            aguaSerie.Points.Clear();

            foreach (var entry in currentData)
            {
                energiaSerie.Points.AddXY(entry.Key, entry.Value.energia);
                aguaSerie.Points.AddXY(entry.Key, entry.Value.agua);
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

