namespace GPA
{
    partial class MenuPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearHistoriaClínicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEstudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarHistoriaClinicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(813, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPacienteToolStripMenuItem,
            this.crearHistoriaClínicaToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // buscarPacienteToolStripMenuItem
            // 
            this.buscarPacienteToolStripMenuItem.Name = "buscarPacienteToolStripMenuItem";
            this.buscarPacienteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.buscarPacienteToolStripMenuItem.Text = "Buscar Paciente";
            this.buscarPacienteToolStripMenuItem.Click += new System.EventHandler(this.buscarPacienteToolStripMenuItem_Click);
            // 
            // crearHistoriaClínicaToolStripMenuItem
            // 
            this.crearHistoriaClínicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarHistoriaClinicaToolStripMenuItem,
            this.agregarEstudioToolStripMenuItem});
            this.crearHistoriaClínicaToolStripMenuItem.Name = "crearHistoriaClínicaToolStripMenuItem";
            this.crearHistoriaClínicaToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.crearHistoriaClínicaToolStripMenuItem.Text = "Historia Clínica";
            this.crearHistoriaClínicaToolStripMenuItem.Click += new System.EventHandler(this.crearHistoriaClínicaToolStripMenuItem_Click);
            // 
            // agregarEstudioToolStripMenuItem
            // 
            this.agregarEstudioToolStripMenuItem.Name = "agregarEstudioToolStripMenuItem";
            this.agregarEstudioToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.agregarEstudioToolStripMenuItem.Text = "Agregar Estudio";
            this.agregarEstudioToolStripMenuItem.Click += new System.EventHandler(this.agregarEstudioToolStripMenuItem_Click);
            // 
            // consultarHistoriaClinicaToolStripMenuItem
            // 
            this.consultarHistoriaClinicaToolStripMenuItem.Name = "consultarHistoriaClinicaToolStripMenuItem";
            this.consultarHistoriaClinicaToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.consultarHistoriaClinicaToolStripMenuItem.Text = "Consultar Historia Clinica";
            this.consultarHistoriaClinicaToolStripMenuItem.Click += new System.EventHandler(this.consultarHistoriaClinicaToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 345);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearHistoriaClínicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarEstudioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarHistoriaClinicaToolStripMenuItem;
    }
}