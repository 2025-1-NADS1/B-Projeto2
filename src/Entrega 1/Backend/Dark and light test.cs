using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Projeto : Form
    {
        private bool isDarkMode = false;
        private PictureBox pictureBox1;
        private Button button1;
        private Image baseImage;

        public Projeto()
        {
            InitializeCustomComponents();

            // Carrega imagem base
            baseImage = Image.FromFile("C:Users25027024DesktopimagensVector 1.png"); // certifique-se do caminho
            SetLightMode();
        }

        private void InitializeCustomComponents()
        {
            this.ClientSize = new Size(600, 400);
            this.Text = "Tema com Imagem Adaptativa";

            pictureBox1 = new PictureBox
            {
                Location = new Point(100, 50),
                Size = new Size(400, 200),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            button1 = new Button
            {
                Text = "Ativar Modo Escuro",
                Location = new Point(250, 300),
                AutoSize = true
            };
            button1.Click += new EventHandler(button1_Click);

            this.Controls.Add(pictureBox1);
            this.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
                SetLightMode();
            else
                SetDarkMode();
        }

        private void SetLightMode()
        {
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;

            button1.BackColor = Color.LightGray;
            button1.ForeColor = Color.Black;
            button1.Text = "Ativar Modo Escuro";

            isDarkMode = false;
            pictureBox1.Image = ImageThemeHelper.ApplyThemeFilter(baseImage, isDarkMode);
        }

        private void SetDarkMode()
        {
            this.BackColor = Color.Black;
            this.ForeColor = Color.White;

            button1.BackColor = Color.DarkGray;
            button1.ForeColor = Color.White;
            button1.Text = "Ativar Modo Claro";

            isDarkMode = true;
            pictureBox1.Image = ImageThemeHelper.ApplyThemeFilter(baseImage, isDarkMode);
        }
    }

    public static class ImageThemeHelper
    {
        public static Image ApplyThemeFilter(Image original, bool isDarkMode)
        {
            float brightness = isDarkMode ? 0.8f : 1.2f;
            float saturation = isDarkMode ? 0.9f : 1.1f;

            return ApplyColorMatrix(original, brightness, saturation);
        }

        private static Image ApplyColorMatrix(Image original, float brightness, float saturation)
        {
            float lumR = 0.3086f;
            float lumG = 0.6094f;
            float lumB = 0.0820f;

            float sr = (1 - saturation) * lumR + saturation;
            float sg = (1 - saturation) * lumG;
            float sb = (1 - saturation) * lumB;

            float sr2 = (1 - saturation) * lumR;
            float sg2 = (1 - saturation) * lumG + saturation;
            float sb2 = (1 - saturation) * lumB;

            float sr3 = (1 - saturation) * lumR;
            float sg3 = (1 - saturation) * lumG;
            float sb3 = (1 - saturation) * lumB + saturation;

            ColorMatrix matrix = new ColorMatrix(new float[][]
            {
                new float[] { sr * brightness, sg * brightness, sb * brightness, 0, 0 },
                new float[] { sr2 * brightness, sg2 * brightness, sb2 * brightness, 0, 0 },
                new float[] { sr3 * brightness, sg3 * brightness, sb3 * brightness, 0, 0 },
                new float[] { 0, 0, 0, 1f, 0 },
                new float[] { 0, 0, 0, 0, 1f }
            });

            Bitmap newImage = new Bitmap(original.Width, original.Height);
            using (Graphics g = Graphics.FromImage(newImage))
            using (ImageAttributes attr = new ImageAttributes())
            {
                attr.SetColorMatrix(matrix);
                g.DrawImage(original, new Rectangle(0, 0, newImage.Width, newImage.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel, attr);
            }

            return newImage;
        }
    }

    // Classe Program com Main
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Projeto());
        }
    }
}

