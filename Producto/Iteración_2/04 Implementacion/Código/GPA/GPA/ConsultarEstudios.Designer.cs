namespace GPA
{
    partial class ConsultarEstudios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarEstudios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTratamientos = new System.Windows.Forms.Button();
            this.btnExamenesGenerales = new System.Windows.Forms.Button();
            this.btnAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnPracticasComplementarias = new System.Windows.Forms.Button();
            this.btnEstudiosDiagPorImagenes = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTratamientos);
            this.panel1.Controls.Add(this.btnExamenesGenerales);
            this.panel1.Controls.Add(this.btnAnalisisLaboratorio);
            this.panel1.Controls.Add(this.btnPracticasComplementarias);
            this.panel1.Controls.Add(this.btnEstudiosDiagPorImagenes);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 537);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTratamientos
            // 
            this.btnTratamientos.Location = new System.Drawing.Point(3, 119);
            this.btnTratamientos.Name = "btnTratamientos";
            this.btnTratamientos.Size = new System.Drawing.Size(206, 23);
            this.btnTratamientos.TabIndex = 4;
            this.btnTratamientos.Text = "Tratamientos";
            this.btnTratamientos.UseVisualStyleBackColor = true;
            this.btnTratamientos.Click += new System.EventHandler(this.btnTratamientos_Click);
            // 
            // btnExamenesGenerales
            // 
            this.btnExamenesGenerales.Location = new System.Drawing.Point(3, 90);
            this.btnExamenesGenerales.Name = "btnExamenesGenerales";
            this.btnExamenesGenerales.Size = new System.Drawing.Size(206, 23);
            this.btnExamenesGenerales.TabIndex = 3;
            this.btnExamenesGenerales.Text = "Exámenes";
            this.btnExamenesGenerales.UseVisualStyleBackColor = true;
            this.btnExamenesGenerales.Click += new System.EventHandler(this.btnExamenesGenerales_Click);
            // 
            // btnAnalisisLaboratorio
            // 
            this.btnAnalisisLaboratorio.Location = new System.Drawing.Point(3, 61);
            this.btnAnalisisLaboratorio.Name = "btnAnalisisLaboratorio";
            this.btnAnalisisLaboratorio.Size = new System.Drawing.Size(206, 23);
            this.btnAnalisisLaboratorio.TabIndex = 2;
            this.btnAnalisisLaboratorio.Text = "Analisis Laboratorio";
            this.btnAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnAnalisisLaboratorio.Click += new System.EventHandler(this.btnAnalisisLaboratorio_Click);
            // 
            // btnPracticasComplementarias
            // 
            this.btnPracticasComplementarias.Location = new System.Drawing.Point(3, 32);
            this.btnPracticasComplementarias.Name = "btnPracticasComplementarias";
            this.btnPracticasComplementarias.Size = new System.Drawing.Size(206, 23);
            this.btnPracticasComplementarias.TabIndex = 1;
            this.btnPracticasComplementarias.Text = "Prácticas Complementarias";
            this.btnPracticasComplementarias.UseVisualStyleBackColor = true;
            this.btnPracticasComplementarias.Click += new System.EventHandler(this.btnPracticasComplementarias_Click);
            // 
            // btnEstudiosDiagPorImagenes
            // 
            this.btnEstudiosDiagPorImagenes.Location = new System.Drawing.Point(3, 3);
            this.btnEstudiosDiagPorImagenes.Name = "btnEstudiosDiagPorImagenes";
            this.btnEstudiosDiagPorImagenes.Size = new System.Drawing.Size(206, 23);
            this.btnEstudiosDiagPorImagenes.TabIndex = 0;
            this.btnEstudiosDiagPorImagenes.Text = "Estudios Diagnostico por Imagen";
            this.btnEstudiosDiagPorImagenes.UseVisualStyleBackColor = true;
            this.btnEstudiosDiagPorImagenes.Click += new System.EventHandler(this.btnEstudiosDiagPorImagenes_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(230, 12);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(842, 537);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ConsultarEstudios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarEstudios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultarEstudios";
            this.Load += new System.EventHandler(this.ConsultarEstudios_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEstudiosDiagPorImagenes;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnPracticasComplementarias;
        private System.Windows.Forms.Button btnAnalisisLaboratorio;
        private System.Windows.Forms.Button btnExamenesGenerales;
        private System.Windows.Forms.Button btnTratamientos;
    }
}