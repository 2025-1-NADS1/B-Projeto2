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
            xpAtual += 100; // Adiciona 100 de XP

            // Checa se atingiu o necessário para upar de nível
            while (xpAtual >= nivel * 100)
            {
                xpAtual -= nivel * 100; // Remove o XP usado para upar
                nivel++; // Sobe um nível
            }

            // Atualiza a interface com o novo estado
            AtualizarInterface();
        }

        // Você pode deixar os outros eventos vazios ou removê-los se não estiver usando
        private void siticoneCircleProgressBar1_ValueChanged(object sender, EventArgs e)
        {
            // Evento automático, pode deixar vazio
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
