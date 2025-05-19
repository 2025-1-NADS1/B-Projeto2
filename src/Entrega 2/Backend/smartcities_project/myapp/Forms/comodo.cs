using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace myapp
{
    public partial class comodo : Form
    {
        // Eventos para interação com outras partes do sistema
        public event Action<string> OnDeleteRequested;
        public event Action OnVoltarRequested;
        public event Action<string, string> OnRenameRequested;

        private string nomeComodo;

        // Construtor da classe, que recebe o nome do cômodo
        public comodo(string nome)
        {
            InitializeComponent();
            this.nomeComodo = nome;  // Atribui o nome do cômodo à variável local
        }

        // Evento de clique no botão "Voltar" para navegar para o formulário principal
        private void button1_Click(object sender, EventArgs e)
        {
            OnVoltarRequested?.Invoke();  // Invoca o evento para informar a solicitação de retorno

            // Criação e exibição do formulário principal
            main trocar = new main();
            trocar.TopLevel = false;
            trocar.FormBorderStyle = FormBorderStyle.None;
            trocar.Dock = DockStyle.Fill;

            this.Controls.Clear();  // Limpa os controles atuais
            this.Controls.Add(trocar);  // Adiciona o novo formulário
            trocar.Show();
        }

        // Evento de clique no botão para deletar o cômodo
        private void button2_Click_1(object sender, EventArgs e)
        {
            // Exibe uma caixa de confirmação antes de excluir o cômodo
            var resultado = MessageBox.Show("Tem certeza que deseja deletar este cômodo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                // Leitura do arquivo de cômodos
                string[] linhas = File.ReadAllLines("comodos.txt");
                // Remove a linha correspondente ao cômodo a ser deletado
                var linhasAtualizadas = linhas.Where(l => l != nomeComodo).ToList();

                // Salva o arquivo sem o cômodo deletado
                File.WriteAllLines("comodos.txt", linhasAtualizadas);

                // Invoca o evento de deleção do cômodo
                OnDeleteRequested?.Invoke(nomeComodo);

                // Atraso de 1,5 segundos antes de voltar à tela principal
                Timer t = new Timer();
                t.Interval = 1500; // Intervalo de 1,5 segundos
                t.Tick += (s, ev) =>
                {
                    t.Stop();

                    // Exibe o formulário principal após a exclusão
                    main voltar = new main();
                    voltar.TopLevel = false;
                    voltar.FormBorderStyle = FormBorderStyle.None;
                    voltar.Dock = DockStyle.Fill;

                    this.Controls.Clear();  // Limpa o formulário atual
                    this.Controls.Add(voltar);  // Adiciona o formulário principal
                    voltar.Show();
                };
                t.Start();
            }
        }

        // Evento de clique no botão "Fechar" para sair da aplicação
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Encerra a aplicação
        }

        // Evento de carregamento do formulário (não utilizado atualmente)
        private void comodo_Load(object sender, EventArgs e) { }

        // Eventos de texto nos campos (não utilizados atualmente)
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }

        // Métodos de eventos de clique nos componentes visuais que não possuem lógica implementada
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void pictureBox6_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }

        // Métodos de eventos para os componentes de texto, como TextBoxes, que não possuem lógica implementada
        private void siticoneTextBox1_TextChanged(object sender, EventArgs e) { }
        private void siticoneTextBox2_TextChanged(object sender, EventArgs e) { }
        private void siticoneTextBox1_TextChanged_1(object sender, EventArgs e) { }
        private void siticoneTextBox2_TextChanged_1(object sender, EventArgs e) { }

        // Métodos para os eventos de alternância de switches, sem lógica implementada
        private void siticoneToggleSwitch8_CheckedChanged(object sender, EventArgs e) { }
        private void siticoneToggleSwitch4_CheckedChanged(object sender, EventArgs e) { }
        private void siticoneToggleSwitch9_CheckedChanged(object sender, EventArgs e) { }
        private void siticoneToggleSwitch3_CheckedChanged(object sender, EventArgs e) { }
        private void siticoneToggleSwitch2_CheckedChanged(object sender, EventArgs e) { }
        private void siticoneToggleSwitch1_CheckedChanged(object sender, EventArgs e) { }

        // Métodos para os eventos de clique nas imagens de PictureBox sem lógica implementada
        private void siticonePictureBox2_Click(object sender, EventArgs e) { }
        private void siticonePictureBox3_Click(object sender, EventArgs e) { }
        private void siticonePictureBox1_Click(object sender, EventArgs e) { }
        private void siticonePictureBox2_Click_1(object sender, EventArgs e) { }
        private void siticonePictureBox3_Click_1(object sender, EventArgs e) { }

        // Evento de clique no botão de "Fechar" para sair da aplicação (duplicado)
        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();  // Encerra a aplicação
        }
    }
}
