namespace GPA
{
    partial class ConsultarHistoriaClínica
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.mtbFechaInicioTratamiento = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mtbFechaCreacionHC = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreApellidoPaciente = new System.Windows.Forms.TextBox();
            this.txtNroHc = new System.Windows.Forms.TextBox();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiagnostico = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvEstudios = new System.Windows.Forms.DataGridView();
            this.tbContenidoDeHC = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudios)).BeginInit();
            this.tbContenidoDeHC.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mtbFechaInicioTratamiento);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.mtbFechaCreacionHC);
            this.panel1.Controls.Add(this.txtNombreApellidoPaciente);
            this.panel1.Controls.Add(this.txtNroHc);
            this.panel1.Controls.Add(this.txtAntecedentes);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDiagnostico);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 514);
            this.panel1.TabIndex = 3;
            // 
            // mtbFechaInicioTratamiento
            // 
            this.mtbFechaInicioTratamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbFechaInicioTratamiento.Location = new System.Drawing.Point(370, 164);
            this.mtbFechaInicioTratamiento.Mask = "00/00/0000";
            this.mtbFechaInicioTratamiento.Name = "mtbFechaInicioTratamiento";
            this.mtbFechaInicioTratamiento.ReadOnly = true;
            this.mtbFechaInicioTratamiento.Size = new System.Drawing.Size(140, 30);
            this.mtbFechaInicioTratamiento.TabIndex = 14;
            this.mtbFechaInicioTratamiento.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(360, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha inicio tratamiento con profesional:";
            // 
            // mtbFechaCreacionHC
            // 
            this.mtbFechaCreacionHC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbFechaCreacionHC.Location = new System.Drawing.Point(188, 124);
            this.mtbFechaCreacionHC.Mask = "00/00/0000";
            this.mtbFechaCreacionHC.Name = "mtbFechaCreacionHC";
            this.mtbFechaCreacionHC.ReadOnly = true;
            this.mtbFechaCreacionHC.Size = new System.Drawing.Size(140, 30);
            this.mtbFechaCreacionHC.TabIndex = 12;
            this.mtbFechaCreacionHC.ValidatingType = typeof(System.DateTime);
            // 
            // txtNombreApellidoPaciente
            // 
            this.txtNombreApellidoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreApellidoPaciente.Location = new System.Drawing.Point(97, 88);
            this.txtNombreApellidoPaciente.Name = "txtNombreApellidoPaciente";
            this.txtNombreApellidoPaciente.ReadOnly = true;
            this.txtNombreApellidoPaciente.Size = new System.Drawing.Size(231, 30);
            this.txtNombreApellidoPaciente.TabIndex = 11;
            // 
            // txtNroHc
            // 
            this.txtNroHc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroHc.Location = new System.Drawing.Point(97, 52);
            this.txtNroHc.Name = "txtNroHc";
            this.txtNroHc.ReadOnly = true;
            this.txtNroHc.Size = new System.Drawing.Size(231, 30);
            this.txtNroHc.TabIndex = 10;
            // 
            // txtAntecedentes
            // 
            this.txtAntecedentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAntecedentes.Location = new System.Drawing.Point(8, 398);
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.Name = "txtAntecedentes";
            this.txtAntecedentes.Size = new System.Drawing.Size(544, 104);
            this.txtAntecedentes.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(382, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Antecedentes familiares de la enfermedad:";
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnostico.Location = new System.Drawing.Point(7, 254);
            this.txtDiagnostico.Multiline = true;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(545, 104);
            this.txtDiagnostico.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Diagnóstico:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Fecha de creación:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Número:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Paciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos de la historia clínica";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(584, 270);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(115, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(489, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvEstudios);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(489, 214);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Estudios";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvEstudios
            // 
            this.dgvEstudios.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstudios.Location = new System.Drawing.Point(6, 6);
            this.dgvEstudios.Name = "dgvEstudios";
            this.dgvEstudios.ReadOnly = true;
            this.dgvEstudios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEstudios.Size = new System.Drawing.Size(477, 202);
            this.dgvEstudios.TabIndex = 0;
            this.dgvEstudios.DoubleClick += new System.EventHandler(this.dgvEstudios_DoubleClick);
            // 
            // tbContenidoDeHC
            // 
            this.tbContenidoDeHC.Controls.Add(this.tabPage1);
            this.tbContenidoDeHC.Controls.Add(this.tabPage2);
            this.tbContenidoDeHC.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbContenidoDeHC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbContenidoDeHC.Location = new System.Drawing.Point(584, 12);
            this.tbContenidoDeHC.Name = "tbContenidoDeHC";
            this.tbContenidoDeHC.RightToLeftLayout = true;
            this.tbContenidoDeHC.SelectedIndex = 0;
            this.tbContenidoDeHC.Size = new System.Drawing.Size(497, 252);
            this.tbContenidoDeHC.TabIndex = 4;
            // 
            // ConsultarHistoriaClínica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 538);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tbContenidoDeHC);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ConsultarHistoriaClínica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Historia Clínica";
            this.Load += new System.EventHandler(this.ConsultarHistoriaClínica_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstudios)).EndInit();
            this.tbContenidoDeHC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAntecedentes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.MaskedTextBox mtbFechaCreacionHC;
        private System.Windows.Forms.TextBox txtNombreApellidoPaciente;
        private System.Windows.Forms.TextBox txtNroHc;
        private System.Windows.Forms.MaskedTextBox mtbFechaInicioTratamiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvEstudios;
        private System.Windows.Forms.TabControl tbContenidoDeHC;
    }
}