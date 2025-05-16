using System;
using System.Windows.Forms;

namespace TemporizadorComStacks
{
    public class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private Label lblTime;
        private Label lblStacks;
        private int countdownSeconds = 30; // Tempo necessário para 1 stack (exemplo)
        private int currentSeconds;
        private int stackCount = 0;

        public MainForm()
        {
            InitializeComponents();
            StartTimer();
        }

        private void InitializeComponents()
        {
            this.Text = "Temporizador com Stacks";
            this.ClientSize = new System.Drawing.Size(400, 200);

            lblTime = new Label
            {
                Text = "Tempo restante: ",
                AutoSize = true,
                Location = new System.Drawing.Point(30, 30),
                Font = new System.Drawing.Font("Segoe UI", 12)
            };

            lblStacks = new Label
            {
                Text = "Stacks acumulados: 0",
                AutoSize = true,
                Location = new System.Drawing.Point(30, 70),
                Font = new System.Drawing.Font("Segoe UI", 12)
            };

            this.Controls.Add(lblTime);
            this.Controls.Add(lblStacks);
        }

        private void StartTimer()
        {
            currentSeconds = countdownSeconds;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentSeconds--;

            lblTime.Text = $"Tempo restante: {currentSeconds}s";

            if (currentSeconds <= 0)
            {
                stackCount++;
                lblStacks.Text = $"Stacks acumulados: {stackCount}";

                // Reinicia a contagem para o próximo stack
                currentSeconds = countdownSeconds;
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
