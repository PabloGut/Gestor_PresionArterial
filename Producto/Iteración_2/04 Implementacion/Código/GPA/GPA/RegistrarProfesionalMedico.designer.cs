﻿namespace GPA
{
    partial class RegistrarProfesionalMedico
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
            this.grbPersonales = new System.Windows.Forms.GroupBox();
            this._txtFechaNacimiento = new System.Windows.Forms.MaskedTextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.grbSexo = new System.Windows.Forms.GroupBox();
            this.radF = new System.Windows.Forms.RadioButton();
            this.radM = new System.Windows.Forms.RadioButton();
            this._txtEmail = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this._txtNroCelular = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this._txtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.lblTelefonoFijo = new System.Windows.Forms.Label();
            this._txtApellido = new System.Windows.Forms.TextBox();
            this.lblNroCelular = new System.Windows.Forms.Label();
            this._txtNombre = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.grbAdicionales = new System.Windows.Forms.GroupBox();
            this._cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this._txtMatriculaProfesional = new System.Windows.Forms.TextBox();
            this.lblMatriculaProfesional = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.grbDomicilio = new System.Windows.Forms.GroupBox();
            this._cmbBarrio = new System.Windows.Forms.ComboBox();
            this._cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblBarrio = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this._txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this._txtDpto = new System.Windows.Forms.TextBox();
            this.lblDpto = new System.Windows.Forms.Label();
            this._txtPiso = new System.Windows.Forms.TextBox();
            this.lblPiso = new System.Windows.Forms.Label();
            this._txtNroCalle = new System.Windows.Forms.TextBox();
            this.lblNro = new System.Windows.Forms.Label();
            this._txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.grbDocumento = new System.Windows.Forms.GroupBox();
            this._txtNroDocumento = new System.Windows.Forms.TextBox();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this._cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.grbPersonales.SuspendLayout();
            this.grbSexo.SuspendLayout();
            this.grbAdicionales.SuspendLayout();
            this.grbDomicilio.SuspendLayout();
            this.grbDocumento.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbPersonales);
            this.panel1.Controls.Add(this.grbAdicionales);
            this.panel1.Controls.Add(this.grbDomicilio);
            this.panel1.Controls.Add(this.grbDocumento);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 368);
            this.panel1.TabIndex = 27;
            // 
            // grbPersonales
            // 
            this.grbPersonales.Controls.Add(this._txtFechaNacimiento);
            this.grbPersonales.Controls.Add(this.lblFechaNacimiento);
            this.grbPersonales.Controls.Add(this.grbSexo);
            this.grbPersonales.Controls.Add(this._txtEmail);
            this.grbPersonales.Controls.Add(this.lblNombre);
            this.grbPersonales.Controls.Add(this._txtNroCelular);
            this.grbPersonales.Controls.Add(this.lblApellido);
            this.grbPersonales.Controls.Add(this._txtTelefonoFijo);
            this.grbPersonales.Controls.Add(this.lblTelefonoFijo);
            this.grbPersonales.Controls.Add(this._txtApellido);
            this.grbPersonales.Controls.Add(this.lblNroCelular);
            this.grbPersonales.Controls.Add(this._txtNombre);
            this.grbPersonales.Controls.Add(this.lblEmail);
            this.grbPersonales.Location = new System.Drawing.Point(11, 93);
            this.grbPersonales.Name = "grbPersonales";
            this.grbPersonales.Size = new System.Drawing.Size(260, 208);
            this.grbPersonales.TabIndex = 12;
            this.grbPersonales.TabStop = false;
            this.grbPersonales.Text = "Datos Personales";
            // 
            // _txtFechaNacimiento
            // 
            this._txtFechaNacimiento.Culture = new System.Globalization.CultureInfo("es-CR");
            this._txtFechaNacimiento.Location = new System.Drawing.Point(123, 183);
            this._txtFechaNacimiento.Mask = "00/00/0000";
            this._txtFechaNacimiento.Name = "_txtFechaNacimiento";
            this._txtFechaNacimiento.Size = new System.Drawing.Size(80, 20);
            this._txtFechaNacimiento.TabIndex = 15;
            this._txtFechaNacimiento.ValidatingType = typeof(System.DateTime);
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(6, 186);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(111, 13);
            this.lblFechaNacimiento.TabIndex = 14;
            this.lblFechaNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // grbSexo
            // 
            this.grbSexo.Controls.Add(this.radF);
            this.grbSexo.Controls.Add(this.radM);
            this.grbSexo.Location = new System.Drawing.Point(89, 140);
            this.grbSexo.Name = "grbSexo";
            this.grbSexo.Size = new System.Drawing.Size(156, 43);
            this.grbSexo.TabIndex = 13;
            this.grbSexo.TabStop = false;
            this.grbSexo.Text = "Sexo";
            // 
            // radF
            // 
            this.radF.AutoSize = true;
            this.radF.Location = new System.Drawing.Point(85, 19);
            this.radF.Name = "radF";
            this.radF.Size = new System.Drawing.Size(71, 17);
            this.radF.TabIndex = 1;
            this.radF.Text = "Femenino";
            this.radF.UseVisualStyleBackColor = true;
            // 
            // radM
            // 
            this.radM.AutoSize = true;
            this.radM.Checked = true;
            this.radM.Location = new System.Drawing.Point(6, 19);
            this.radM.Name = "radM";
            this.radM.Size = new System.Drawing.Size(73, 17);
            this.radM.TabIndex = 0;
            this.radM.TabStop = true;
            this.radM.Text = "Masculino";
            this.radM.UseVisualStyleBackColor = true;
            // 
            // _txtEmail
            // 
            this._txtEmail.Location = new System.Drawing.Point(124, 115);
            this._txtEmail.Name = "_txtEmail";
            this._txtEmail.Size = new System.Drawing.Size(121, 20);
            this._txtEmail.TabIndex = 11;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(70, 17);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // _txtNroCelular
            // 
            this._txtNroCelular.Location = new System.Drawing.Point(124, 91);
            this._txtNroCelular.Name = "_txtNroCelular";
            this._txtNroCelular.Size = new System.Drawing.Size(121, 20);
            this._txtNroCelular.TabIndex = 10;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(70, 43);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";
            // 
            // _txtTelefonoFijo
            // 
            this._txtTelefonoFijo.Location = new System.Drawing.Point(124, 68);
            this._txtTelefonoFijo.Name = "_txtTelefonoFijo";
            this._txtTelefonoFijo.Size = new System.Drawing.Size(121, 20);
            this._txtTelefonoFijo.TabIndex = 9;
            // 
            // lblTelefonoFijo
            // 
            this.lblTelefonoFijo.AutoSize = true;
            this.lblTelefonoFijo.Location = new System.Drawing.Point(46, 71);
            this.lblTelefonoFijo.Name = "lblTelefonoFijo";
            this.lblTelefonoFijo.Size = new System.Drawing.Size(71, 13);
            this.lblTelefonoFijo.TabIndex = 4;
            this.lblTelefonoFijo.Text = "Teléfono Fijo:";
            // 
            // _txtApellido
            // 
            this._txtApellido.Location = new System.Drawing.Point(124, 40);
            this._txtApellido.Name = "_txtApellido";
            this._txtApellido.Size = new System.Drawing.Size(121, 20);
            this._txtApellido.TabIndex = 8;
            // 
            // lblNroCelular
            // 
            this.lblNroCelular.AutoSize = true;
            this.lblNroCelular.Location = new System.Drawing.Point(20, 94);
            this.lblNroCelular.Name = "lblNroCelular";
            this.lblNroCelular.Size = new System.Drawing.Size(97, 13);
            this.lblNroCelular.TabIndex = 5;
            this.lblNroCelular.Text = "Número de Celular:";
            // 
            // _txtNombre
            // 
            this._txtNombre.Location = new System.Drawing.Point(124, 14);
            this._txtNombre.Name = "_txtNombre";
            this._txtNombre.Size = new System.Drawing.Size(121, 20);
            this._txtNombre.TabIndex = 7;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(79, 118);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "E-mail:";
            // 
            // grbAdicionales
            // 
            this.grbAdicionales.Controls.Add(this._cmbEspecialidad);
            this.grbAdicionales.Controls.Add(this._txtMatriculaProfesional);
            this.grbAdicionales.Controls.Add(this.lblMatriculaProfesional);
            this.grbAdicionales.Controls.Add(this.lblEspecialidad);
            this.grbAdicionales.Location = new System.Drawing.Point(12, 307);
            this.grbAdicionales.Name = "grbAdicionales";
            this.grbAdicionales.Size = new System.Drawing.Size(504, 49);
            this.grbAdicionales.TabIndex = 2;
            this.grbAdicionales.TabStop = false;
            this.grbAdicionales.Text = "Datos Adicionales del Profesional Médico";
            // 
            // _cmbEspecialidad
            // 
            this._cmbEspecialidad.FormattingEnabled = true;
            this._cmbEspecialidad.Location = new System.Drawing.Point(82, 22);
            this._cmbEspecialidad.Name = "_cmbEspecialidad";
            this._cmbEspecialidad.Size = new System.Drawing.Size(121, 21);
            this._cmbEspecialidad.TabIndex = 14;
            // 
            // _txtMatriculaProfesional
            // 
            this._txtMatriculaProfesional.Location = new System.Drawing.Point(323, 22);
            this._txtMatriculaProfesional.Name = "_txtMatriculaProfesional";
            this._txtMatriculaProfesional.Size = new System.Drawing.Size(83, 20);
            this._txtMatriculaProfesional.TabIndex = 11;
            // 
            // lblMatriculaProfesional
            // 
            this.lblMatriculaProfesional.AutoSize = true;
            this.lblMatriculaProfesional.Location = new System.Drawing.Point(209, 25);
            this.lblMatriculaProfesional.Name = "lblMatriculaProfesional";
            this.lblMatriculaProfesional.Size = new System.Drawing.Size(110, 13);
            this.lblMatriculaProfesional.TabIndex = 10;
            this.lblMatriculaProfesional.Text = "Matrícula Profesional:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(6, 25);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 0;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // grbDomicilio
            // 
            this.grbDomicilio.Controls.Add(this._cmbBarrio);
            this.grbDomicilio.Controls.Add(this._cmbLocalidad);
            this.grbDomicilio.Controls.Add(this.lblBarrio);
            this.grbDomicilio.Controls.Add(this.lblLocalidad);
            this.grbDomicilio.Controls.Add(this._txtCodigoPostal);
            this.grbDomicilio.Controls.Add(this.lblCodigoPostal);
            this.grbDomicilio.Controls.Add(this._txtDpto);
            this.grbDomicilio.Controls.Add(this.lblDpto);
            this.grbDomicilio.Controls.Add(this._txtPiso);
            this.grbDomicilio.Controls.Add(this.lblPiso);
            this.grbDomicilio.Controls.Add(this._txtNroCalle);
            this.grbDomicilio.Controls.Add(this.lblNro);
            this.grbDomicilio.Controls.Add(this._txtCalle);
            this.grbDomicilio.Controls.Add(this.lblCalle);
            this.grbDomicilio.Location = new System.Drawing.Point(278, 13);
            this.grbDomicilio.Name = "grbDomicilio";
            this.grbDomicilio.Size = new System.Drawing.Size(238, 226);
            this.grbDomicilio.TabIndex = 1;
            this.grbDomicilio.TabStop = false;
            this.grbDomicilio.Text = "Datos del Domicilio";
            // 
            // _cmbBarrio
            // 
            this._cmbBarrio.FormattingEnabled = true;
            this._cmbBarrio.Location = new System.Drawing.Point(63, 132);
            this._cmbBarrio.Name = "_cmbBarrio";
            this._cmbBarrio.Size = new System.Drawing.Size(169, 21);
            this._cmbBarrio.TabIndex = 25;
            // 
            // _cmbLocalidad
            // 
            this._cmbLocalidad.FormattingEnabled = true;
            this._cmbLocalidad.Location = new System.Drawing.Point(63, 105);
            this._cmbLocalidad.Name = "_cmbLocalidad";
            this._cmbLocalidad.Size = new System.Drawing.Size(169, 21);
            this._cmbLocalidad.TabIndex = 24;
            this._cmbLocalidad.SelectedIndexChanged += new System.EventHandler(this._cmbLocalidad_SelectedIndexChanged);
            // 
            // lblBarrio
            // 
            this.lblBarrio.AutoSize = true;
            this.lblBarrio.Location = new System.Drawing.Point(25, 135);
            this.lblBarrio.Name = "lblBarrio";
            this.lblBarrio.Size = new System.Drawing.Size(37, 13);
            this.lblBarrio.TabIndex = 23;
            this.lblBarrio.Text = "Barrio:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(6, 108);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(56, 13);
            this.lblLocalidad.TabIndex = 22;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // _txtCodigoPostal
            // 
            this._txtCodigoPostal.Location = new System.Drawing.Point(147, 79);
            this._txtCodigoPostal.Name = "_txtCodigoPostal";
            this._txtCodigoPostal.Size = new System.Drawing.Size(37, 20);
            this._txtCodigoPostal.TabIndex = 21;
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(66, 82);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.lblCodigoPostal.TabIndex = 20;
            this.lblCodigoPostal.Text = "Código Postal:";
            // 
            // _txtDpto
            // 
            this._txtDpto.Location = new System.Drawing.Point(201, 49);
            this._txtDpto.Name = "_txtDpto";
            this._txtDpto.Size = new System.Drawing.Size(31, 20);
            this._txtDpto.TabIndex = 19;
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(167, 52);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(33, 13);
            this.lblDpto.TabIndex = 18;
            this.lblDpto.Text = "Dpto:";
            // 
            // _txtPiso
            // 
            this._txtPiso.Location = new System.Drawing.Point(138, 49);
            this._txtPiso.Name = "_txtPiso";
            this._txtPiso.Size = new System.Drawing.Size(23, 20);
            this._txtPiso.TabIndex = 17;
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(106, 52);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(30, 13);
            this.lblPiso.TabIndex = 16;
            this.lblPiso.Text = "Piso:";
            // 
            // _txtNroCalle
            // 
            this._txtNroCalle.Location = new System.Drawing.Point(59, 49);
            this._txtNroCalle.Name = "_txtNroCalle";
            this._txtNroCalle.Size = new System.Drawing.Size(41, 20);
            this._txtNroCalle.TabIndex = 15;
            // 
            // lblNro
            // 
            this.lblNro.AutoSize = true;
            this.lblNro.Location = new System.Drawing.Point(6, 52);
            this.lblNro.Name = "lblNro";
            this.lblNro.Size = new System.Drawing.Size(47, 13);
            this.lblNro.TabIndex = 14;
            this.lblNro.Text = "Número:";
            // 
            // _txtCalle
            // 
            this._txtCalle.Location = new System.Drawing.Point(59, 19);
            this._txtCalle.Name = "_txtCalle";
            this._txtCalle.Size = new System.Drawing.Size(173, 20);
            this._txtCalle.TabIndex = 13;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(20, 22);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 12;
            this.lblCalle.Text = "Calle:";
            // 
            // grbDocumento
            // 
            this.grbDocumento.Controls.Add(this._txtNroDocumento);
            this.grbDocumento.Controls.Add(this.lblNroDocumento);
            this.grbDocumento.Controls.Add(this._cmbTipoDocumento);
            this.grbDocumento.Controls.Add(this.lblTipoDocumento);
            this.grbDocumento.Location = new System.Drawing.Point(12, 13);
            this.grbDocumento.Name = "grbDocumento";
            this.grbDocumento.Size = new System.Drawing.Size(260, 74);
            this.grbDocumento.TabIndex = 0;
            this.grbDocumento.TabStop = false;
            this.grbDocumento.Text = "Datos del Documento";
            // 
            // _txtNroDocumento
            // 
            this._txtNroDocumento.Location = new System.Drawing.Point(123, 46);
            this._txtNroDocumento.Name = "_txtNroDocumento";
            this._txtNroDocumento.Size = new System.Drawing.Size(121, 20);
            this._txtNroDocumento.TabIndex = 1;
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.Location = new System.Drawing.Point(-4, 49);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(120, 13);
            this.lblNroDocumento.TabIndex = 1;
            this.lblNroDocumento.Text = "Número de Documento:";
            // 
            // _cmbTipoDocumento
            // 
            this._cmbTipoDocumento.FormattingEnabled = true;
            this._cmbTipoDocumento.Location = new System.Drawing.Point(123, 13);
            this._cmbTipoDocumento.Name = "_cmbTipoDocumento";
            this._cmbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this._cmbTipoDocumento.TabIndex = 1;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(12, 16);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDocumento.TabIndex = 1;
            this.lblTipoDocumento.Text = "Tipo de Documento:";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(331, 393);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(250, 393);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(169, 393);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 24;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // RegistrarProfesionalMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 428);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "RegistrarProfesionalMedico";
            this.Text = "Registrar Profesional Medico";
            this.panel1.ResumeLayout(false);
            this.grbPersonales.ResumeLayout(false);
            this.grbPersonales.PerformLayout();
            this.grbSexo.ResumeLayout(false);
            this.grbSexo.PerformLayout();
            this.grbAdicionales.ResumeLayout(false);
            this.grbAdicionales.PerformLayout();
            this.grbDomicilio.ResumeLayout(false);
            this.grbDomicilio.PerformLayout();
            this.grbDocumento.ResumeLayout(false);
            this.grbDocumento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbAdicionales;
        private System.Windows.Forms.ComboBox _cmbEspecialidad;

        public System.Windows.Forms.ComboBox cmbEspecialidad
        {
            get { return _cmbEspecialidad; }
            set { _cmbEspecialidad = value; }
        }
        private System.Windows.Forms.TextBox _txtMatriculaProfesional;

        public System.Windows.Forms.TextBox txtMatriculaProfesional
        {
            get { return _txtMatriculaProfesional; }
            set { _txtMatriculaProfesional = value; }
        }
        private System.Windows.Forms.Label lblMatriculaProfesional;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.GroupBox grbDomicilio;
        private System.Windows.Forms.ComboBox _cmbBarrio;

        public System.Windows.Forms.ComboBox cmbBarrio
        {
            get { return _cmbBarrio; }
            set { _cmbBarrio = value; }
        }
        private System.Windows.Forms.ComboBox _cmbLocalidad;

        public System.Windows.Forms.ComboBox cmbLocalidad
        {
            get { return _cmbLocalidad; }
            set { _cmbLocalidad = value; }
        }
        private System.Windows.Forms.Label lblBarrio;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.TextBox _txtCodigoPostal;

        public System.Windows.Forms.TextBox txtCodigoPostal
        {
            get { return _txtCodigoPostal; }
            set { _txtCodigoPostal = value; }
        }
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.TextBox _txtDpto;

        public System.Windows.Forms.TextBox txtDpto
        {
            get { return _txtDpto; }
            set { _txtDpto = value; }
        }
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.TextBox _txtPiso;

        public System.Windows.Forms.TextBox txtPiso
        {
            get { return _txtPiso; }
            set { _txtPiso = value; }
        }
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.TextBox _txtNroCalle;

        public System.Windows.Forms.TextBox txtNroCalle
        {
            get { return _txtNroCalle; }
            set { _txtNroCalle = value; }
        }
        private System.Windows.Forms.Label lblNro;
        private System.Windows.Forms.TextBox _txtCalle;

        public System.Windows.Forms.TextBox txtCalle
        {
            get { return _txtCalle; }
            set { _txtCalle = value; }
        }
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.GroupBox grbDocumento;
        private System.Windows.Forms.TextBox _txtEmail;

        public System.Windows.Forms.TextBox txtEmail
        {
            get { return _txtEmail; }
            set { _txtEmail = value; }
        }
        private System.Windows.Forms.TextBox _txtNroCelular;

        public System.Windows.Forms.TextBox txtNroCelular
        {
            get { return _txtNroCelular; }
            set { _txtNroCelular = value; }
        }
        private System.Windows.Forms.TextBox _txtTelefonoFijo;

        public System.Windows.Forms.TextBox txtTelefonoFijo
        {
            get { return _txtTelefonoFijo; }
            set { _txtTelefonoFijo = value; }
        }
        private System.Windows.Forms.TextBox _txtApellido;

        public System.Windows.Forms.TextBox txtApellido
        {
            get { return _txtApellido; }
            set { _txtApellido = value; }
        }
        private System.Windows.Forms.TextBox _txtNombre;

        public System.Windows.Forms.TextBox txtNombre
        {
            get { return _txtNombre; }
            set { _txtNombre = value; }
        }
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNroCelular;
        private System.Windows.Forms.Label lblTelefonoFijo;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox _txtNroDocumento;

        public System.Windows.Forms.TextBox txtNroDocumento
        {
            get { return _txtNroDocumento; }
            set { _txtNroDocumento = value; }
        }
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.ComboBox _cmbTipoDocumento;

        public System.Windows.Forms.ComboBox cmbTipoDocumento
        {
            get { return _cmbTipoDocumento; }
            set { _cmbTipoDocumento = value; }
        }
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox grbPersonales;
        private System.Windows.Forms.GroupBox grbSexo;
        private System.Windows.Forms.RadioButton radF;
        private System.Windows.Forms.RadioButton radM;
        private System.Windows.Forms.MaskedTextBox _txtFechaNacimiento;

        public System.Windows.Forms.MaskedTextBox txtFechaNacimiento
        {
            get { return _txtFechaNacimiento; }
            set { _txtFechaNacimiento = value; }
        }
        private System.Windows.Forms.Label lblFechaNacimiento;
    }
}