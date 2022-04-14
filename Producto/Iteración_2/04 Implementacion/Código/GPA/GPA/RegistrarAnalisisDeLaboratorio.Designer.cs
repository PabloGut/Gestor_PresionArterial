namespace GPA
{
    partial class Registrar_Análisis_de_Laboratorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registrar_Análisis_de_Laboratorio));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAgregarAnalisis = new System.Windows.Forms.Button();
            this.panelDetalleValorReferencia = new System.Windows.Forms.Panel();
            this.cbUnidadMedidaDetalleValorReferencia = new System.Windows.Forms.CheckBox();
            this.cboUnidadMedidaDetalleValorReferencia = new System.Windows.Forms.ComboBox();
            this.dgvDetallesValorReferencia = new System.Windows.Forms.DataGridView();
            this.btnAgregarDetalleValorReferencia = new System.Windows.Forms.Button();
            this.txtDescripcionDetalleValorReferencia = new System.Windows.Forms.TextBox();
            this.txtValorMaximoDetalleValorReferencia = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtValorMinimoDetalleValorReferencia = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelDetalleItem = new System.Windows.Forms.Panel();
            this.cbUnidadMedidaValorReferencia = new System.Windows.Forms.CheckBox();
            this.cbAgregarDetalleValorReferencia = new System.Windows.Forms.CheckBox();
            this.dgvValoresReferencia = new System.Windows.Forms.DataGridView();
            this.btnAgregarValorReferencia = new System.Windows.Forms.Button();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.txtNombreDetalleItem = new System.Windows.Forms.TextBox();
            this.txtValorMaximoReferencia = new System.Windows.Forms.TextBox();
            this.txtValorMinimoReferencia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreEstudioLaboratorio = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelDetalleValorReferencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesValorReferencia)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelDetalleItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresReferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre estudio:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtNombreEstudioLaboratorio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 374);
            this.panel1.TabIndex = 3;
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(229, 316);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(52, 48);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(115, 316);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(50, 48);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAgregarAnalisis);
            this.groupBox2.Controls.Add(this.panelDetalleValorReferencia);
            this.groupBox2.Location = new System.Drawing.Point(599, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 368);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle valor de referencia";
            // 
            // btnAgregarAnalisis
            // 
            this.btnAgregarAnalisis.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarAnalisis.Image")));
            this.btnAgregarAnalisis.Location = new System.Drawing.Point(137, 310);
            this.btnAgregarAnalisis.Name = "btnAgregarAnalisis";
            this.btnAgregarAnalisis.Size = new System.Drawing.Size(43, 45);
            this.btnAgregarAnalisis.TabIndex = 15;
            this.btnAgregarAnalisis.UseVisualStyleBackColor = true;
            this.btnAgregarAnalisis.Click += new System.EventHandler(this.btnAgregarAnalisis_Click);
            // 
            // panelDetalleValorReferencia
            // 
            this.panelDetalleValorReferencia.Controls.Add(this.cbUnidadMedidaDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.cboUnidadMedidaDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.dgvDetallesValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.btnAgregarDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.txtDescripcionDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.txtValorMaximoDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.label15);
            this.panelDetalleValorReferencia.Controls.Add(this.label13);
            this.panelDetalleValorReferencia.Controls.Add(this.txtValorMinimoDetalleValorReferencia);
            this.panelDetalleValorReferencia.Controls.Add(this.label14);
            this.panelDetalleValorReferencia.Location = new System.Drawing.Point(6, 17);
            this.panelDetalleValorReferencia.Name = "panelDetalleValorReferencia";
            this.panelDetalleValorReferencia.Size = new System.Drawing.Size(340, 287);
            this.panelDetalleValorReferencia.TabIndex = 0;
            // 
            // cbUnidadMedidaDetalleValorReferencia
            // 
            this.cbUnidadMedidaDetalleValorReferencia.AutoSize = true;
            this.cbUnidadMedidaDetalleValorReferencia.Location = new System.Drawing.Point(17, 85);
            this.cbUnidadMedidaDetalleValorReferencia.Name = "cbUnidadMedidaDetalleValorReferencia";
            this.cbUnidadMedidaDetalleValorReferencia.Size = new System.Drawing.Size(113, 17);
            this.cbUnidadMedidaDetalleValorReferencia.TabIndex = 13;
            this.cbUnidadMedidaDetalleValorReferencia.Text = "Unidad de Medida";
            this.cbUnidadMedidaDetalleValorReferencia.UseVisualStyleBackColor = true;
            this.cbUnidadMedidaDetalleValorReferencia.CheckedChanged += new System.EventHandler(this.cbUnidadMedidaDetalleValorReferencia_CheckedChanged);
            // 
            // cboUnidadMedidaDetalleValorReferencia
            // 
            this.cboUnidadMedidaDetalleValorReferencia.FormattingEnabled = true;
            this.cboUnidadMedidaDetalleValorReferencia.Location = new System.Drawing.Point(140, 83);
            this.cboUnidadMedidaDetalleValorReferencia.Name = "cboUnidadMedidaDetalleValorReferencia";
            this.cboUnidadMedidaDetalleValorReferencia.Size = new System.Drawing.Size(82, 21);
            this.cboUnidadMedidaDetalleValorReferencia.TabIndex = 13;
            // 
            // dgvDetallesValorReferencia
            // 
            this.dgvDetallesValorReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesValorReferencia.Location = new System.Drawing.Point(13, 126);
            this.dgvDetallesValorReferencia.Name = "dgvDetallesValorReferencia";
            this.dgvDetallesValorReferencia.Size = new System.Drawing.Size(320, 150);
            this.dgvDetallesValorReferencia.TabIndex = 52;
            // 
            // btnAgregarDetalleValorReferencia
            // 
            this.btnAgregarDetalleValorReferencia.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarDetalleValorReferencia.Image")));
            this.btnAgregarDetalleValorReferencia.Location = new System.Drawing.Point(228, 73);
            this.btnAgregarDetalleValorReferencia.Name = "btnAgregarDetalleValorReferencia";
            this.btnAgregarDetalleValorReferencia.Size = new System.Drawing.Size(39, 38);
            this.btnAgregarDetalleValorReferencia.TabIndex = 14;
            this.btnAgregarDetalleValorReferencia.UseVisualStyleBackColor = true;
            this.btnAgregarDetalleValorReferencia.Click += new System.EventHandler(this.btnAgregarDetalleValorReferencia_Click);
            // 
            // txtDescripcionDetalleValorReferencia
            // 
            this.txtDescripcionDetalleValorReferencia.Location = new System.Drawing.Point(85, 4);
            this.txtDescripcionDetalleValorReferencia.Name = "txtDescripcionDetalleValorReferencia";
            this.txtDescripcionDetalleValorReferencia.Size = new System.Drawing.Size(226, 20);
            this.txtDescripcionDetalleValorReferencia.TabIndex = 10;
            // 
            // txtValorMaximoDetalleValorReferencia
            // 
            this.txtValorMaximoDetalleValorReferencia.Location = new System.Drawing.Point(251, 37);
            this.txtValorMaximoDetalleValorReferencia.Name = "txtValorMaximoDetalleValorReferencia";
            this.txtValorMaximoDetalleValorReferencia.Size = new System.Drawing.Size(67, 20);
            this.txtValorMaximoDetalleValorReferencia.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Descripción:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Valor Máximo:";
            // 
            // txtValorMinimoDetalleValorReferencia
            // 
            this.txtValorMinimoDetalleValorReferencia.Location = new System.Drawing.Point(85, 37);
            this.txtValorMinimoDetalleValorReferencia.Name = "txtValorMinimoDetalleValorReferencia";
            this.txtValorMinimoDetalleValorReferencia.Size = new System.Drawing.Size(68, 20);
            this.txtValorMinimoDetalleValorReferencia.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Valor Mínimo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(171, 316);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(52, 48);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelDetalleItem);
            this.groupBox1.Location = new System.Drawing.Point(6, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 269);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle items del estudio de laboratorio";
            // 
            // panelDetalleItem
            // 
            this.panelDetalleItem.Controls.Add(this.cbUnidadMedidaValorReferencia);
            this.panelDetalleItem.Controls.Add(this.cbAgregarDetalleValorReferencia);
            this.panelDetalleItem.Controls.Add(this.dgvValoresReferencia);
            this.panelDetalleItem.Controls.Add(this.btnAgregarValorReferencia);
            this.panelDetalleItem.Controls.Add(this.cboUnidadMedida);
            this.panelDetalleItem.Controls.Add(this.txtNombreDetalleItem);
            this.panelDetalleItem.Controls.Add(this.txtValorMaximoReferencia);
            this.panelDetalleItem.Controls.Add(this.txtValorMinimoReferencia);
            this.panelDetalleItem.Controls.Add(this.label12);
            this.panelDetalleItem.Controls.Add(this.label8);
            this.panelDetalleItem.Controls.Add(this.label7);
            this.panelDetalleItem.Location = new System.Drawing.Point(6, 19);
            this.panelDetalleItem.Name = "panelDetalleItem";
            this.panelDetalleItem.Size = new System.Drawing.Size(575, 237);
            this.panelDetalleItem.TabIndex = 34;
            // 
            // cbUnidadMedidaValorReferencia
            // 
            this.cbUnidadMedidaValorReferencia.AutoSize = true;
            this.cbUnidadMedidaValorReferencia.Location = new System.Drawing.Point(6, 68);
            this.cbUnidadMedidaValorReferencia.Name = "cbUnidadMedidaValorReferencia";
            this.cbUnidadMedidaValorReferencia.Size = new System.Drawing.Size(113, 17);
            this.cbUnidadMedidaValorReferencia.TabIndex = 6;
            this.cbUnidadMedidaValorReferencia.Text = "Unidad de Medida";
            this.cbUnidadMedidaValorReferencia.UseVisualStyleBackColor = true;
            this.cbUnidadMedidaValorReferencia.CheckedChanged += new System.EventHandler(this.cbUnidadMedidaValorReferencia_CheckedChanged);
            // 
            // cbAgregarDetalleValorReferencia
            // 
            this.cbAgregarDetalleValorReferencia.AutoSize = true;
            this.cbAgregarDetalleValorReferencia.Location = new System.Drawing.Point(6, 209);
            this.cbAgregarDetalleValorReferencia.Name = "cbAgregarDetalleValorReferencia";
            this.cbAgregarDetalleValorReferencia.Size = new System.Drawing.Size(188, 17);
            this.cbAgregarDetalleValorReferencia.TabIndex = 9;
            this.cbAgregarDetalleValorReferencia.Text = "Agregar detalle valor de referencia";
            this.cbAgregarDetalleValorReferencia.UseVisualStyleBackColor = true;
            this.cbAgregarDetalleValorReferencia.CheckedChanged += new System.EventHandler(this.cbAgregarDetalleValorReferencia_CheckedChanged);
            // 
            // dgvValoresReferencia
            // 
            this.dgvValoresReferencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValoresReferencia.Location = new System.Drawing.Point(6, 109);
            this.dgvValoresReferencia.Name = "dgvValoresReferencia";
            this.dgvValoresReferencia.Size = new System.Drawing.Size(563, 95);
            this.dgvValoresReferencia.TabIndex = 44;
            // 
            // btnAgregarValorReferencia
            // 
            this.btnAgregarValorReferencia.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarValorReferencia.Image")));
            this.btnAgregarValorReferencia.Location = new System.Drawing.Point(229, 56);
            this.btnAgregarValorReferencia.Name = "btnAgregarValorReferencia";
            this.btnAgregarValorReferencia.Size = new System.Drawing.Size(39, 38);
            this.btnAgregarValorReferencia.TabIndex = 8;
            this.btnAgregarValorReferencia.UseVisualStyleBackColor = true;
            this.btnAgregarValorReferencia.Click += new System.EventHandler(this.btnAgregarValorReferencia_Click);
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(141, 66);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(82, 21);
            this.cboUnidadMedida.TabIndex = 7;
            // 
            // txtNombreDetalleItem
            // 
            this.txtNombreDetalleItem.Location = new System.Drawing.Point(53, 22);
            this.txtNombreDetalleItem.Name = "txtNombreDetalleItem";
            this.txtNombreDetalleItem.Size = new System.Drawing.Size(100, 20);
            this.txtNombreDetalleItem.TabIndex = 3;
            // 
            // txtValorMaximoReferencia
            // 
            this.txtValorMaximoReferencia.Location = new System.Drawing.Point(440, 22);
            this.txtValorMaximoReferencia.Name = "txtValorMaximoReferencia";
            this.txtValorMaximoReferencia.Size = new System.Drawing.Size(100, 20);
            this.txtValorMaximoReferencia.TabIndex = 5;
            // 
            // txtValorMinimoReferencia
            // 
            this.txtValorMinimoReferencia.Location = new System.Drawing.Point(246, 22);
            this.txtValorMinimoReferencia.Name = "txtValorMinimoReferencia";
            this.txtValorMinimoReferencia.Size = new System.Drawing.Size(100, 20);
            this.txtValorMinimoReferencia.TabIndex = 4;
            this.txtValorMinimoReferencia.TextChanged += new System.EventHandler(this.txtValorMinimoReferencia_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(361, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Valor Máximo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Valor Mínimo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Nombre:";
            // 
            // txtNombreEstudioLaboratorio
            // 
            this.txtNombreEstudioLaboratorio.Location = new System.Drawing.Point(96, 19);
            this.txtNombreEstudioLaboratorio.Name = "txtNombreEstudioLaboratorio";
            this.txtNombreEstudioLaboratorio.Size = new System.Drawing.Size(232, 20);
            this.txtNombreEstudioLaboratorio.TabIndex = 1;
            // 
            // Registrar_Análisis_de_Laboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 390);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registrar_Análisis_de_Laboratorio";
            this.Text = "Registrar Análisis de Laboratorio";
            this.Load += new System.EventHandler(this.Registrar_Análisis_de_Laboratorio_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panelDetalleValorReferencia.ResumeLayout(false);
            this.panelDetalleValorReferencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesValorReferencia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panelDetalleItem.ResumeLayout(false);
            this.panelDetalleItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoresReferencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreEstudioLaboratorio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox cbAgregarDetalleValorReferencia;
        private System.Windows.Forms.Panel panelDetalleItem;
        private System.Windows.Forms.DataGridView dgvValoresReferencia;
        private System.Windows.Forms.Button btnAgregarValorReferencia;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.TextBox txtNombreDetalleItem;
        private System.Windows.Forms.TextBox txtValorMaximoReferencia;
        private System.Windows.Forms.TextBox txtValorMinimoReferencia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelDetalleValorReferencia;
        private System.Windows.Forms.ComboBox cboUnidadMedidaDetalleValorReferencia;
        private System.Windows.Forms.DataGridView dgvDetallesValorReferencia;
        private System.Windows.Forms.Button btnAgregarDetalleValorReferencia;
        private System.Windows.Forms.TextBox txtDescripcionDetalleValorReferencia;
        private System.Windows.Forms.TextBox txtValorMaximoDetalleValorReferencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtValorMinimoDetalleValorReferencia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAgregarAnalisis;
        private System.Windows.Forms.CheckBox cbUnidadMedidaValorReferencia;
        private System.Windows.Forms.CheckBox cbUnidadMedidaDetalleValorReferencia;
    }
}