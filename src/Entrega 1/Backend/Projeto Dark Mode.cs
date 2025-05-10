using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Projeto : Form
    {
        // Variáveis para controlar o modo atual
        private bool isDarkMode = false;

        public Projeto()
        {
            InitializeComponent();
            // Configuração inicial do tema (Modo Claro)
            SetLightMode();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Alternar entre Modo Claro e Modo Escuro
            if (isDarkMode)
            {
                SetLightMode();  // Ativa o Modo Claro
            }
            else
            {
                SetDarkMode();   // Ativa o Modo Escuro
            }
        }

        private void SetLightMode()
        {
            // Configurações para o Modo Claro
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.Black;

            isDarkMode = false;  // Atualiza a variável de controle
            button1.Text = "Ativar Modo Escuro";
        }

        private void SetDarkMode()
        {
            // Configurações para o Modo Escuro
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            button1.BackColor = Color.DarkGray;
            button1.ForeColor = Color.White;

            isDarkMode = true;  // Atualiza a variável de controle
            button1.Text = "Ativar Modo Claro";
        }
    }
}
