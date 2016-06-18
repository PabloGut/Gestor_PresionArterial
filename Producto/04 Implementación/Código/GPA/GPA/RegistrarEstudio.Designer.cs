namespace GPA
{
    partial class RegistrarEstudio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscarInstitucion = new System.Windows.Forms.Button();
            this.btnRegInstitucion = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.cboInstitucion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbFechaEstudio = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInforme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDoctorACargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreEstudio = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBuscarInstitucion);
            this.groupBox3.Controls.Add(this.btnRegInstitucion);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Controls.Add(this.txtCalle);
            this.groupBox3.Controls.Add(this.cboInstitucion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 140);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Institución donde se realizó el estudio";
            // 
            // btnBuscarInstitucion
            // 
            this.btnBuscarInstitucion.Location = new System.Drawing.Point(260, 63);
            this.btnBuscarInstitucion.Name = "btnBuscarInstitucion";
            this.btnBuscarInstitucion.Size = new System.Drawing.Size(111, 39);
            this.btnBuscarInstitucion.TabIndex = 9;
            this.btnBuscarInstitucion.Text = "Buscar ";
            this.btnBuscarInstitucion.UseVisualStyleBackColor = true;
            this.btnBuscarInstitucion.Click += new System.EventHandler(this.btnBuscarInstitucion_Click);
            // 
            // btnRegInstitucion
            // 
            this.btnRegInstitucion.Location = new System.Drawing.Point(260, 13);
            this.btnRegInstitucion.Name = "btnRegInstitucion";
            this.btnRegInstitucion.Size = new System.Drawing.Size(111, 39);
            this.btnRegInstitucion.TabIndex = 6;
            this.btnRegInstitucion.Text = "Registrar Institución";
            this.btnRegInstitucion.UseVisualStyleBackColor = true;
            this.btnRegInstitucion.Click += new System.EventHandler(this.btnRegInstitucion_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(56, 96);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(197, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(42, 63);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(211, 20);
            this.txtCalle.TabIndex = 4;
            // 
            // cboInstitucion
            // 
            this.cboInstitucion.FormattingEnabled = true;
            this.cboInstitucion.Location = new System.Drawing.Point(132, 23);
            this.cboInstitucion.Name = "cboInstitucion";
            this.cboInstitucion.Size = new System.Drawing.Size(121, 21);
            this.cboInstitucion.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Número";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Calle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nombre de la institución";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSalir);
            this.panel2.Controls.Add(this.btnCancelar);
            this.panel2.Controls.Add(this.btnAceptar);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(567, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 379);
            this.panel2.TabIndex = 6;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(135, 278);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 48);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(135, 223);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 48);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(135, 169);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(97, 48);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtbFechaEstudio);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDoctorACargo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombreEstudio);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 367);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del estudio";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // mtbFechaEstudio
            // 
            this.mtbFechaEstudio.Location = new System.Drawing.Point(114, 67);
            this.mtbFechaEstudio.Mask = "00/00/0000";
            this.mtbFechaEstudio.Name = "mtbFechaEstudio";
            this.mtbFechaEstudio.Size = new System.Drawing.Size(87, 20);
            this.mtbFechaEstudio.TabIndex = 10;
            this.mtbFechaEstudio.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInforme);
            this.groupBox2.Location = new System.Drawing.Point(6, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 157);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informe del estudio";
            // 
            // txtInforme
            // 
            this.txtInforme.Location = new System.Drawing.Point(6, 19);
            this.txtInforme.Multiline = true;
            this.txtInforme.Name = "txtInforme";
            this.txtInforme.Size = new System.Drawing.Size(508, 132);
            this.txtInforme.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre del doctor a cargo";
            // 
            // txtDoctorACargo
            // 
            this.txtDoctorACargo.Location = new System.Drawing.Point(142, 113);
            this.txtDoctorACargo.Name = "txtDoctorACargo";
            this.txtDoctorACargo.Size = new System.Drawing.Size(183, 20);
            this.txtDoctorACargo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de realización";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del estudio";
            // 
            // txtNombreEstudio
            // 
            this.txtNombreEstudio.Location = new System.Drawing.Point(104, 23);
            this.txtNombreEstudio.Name = "txtNombreEstudio";
            this.txtNombreEstudio.Size = new System.Drawing.Size(221, 20);
            this.txtNombreEstudio.TabIndex = 3;
            // 
            // RegistrarEstudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 411);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegistrarEstudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Estudio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscarInstitucion;
        private System.Windows.Forms.Button btnRegInstitucion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.ComboBox cboInstitucion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mtbFechaEstudio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInforme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDoctorACargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreEstudio;
    }
}

