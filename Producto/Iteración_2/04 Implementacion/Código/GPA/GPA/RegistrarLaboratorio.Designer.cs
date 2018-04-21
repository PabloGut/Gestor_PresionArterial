namespace GPA
{
    partial class RegistrarLaboratorio
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnalisisSolicitado = new System.Windows.Forms.TextBox();
            this.btnAgregarInstitucion = new System.Windows.Forms.Button();
            this.cboInstitucion = new System.Windows.Forms.ComboBox();
            this.mtbFechaPractica = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoctorACargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarUnidadMedida = new System.Windows.Forms.Button();
            this.btnAgregarMetodoAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnNuevoAnalisis = new System.Windows.Forms.Button();
            this.btnAgregarResultadoAnalisis = new System.Windows.Forms.Button();
            this.dgvListaResultadosAnalisis = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.cboUnidadDeMedida = new System.Windows.Forms.ComboBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEstudioSeleccionado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstudioBuscado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscarItemEstudioLaboratorio = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvListadoItemsEstudioLaboratorio = new System.Windows.Forms.DataGridView();
            this.cboMetodoAnalisisLaboratorio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardarInformeAnalisis = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaResultadosAnalisis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoItemsEstudioLaboratorio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Análisis Laboratorio Solicitado";
            // 
            // txtAnalisisSolicitado
            // 
            this.txtAnalisisSolicitado.Location = new System.Drawing.Point(159, 23);
            this.txtAnalisisSolicitado.Name = "txtAnalisisSolicitado";
            this.txtAnalisisSolicitado.ReadOnly = true;
            this.txtAnalisisSolicitado.Size = new System.Drawing.Size(142, 20);
            this.txtAnalisisSolicitado.TabIndex = 1;
            // 
            // btnAgregarInstitucion
            // 
            this.btnAgregarInstitucion.Location = new System.Drawing.Point(159, 156);
            this.btnAgregarInstitucion.Name = "btnAgregarInstitucion";
            this.btnAgregarInstitucion.Size = new System.Drawing.Size(119, 23);
            this.btnAgregarInstitucion.TabIndex = 19;
            this.btnAgregarInstitucion.Text = "Agregar Institución";
            this.btnAgregarInstitucion.UseVisualStyleBackColor = true;
            this.btnAgregarInstitucion.Click += new System.EventHandler(this.btnAgregarInstitucion_Click);
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(159, 129);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(183, 21);
            this.cboInstitucion.TabIndex = 18;
            // 
            // mtbFechaPractica
            // 
            this.mtbFechaPractica.Location = new System.Drawing.Point(159, 57);
            this.mtbFechaPractica.Mask = "00/00/0000";
            this.mtbFechaPractica.Name = "mtbFechaPractica";
            this.mtbFechaPractica.Size = new System.Drawing.Size(87, 20);
            this.mtbFechaPractica.TabIndex = 17;
            this.mtbFechaPractica.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nombre de la institución";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nombre del doctor a cargo";
            // 
            // txtDoctorACargo
            // 
            this.txtDoctorACargo.Location = new System.Drawing.Point(159, 89);
            this.txtDoctorACargo.Name = "txtDoctorACargo";
            this.txtDoctorACargo.Size = new System.Drawing.Size(183, 20);
            this.txtDoctorACargo.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fecha de realización";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(358, 26);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(505, 60);
            this.txtObservaciones.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Observaciones de los resultados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboInstitucion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.txtAnalisisSolicitado);
            this.groupBox1.Controls.Add(this.btnAgregarInstitucion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDoctorACargo);
            this.groupBox1.Controls.Add(this.mtbFechaPractica);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(869, 189);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del estudio";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarUnidadMedida);
            this.groupBox2.Controls.Add(this.btnAgregarMetodoAnalisisLaboratorio);
            this.groupBox2.Controls.Add(this.btnNuevoAnalisis);
            this.groupBox2.Controls.Add(this.btnAgregarResultadoAnalisis);
            this.groupBox2.Controls.Add(this.dgvListaResultadosAnalisis);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboUnidadDeMedida);
            this.groupBox2.Controls.Add(this.txtResultado);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtEstudioSeleccionado);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtEstudioBuscado);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnBuscarItemEstudioLaboratorio);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvListadoItemsEstudioLaboratorio);
            this.groupBox2.Controls.Add(this.cboMetodoAnalisisLaboratorio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(869, 269);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informe del análisis";
            // 
            // btnAgregarUnidadMedida
            // 
            this.btnAgregarUnidadMedida.Location = new System.Drawing.Point(665, 71);
            this.btnAgregarUnidadMedida.Name = "btnAgregarUnidadMedida";
            this.btnAgregarUnidadMedida.Size = new System.Drawing.Size(159, 23);
            this.btnAgregarUnidadMedida.TabIndex = 17;
            this.btnAgregarUnidadMedida.Text = "Agregar Unidad de Medida";
            this.btnAgregarUnidadMedida.UseVisualStyleBackColor = true;
            this.btnAgregarUnidadMedida.Click += new System.EventHandler(this.btnAgregarUnidadMedida_Click);
            // 
            // btnAgregarMetodoAnalisisLaboratorio
            // 
            this.btnAgregarMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(217, 31);
            this.btnAgregarMetodoAnalisisLaboratorio.Name = "btnAgregarMetodoAnalisisLaboratorio";
            this.btnAgregarMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarMetodoAnalisisLaboratorio.TabIndex = 16;
            this.btnAgregarMetodoAnalisisLaboratorio.Text = "Agregar método";
            this.btnAgregarMetodoAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnAgregarMetodoAnalisisLaboratorio.Click += new System.EventHandler(this.btnAgregarMetodoAnalisisLaboratorio_Click);
            // 
            // btnNuevoAnalisis
            // 
            this.btnNuevoAnalisis.Location = new System.Drawing.Point(220, 120);
            this.btnNuevoAnalisis.Name = "btnNuevoAnalisis";
            this.btnNuevoAnalisis.Size = new System.Drawing.Size(75, 39);
            this.btnNuevoAnalisis.TabIndex = 15;
            this.btnNuevoAnalisis.Text = "Nuevo análisis";
            this.btnNuevoAnalisis.UseVisualStyleBackColor = true;
            this.btnNuevoAnalisis.Click += new System.EventHandler(this.btnNuevoAnalisis_Click);
            // 
            // btnAgregarResultadoAnalisis
            // 
            this.btnAgregarResultadoAnalisis.Location = new System.Drawing.Point(757, 101);
            this.btnAgregarResultadoAnalisis.Name = "btnAgregarResultadoAnalisis";
            this.btnAgregarResultadoAnalisis.Size = new System.Drawing.Size(106, 23);
            this.btnAgregarResultadoAnalisis.TabIndex = 14;
            this.btnAgregarResultadoAnalisis.Text = "Agregar resultado";
            this.btnAgregarResultadoAnalisis.UseVisualStyleBackColor = true;
            this.btnAgregarResultadoAnalisis.Click += new System.EventHandler(this.btnAgregarResultadoAnalisis_Click);
            // 
            // dgvListaResultadosAnalisis
            // 
            this.dgvListaResultadosAnalisis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaResultadosAnalisis.Location = new System.Drawing.Point(358, 101);
            this.dgvListaResultadosAnalisis.Name = "dgvListaResultadosAnalisis";
            this.dgvListaResultadosAnalisis.Size = new System.Drawing.Size(393, 154);
            this.dgvListaResultadosAnalisis.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(483, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Unidad de Medida:";
            // 
            // cboUnidadDeMedida
            // 
            this.cboUnidadDeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadDeMedida.FormattingEnabled = true;
            this.cboUnidadDeMedida.Location = new System.Drawing.Point(586, 72);
            this.cboUnidadDeMedida.Name = "cboUnidadDeMedida";
            this.cboUnidadDeMedida.Size = new System.Drawing.Size(73, 21);
            this.cboUnidadDeMedida.TabIndex = 11;
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(419, 73);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(58, 20);
            this.txtResultado.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(355, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Resultado:";
            // 
            // txtEstudioSeleccionado
            // 
            this.txtEstudioSeleccionado.Location = new System.Drawing.Point(448, 33);
            this.txtEstudioSeleccionado.Name = "txtEstudioSeleccionado";
            this.txtEstudioSeleccionado.ReadOnly = true;
            this.txtEstudioSeleccionado.Size = new System.Drawing.Size(156, 20);
            this.txtEstudioSeleccionado.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(355, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Estudio realizado";
            // 
            // txtEstudioBuscado
            // 
            this.txtEstudioBuscado.Location = new System.Drawing.Point(51, 94);
            this.txtEstudioBuscado.Name = "txtEstudioBuscado";
            this.txtEstudioBuscado.Size = new System.Drawing.Size(158, 20);
            this.txtEstudioBuscado.TabIndex = 6;
            this.txtEstudioBuscado.TextChanged += new System.EventHandler(this.txtEstudioBuscado_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Nombre";
            // 
            // btnBuscarItemEstudioLaboratorio
            // 
            this.btnBuscarItemEstudioLaboratorio.Location = new System.Drawing.Point(220, 92);
            this.btnBuscarItemEstudioLaboratorio.Name = "btnBuscarItemEstudioLaboratorio";
            this.btnBuscarItemEstudioLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarItemEstudioLaboratorio.TabIndex = 4;
            this.btnBuscarItemEstudioLaboratorio.Text = "Buscar";
            this.btnBuscarItemEstudioLaboratorio.UseVisualStyleBackColor = true;
            this.btnBuscarItemEstudioLaboratorio.Click += new System.EventHandler(this.btnBuscarItemEstudioLaboratorio_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Listado estudios";
            // 
            // dgvListadoItemsEstudioLaboratorio
            // 
            this.dgvListadoItemsEstudioLaboratorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoItemsEstudioLaboratorio.Location = new System.Drawing.Point(9, 120);
            this.dgvListadoItemsEstudioLaboratorio.Name = "dgvListadoItemsEstudioLaboratorio";
            this.dgvListadoItemsEstudioLaboratorio.ReadOnly = true;
            this.dgvListadoItemsEstudioLaboratorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoItemsEstudioLaboratorio.Size = new System.Drawing.Size(205, 135);
            this.dgvListadoItemsEstudioLaboratorio.TabIndex = 2;
            this.dgvListadoItemsEstudioLaboratorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoItemsEstudioLaboratorio_CellClick);
            // 
            // cboMetodoAnalisisLaboratorio
            // 
            this.cboMetodoAnalisisLaboratorio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMetodoAnalisisLaboratorio.FormattingEnabled = true;
            this.cboMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(55, 33);
            this.cboMetodoAnalisisLaboratorio.Name = "cboMetodoAnalisisLaboratorio";
            this.cboMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(156, 21);
            this.cboMetodoAnalisisLaboratorio.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Método";
            // 
            // btnGuardarInformeAnalisis
            // 
            this.btnGuardarInformeAnalisis.Location = new System.Drawing.Point(9, 482);
            this.btnGuardarInformeAnalisis.Name = "btnGuardarInformeAnalisis";
            this.btnGuardarInformeAnalisis.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarInformeAnalisis.TabIndex = 24;
            this.btnGuardarInformeAnalisis.Text = "Guardar";
            this.btnGuardarInformeAnalisis.UseVisualStyleBackColor = true;
            this.btnGuardarInformeAnalisis.Click += new System.EventHandler(this.btnGuardarInformeAnalisis_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(90, 482);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(171, 482);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // RegistrarLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 528);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarInformeAnalisis);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarLaboratorio";
            this.Text = "RegistrarLaboratorio";
            this.Load += new System.EventHandler(this.RegistrarLaboratorio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaResultadosAnalisis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoItemsEstudioLaboratorio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnalisisSolicitado;
        private System.Windows.Forms.Button btnAgregarInstitucion;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.MaskedTextBox mtbFechaPractica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoctorACargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboMetodoAnalisisLaboratorio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvListadoItemsEstudioLaboratorio;
        private System.Windows.Forms.TextBox txtEstudioBuscado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscarItemEstudioLaboratorio;
        private System.Windows.Forms.TextBox txtEstudioSeleccionado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboUnidadDeMedida;
        private System.Windows.Forms.Button btnAgregarResultadoAnalisis;
        private System.Windows.Forms.DataGridView dgvListaResultadosAnalisis;
        private System.Windows.Forms.Button btnGuardarInformeAnalisis;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevoAnalisis;
        private System.Windows.Forms.Button btnAgregarMetodoAnalisisLaboratorio;
        private System.Windows.Forms.Button btnAgregarUnidadMedida;
    }
}