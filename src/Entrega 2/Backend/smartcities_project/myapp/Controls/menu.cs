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
            xpBotao1 += 2;

            if (xpBotao1 >= 4)
            {
                xpAtual += 15;
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

            // Adiciona quests com títulos e XP atuais
            AdicionarQuest("Use o aplicativo 4 dias consecutivos", xpBotao1, 4);
            AdicionarQuest("Tenha um gasto menor ou igual\na R$1000 neste mês", 1, 4);
            AdicionarQuest("Tenha uma média melhor de uso\nde energia nesse dia", 4, 7);
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

            // Forçar o painel a se redesenhar
            panelQuestsContainer.Invalidate(); // Força o painel a se redesenhar
        }

        private void IniciarAtualizadorDeQuests()
        {
            if (questUpdateTimer != null)
            {
                questUpdateTimer.Stop(); // Parar o timer caso esteja ativo
            }

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
                    if (quest.Titulo.Contains("xp") || quest.Titulo.Contains("XP"))
                    {
                        quest.SetDados(quest.Titulo, xpBotao1, 100);
                    }
                }
            }
        }

        // Métodos para garantir que a interface funcione corretamente
        private void label1_Click(object sender, EventArgs e) { }
        private void panelQuestsContainer_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void menu_Load(object sender, EventArgs e) { }
        private void siticoneCircleProgressBar1_ValueChanged(object sender, EventArgs e) { }
        private void siticoneCirclePictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panelQuestsContainer_Paint_1(object sender, PaintEventArgs e) { }
    }
}
