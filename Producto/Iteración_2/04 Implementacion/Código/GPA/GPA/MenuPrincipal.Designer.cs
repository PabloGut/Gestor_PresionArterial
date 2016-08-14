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
            this.registrarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearHistoriaClínicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarHistoriaClinicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEstudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarProfesionalMédicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.ediciónToolStripMenuItem});
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
            this.registrarPacienteToolStripMenuItem,
            this.buscarPacienteToolStripMenuItem,
            this.crearHistoriaClínicaToolStripMenuItem,
            this.registrarProfesionalMédicoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
            // 
            // registrarPacienteToolStripMenuItem
            // 
            this.registrarPacienteToolStripMenuItem.Name = "registrarPacienteToolStripMenuItem";
            this.registrarPacienteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.registrarPacienteToolStripMenuItem.Text = "Registrar Paciente";
            this.registrarPacienteToolStripMenuItem.Click += new System.EventHandler(this.registrarPacienteToolStripMenuItem_Click);
            // 
            // buscarPacienteToolStripMenuItem
            // 
            this.buscarPacienteToolStripMenuItem.Name = "buscarPacienteToolStripMenuItem";
            this.buscarPacienteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.buscarPacienteToolStripMenuItem.Text = "Buscar Paciente";
            this.buscarPacienteToolStripMenuItem.Click += new System.EventHandler(this.buscarPacienteToolStripMenuItem_Click);
            // 
            // crearHistoriaClínicaToolStripMenuItem
            // 
            this.crearHistoriaClínicaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarHistoriaClinicaToolStripMenuItem,
            this.agregarEstudioToolStripMenuItem});
            this.crearHistoriaClínicaToolStripMenuItem.Name = "crearHistoriaClínicaToolStripMenuItem";
            this.crearHistoriaClínicaToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.crearHistoriaClínicaToolStripMenuItem.Text = "Historia Clínica";
            this.crearHistoriaClínicaToolStripMenuItem.Click += new System.EventHandler(this.crearHistoriaClínicaToolStripMenuItem_Click);
            // 
            // consultarHistoriaClinicaToolStripMenuItem
            // 
            this.consultarHistoriaClinicaToolStripMenuItem.Name = "consultarHistoriaClinicaToolStripMenuItem";
            this.consultarHistoriaClinicaToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.consultarHistoriaClinicaToolStripMenuItem.Text = "Consultar Historia Clinica";
            this.consultarHistoriaClinicaToolStripMenuItem.Click += new System.EventHandler(this.consultarHistoriaClinicaToolStripMenuItem_Click);
            // 
            // agregarEstudioToolStripMenuItem
            // 
            this.agregarEstudioToolStripMenuItem.Name = "agregarEstudioToolStripMenuItem";
            this.agregarEstudioToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.agregarEstudioToolStripMenuItem.Text = "Agregar Estudio";
            this.agregarEstudioToolStripMenuItem.Click += new System.EventHandler(this.agregarEstudioToolStripMenuItem_Click);
            // 
            // ediciónToolStripMenuItem
            // 
            this.ediciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barriosToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.localidadesToolStripMenuItem,
            this.tiposDeDocumentoToolStripMenuItem});
            this.ediciónToolStripMenuItem.Name = "ediciónToolStripMenuItem";
            this.ediciónToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ediciónToolStripMenuItem.Text = "Edición";
            // 
            // barriosToolStripMenuItem
            // 
            this.barriosToolStripMenuItem.Name = "barriosToolStripMenuItem";
            this.barriosToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.barriosToolStripMenuItem.Text = "Barrios";
            this.barriosToolStripMenuItem.Click += new System.EventHandler(this.barriosToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // localidadesToolStripMenuItem
            // 
            this.localidadesToolStripMenuItem.Name = "localidadesToolStripMenuItem";
            this.localidadesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.localidadesToolStripMenuItem.Text = "Localidades";
            this.localidadesToolStripMenuItem.Click += new System.EventHandler(this.localidadesToolStripMenuItem_Click);
            // 
            // tiposDeDocumentoToolStripMenuItem
            // 
            this.tiposDeDocumentoToolStripMenuItem.Name = "tiposDeDocumentoToolStripMenuItem";
            this.tiposDeDocumentoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.tiposDeDocumentoToolStripMenuItem.Text = "Tipos de Documento";
            this.tiposDeDocumentoToolStripMenuItem.Click += new System.EventHandler(this.tiposDeDocumentoToolStripMenuItem_Click);
            // 
            // registrarProfesionalMédicoToolStripMenuItem
            // 
            this.registrarProfesionalMédicoToolStripMenuItem.Name = "registrarProfesionalMédicoToolStripMenuItem";
            this.registrarProfesionalMédicoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.registrarProfesionalMédicoToolStripMenuItem.Text = "Registrar Profesional Médico";
            this.registrarProfesionalMédicoToolStripMenuItem.Click += new System.EventHandler(this.registrarProfesionalMédicoToolStripMenuItem_Click);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipal_FormClosed);
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
        private System.Windows.Forms.ToolStripMenuItem ediciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeDocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarPacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarProfesionalMédicoToolStripMenuItem;
    }
}