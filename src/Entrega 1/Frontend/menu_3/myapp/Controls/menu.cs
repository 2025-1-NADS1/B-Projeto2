using System;
using System.Windows.Forms;

namespace myapp.Controls
{
    public partial class menu : UserControl
    {
        int nivel = 1;
        int xpAtual = 0;
        int xpBotao1 = 0;

        int alturaAtual = 0;
        int espacamentoEntreQuests = 5;

        Timer questUpdateTimer;

        public menu()
        {
            InitializeComponent();

            AtualizarInterface();
            CarregarQuests();
            IniciarAtualizadorDeQuests();
        }

        private void AtualizarInterface()
        {
            int xpNecessario = nivel * 100;
            siticoneCircleProgressBar1.Maximum = xpNecessario;

            // Garantir que o valor não ultrapasse o máximo para evitar erro
            siticoneCircleProgressBar1.Value = Math.Min(xpAtual, xpNecessario);

            label1.Text = $"Lvl: {nivel}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xpBotao1 += 5;

            if (xpBotao1 >= 100)
            {
                xpAtual += 5;
                xpBotao1 = 0; // Zera xpBotao1 depois de usar para xpAtual
            }

            // Evoluir nível enquanto possível
            while (xpAtual >= nivel * 100)
            {
                xpAtual -= nivel * 100;
                nivel++;
            }

            AtualizarInterface();
            CarregarQuests(); // Atualiza as quests para refletir XP novo
        }

        private void CarregarQuests()
        {
            panelQuestsContainer.Controls.Clear();
            alturaAtual = 0;

            AdicionarQuest("Tome no co 1 milhao de vezes", xpBotao1, 100); // Corrigi maximo de 999 para 100
            AdicionarQuest("Dias consecutivos usando o app", 1, 4);
            AdicionarQuest("Complete sua lista de tarefas diárias", 4, 7);
        }

        private QuestControl AdicionarQuest(string titulo, int atual, int maximo)
        {
            QuestControl quest = new QuestControl();
            quest.SetDados(titulo, atual, maximo);

            quest.Width = panelQuestsContainer.ClientSize.Width - 10;
            quest.Height = 60;

            quest.Left = 0;
            quest.Top = alturaAtual;

            alturaAtual += quest.Height + espacamentoEntreQuests;

            quest.OnQuestCompleta += Quest_OnQuestCompleta;

            panelQuestsContainer.Controls.Add(quest);

            return quest;
        }

        private void Quest_OnQuestCompleta(QuestControl quest)
        {
            panelQuestsContainer.Controls.Remove(quest);
            ReorganizarQuests();
        }

        private void ReorganizarQuests()
        {
            int y = 0;
            foreach (Control ctrl in panelQuestsContainer.Controls)
            {
                ctrl.Location = new System.Drawing.Point(0, y);
                y += ctrl.Height + espacamentoEntreQuests;
            }
            alturaAtual = y;
        }

        private void IniciarAtualizadorDeQuests()
        {
            questUpdateTimer = new Timer();
            questUpdateTimer.Interval = 200; // 0.2 segundos
            questUpdateTimer.Tick += QuestUpdateTimer_Tick;
            questUpdateTimer.Start();
        }

        private void QuestUpdateTimer_Tick(object sender, EventArgs e)
        {
            foreach (Control ctrl in panelQuestsContainer.Controls)
            {
                if (ctrl is QuestControl quest)
                {
                    // Atualiza as quests que dependem do XP Botão1
                    if (quest.Titulo.Contains("Tome no co") || quest.Titulo.Contains("XP"))
                    {
                        quest.SetDados(quest.Titulo, xpBotao1, 100);
                    }
                }
            }
        }

        // Os métodos abaixo estão vazios, mas mantive para que não quebre caso sejam usados no Designer
        private void label1_Click(object sender, EventArgs e) { }
        private void panelQuestsContainer_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void menu_Load(object sender, EventArgs e) { }
        private void siticoneCircleProgressBar1_ValueChanged(object sender, EventArgs e) { }
        private void button1_Click_1(object sender, EventArgs e) { }
        private void siticoneCirclePictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panelQuestsContainer_Paint_1(object sender, PaintEventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
    }
}
