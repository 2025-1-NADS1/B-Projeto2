using System;
using System.Windows.Forms;

namespace myapp
{
    public partial class menu : Form
    {
        // Variáveis para controlar o XP e o nível
        int nivel = 1;
        int xpAtual = 0;
        int tempoDecorrido = 0;

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
            siticoneCircleProgressBar1.Value = Math.Min(xpAtual, xpNecessario);

            // Atualiza o texto do label com o nível atual
            label1.Text = $"Lvl: {nivel}";
        }

        // Evento de clique do botão que adiciona XP
        private void button1_Click(object sender, EventArgs e)
        {
            tempoDecorrido += 5;

            if (tempoDecorrido >= 100)
            {
                xpAtual += 5;
            }

            while (xpAtual >= nivel * 100)
            {
                xpAtual -= nivel * 100; // Remove o XP usado para upar
                nivel++; // Sobe um nível
            }




            AtualizarInterface();
        }

        // Método para carregar quests no painel
        private void CarregarQuests()
        {
            // Limpa quests antigas, se houver
            panelQuestsContainer.Controls.Clear();

            // Variável para controle da posição vertical
            int y = 0;

            // Exemplo: Quest 1
            AdicionarQuest("Dias consecutivos usando o app", tempoDecorrido, 4, ref y);

            // Exemplo: Quest 2
            AdicionarQuest("Complete sua lista de tarefas diárias", 4, 7, ref y);

            // Aqui você pode adicionar mais quests, passando o 'y' para posicionar corretamente
        }

        // Método auxiliar para criar e adicionar um QuestControl ao painel
        private void AdicionarQuest(string titulo, int atual, int maximo, ref int posY)
        {
            QuestControl quest = new QuestControl();
            quest.SetDados(titulo, atual, maximo);

            // Ajusta tamanho para preencher a largura do painel com uma margem
            quest.Width = panelQuestsContainer.ClientSize.Width - 10;
            quest.Height = 60; // ajuste conforme desejar

            // Define a posição no painel para empilhar as quests
            quest.Location = new System.Drawing.Point(0, posY);
            posY += quest.Height + 5; // incrementa posição para próxima quest

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

        // Eventos gerados automaticamente - podem ficar vazios se não usados
        private void siticoneCircleProgressBar1_ValueChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void panelQuestsContainer_Paint(object sender, PaintEventArgs e) { }
        private void menu_Load(object sender, EventArgs e) { }
    }
}
