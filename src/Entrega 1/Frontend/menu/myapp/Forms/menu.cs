using System;
using System.Windows.Forms;

namespace myapp
{
    public partial class menu : Form
    {
        // Variáveis para controlar o XP e o nível
        int nivel = 1;
        int xpAtual = 0;

        public menu()
        {
            InitializeComponent();

            // Atualiza a interface com os valores iniciais
            AtualizarInterface();

            // Carregar quests na inicialização
            CarregarQuests();
        }

        // Atualiza a barra de progresso e o texto do label
        private void AtualizarInterface()
        {
            int xpNecessario = nivel * 100; // XP necessário para o próximo nível

            // Atualiza a barra de progresso (maximo e valor atual)
            siticoneCircleProgressBar1.Maximum = xpNecessario;
            siticoneCircleProgressBar1.Value = xpAtual;

            // Atualiza o texto do label com o nível atual
            label1.Text = $"Lvl: {nivel}";
        }

        // Evento de clique do botão que adiciona 100 XP
        private void button1_Click(object sender, EventArgs e)
        {

            // Checa se atingiu o necessário para upar de nível
            while (xpAtual >= nivel * 100)
            {
                xpAtual -= nivel * 100; // Remove o XP usado para upar
                nivel++; // Sobe um nível
            }

            // Atualiza a interface com o novo estado
            AtualizarInterface();
        }

        // Método para carregar quests no painel
        private void CarregarQuests()
        {
            // Limpa quests antigas, se houver
            panelQuestsContainer.Controls.Clear();

            // Exemplo: Quest 1
            AdicionarQuest("Dias consecutivos usando o app", 1, 4);

            // Exemplo: Quest 2
            AdicionarQuest("Complete sua lista de tarefas diárias", 4, 7);

            // Adicione mais quests aqui conforme quiser
        }

        // Método auxiliar para criar e adicionar um QuestControl ao painel
        private void AdicionarQuest(string titulo, int atual, int maximo)
        {
            QuestControl quest = new QuestControl();
            quest.SetDados(titulo, atual, maximo);

            // Ajusta tamanho para preencher a largura do painel com uma margem
            quest.Width = panelQuestsContainer.ClientSize.Width - 10;
            quest.Height = 60; // ajuste conforme desejar

            // Vincula o evento para remover quest quando completar
            quest.OnQuestCompleta += Quest_OnQuestCompleta;

            // Adiciona ao painel
            panelQuestsContainer.Controls.Add(quest);
        }

        // Evento disparado quando uma quest é completada
        private void Quest_OnQuestCompleta(QuestControl quest)
        {
            // Remove a quest completada do painel
            panelQuestsContainer.Controls.Remove(quest);

            // Reorganiza as quests restantes para "subir"
            ReorganizarQuests();
        }

        // Organiza as quests no painel para que não fiquem espaços vazios
        private void ReorganizarQuests()
        {
            int y = 0;
            foreach (Control ctrl in panelQuestsContainer.Controls)
            {
                ctrl.Location = new System.Drawing.Point(0, y);
                y += ctrl.Height + 5; // espaço entre quests
            }
        }

        // Você pode deixar os outros eventos vazios ou removê-los se não estiver usando
        private void siticoneCircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            // Evento automático, pode deixar vazio
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelQuestsContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
