namespace myapp.Controls
{
    partial class menu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.siticoneCircleProgressBar1 = new Siticone.Desktop.UI.WinForms.SiticoneCircleProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.siticoneCirclePictureBox1 = new Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelQuestsContainer = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.siticoneCircleProgressBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticoneCirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // siticoneCircleProgressBar1
            // 
            this.siticoneCircleProgressBar1.Controls.Add(this.label1);
            this.siticoneCircleProgressBar1.FillColor = System.Drawing.Color.FromArgb(53, 49, 57);
            this.siticoneCircleProgressBar1.FillThickness = 15;
            this.siticoneCircleProgressBar1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.siticoneCircleProgressBar1.ForeColor = System.Drawing.Color.White;
            this.siticoneCircleProgressBar1.Location = new System.Drawing.Point(70, 36);
            this.siticoneCircleProgressBar1.Minimum = 0;
            this.siticoneCircleProgressBar1.Name = "siticoneCircleProgressBar1";
            this.siticoneCircleProgressBar1.ProgressBrushMode = Siticone.Desktop.UI.WinForms.Enums.BrushMode.Solid;
            this.siticoneCircleProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(255, 65, 65);
            this.siticoneCircleProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(255, 65, 65);
            this.siticoneCircleProgressBar1.ProgressEndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            this.siticoneCircleProgressBar1.ProgressThickness = 15;
            this.siticoneCircleProgressBar1.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.siticoneCircleProgressBar1.Size = new System.Drawing.Size(148, 148);
            this.siticoneCircleProgressBar1.TabIndex = 1;
            this.siticoneCircleProgressBar1.Text = "siticoneCircleProgressBar1";
            this.siticoneCircleProgressBar1.ValueChanged += new System.EventHandler(this.siticoneCircleProgressBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(31, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // siticoneCirclePictureBox1
            // 
            this.siticoneCirclePictureBox1.ImageRotate = 0F;
            this.siticoneCirclePictureBox1.Location = new System.Drawing.Point(140, 209);
            this.siticoneCirclePictureBox1.Name = "siticoneCirclePictureBox1";
            this.siticoneCirclePictureBox1.ShadowDecoration.Mode = Siticone.Desktop.UI.WinForms.Enums.ShadowMode.Circle;
            this.siticoneCirclePictureBox1.Size = new System.Drawing.Size(5, 5);
            this.siticoneCirclePictureBox1.TabIndex = 7;
            this.siticoneCirclePictureBox1.TabStop = false;
            this.siticoneCirclePictureBox1.Click += new System.EventHandler(this.siticoneCirclePictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Location = new System.Drawing.Point(161, 210);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(88, 1);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox1.Location = new System.Drawing.Point(35, 210);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 1);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelQuestsContainer
            // 
            this.panelQuestsContainer.AutoScroll = true;
            this.panelQuestsContainer.Location = new System.Drawing.Point(42, 238);
            this.panelQuestsContainer.Name = "panelQuestsContainer";
            this.panelQuestsContainer.Size = new System.Drawing.Size(200, 319);
            this.panelQuestsContainer.TabIndex = 9;
            this.panelQuestsContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelQuestsContainer_Paint_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click); // Corrigido para botão do menu.cs
            // 
            // menu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(26, 20, 29);
            this.Controls.Add(this.panelQuestsContainer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.siticoneCirclePictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.siticoneCircleProgressBar1);
            this.Name = "menu";
            this.Size = new System.Drawing.Size(300, 597);
            this.Load += new System.EventHandler(this.menu_Load);
            this.siticoneCircleProgressBar1.ResumeLayout(false);
            this.siticoneCircleProgressBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.siticoneCirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private Siticone.Desktop.UI.WinForms.SiticoneCircleProgressBar siticoneCircleProgressBar1;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneCirclePictureBox siticoneCirclePictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelQuestsContainer;
        private System.Windows.Forms.Button button1;
    }
}
