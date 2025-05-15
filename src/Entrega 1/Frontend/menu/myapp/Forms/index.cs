using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myapp
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string endpoint = textBox1.Text.Trim();

            // Se estiver vazio, vai pra página padrão
            if (string.IsNullOrEmpty(endpoint))
                endpoint = "/";

            string url = $"http://localhost:9999{endpoint}";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string resposta = await client.GetStringAsync(url);
                    textBox1.Text = resposta;
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Erro na requisição: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
