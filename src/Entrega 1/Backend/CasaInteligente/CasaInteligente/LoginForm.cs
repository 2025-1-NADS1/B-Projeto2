using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasaInteligente
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string senha = txtSenha.Text;

            if (usuario == "admin" && senha == "1234")
            {
                MainForm telaPrincipal = new MainForm();
                telaPrincipal.Show();
                this.Hide(); // Esconde a tela de login
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
