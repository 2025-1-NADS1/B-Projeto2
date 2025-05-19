using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace myapp
{
    partial class GraficoComodo
    {
        private Label lblTitulo;
        private Chart chartLuz;
        private Chart chartAgua;
        private PictureBox pictureBox1;



        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chartLuz = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAgua = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAgua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Nirmala UI", 13F);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(56, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título";
            // 
            // chartLuz
            // 
            this.chartLuz.BackColor = System.Drawing.Color.Transparent;
            this.chartLuz.Location = new System.Drawing.Point(10, 40);
            this.chartLuz.Name = "chartLuz";
            this.chartLuz.Size = new System.Drawing.Size(231, 284);
            this.chartLuz.TabIndex = 1;
            this.chartLuz.Text = "chartLuz";
            // 
            // chartAgua
            // 
            this.chartAgua.BackColor = System.Drawing.Color.Transparent;
            this.chartAgua.BorderlineWidth = 0;
            this.chartAgua.Location = new System.Drawing.Point(256, 40);
            this.chartAgua.Name = "chartAgua";
            this.chartAgua.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartAgua.Size = new System.Drawing.Size(231, 284);
            this.chartAgua.TabIndex = 2;
            this.chartAgua.Text = "chartAgua";
            this.chartAgua.Click += new System.EventHandler(this.chartAgua_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(513, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1, 332);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // GraficoComodo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chartAgua);
            this.Controls.Add(this.chartLuz);
            this.Controls.Add(this.lblTitulo);
            this.Name = "GraficoComodo";
            this.Size = new System.Drawing.Size(523, 352);
            ((System.ComponentModel.ISupportInitialize)(this.chartLuz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAgua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
