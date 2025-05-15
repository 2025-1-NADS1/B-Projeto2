using System;
using System.Windows.Forms;

namespace myapp
{
    public partial class QuestControl : UserControl
    {
        // Evento que será chamado quando a missão for completada
        public event Action<QuestControl> OnQuestCompleta;

        // Propriedades internas
        private int valorAtual;
        private int valorMaximo;

        public QuestControl()
        {
            InitializeComponent();
        }

        // Define os dados da missão
        public void SetDados(string titulo, int atual, int maximo)
        {
            lblTitulo.Text = titulo;
            valorAtual = atual;
            valorMaximo = maximo;

            progressBar.Maximum = valorMaximo;
            progressBar.Value = Math.Min(valorAtual, valorMaximo);
            lblContador.Text = $"{valorAtual} / {valorMaximo}";

            VerificarCompleto();
        }

        // Atualiza o progresso da missão
        public void AtualizarProgresso(int novoValor)
        {
            valorAtual = novoValor;
            progressBar.Value = Math.Min(valorAtual, valorMaximo);
            lblContador.Text = $"{valorAtual} / {valorMaximo}";

            VerificarCompleto();
        }

        // Verifica se a missão foi completada
        private void VerificarCompleto()
        {
            if (valorAtual >= valorMaximo)
            {
                OnQuestCompleta?.Invoke(this);
            }
        }

        private void lblContador_Click(object sender, EventArgs e)
        {

        }

        private void progressBar_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
