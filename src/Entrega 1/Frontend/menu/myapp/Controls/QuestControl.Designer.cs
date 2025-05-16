namespace myapp
{
    partial class QuestControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.progressBar = new Siticone.Desktop.UI.WinForms.SiticoneProgressBar();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Nirmala UI", 7F);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Location = new System.Drawing.Point(10, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(39, 12);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "lblTitulo";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Nirmala UI", 7F);
            this.lblContador.ForeColor = System.Drawing.SystemColors.Control;
            this.lblContador.Location = new System.Drawing.Point(167, 25);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(56, 12);
            this.lblContador.TabIndex = 1;
            this.lblContador.Text = "lblContador";
            this.lblContador.Click += new System.EventHandler(this.lblContador_Click);
            // 
            // progressBar
            // 
            this.progressBar.AutoRoundedCorners = true;
            this.progressBar.BorderRadius = 4;
            this.progressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(49)))), ((int)(((byte)(57)))));
            this.progressBar.Location = new System.Drawing.Point(10, 43);
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.progressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.progressBar.Size = new System.Drawing.Size(179, 10);
            this.progressBar.TabIndex = 2;
            this.progressBar.Text = "siticoneProgressBar1";
            this.progressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.progressBar.ValueChanged += new System.EventHandler(this.progressBar_ValueChanged);
            // 
            // QuestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.lblTitulo);
            this.Name = "QuestControl";
            this.Size = new System.Drawing.Size(232, 97);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblContador;

        private Siticone.Desktop.UI.WinForms.SiticoneProgressBar progressBar;
    }
}
