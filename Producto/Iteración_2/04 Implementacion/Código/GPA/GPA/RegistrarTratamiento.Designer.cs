namespace GPA
{
    partial class RegistrarTratamiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarTratamiento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTerapia = new System.Windows.Forms.ComboBox();
            this.txtIndicacionesTerapia = new System.Windows.Forms.TextBox();
            this.mtbFechaInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtMotivoInicio = new System.Windows.Forms.TextBox();
            this.grbTratamientoFarmacologico = new System.Windows.Forms.GroupBox();
            this.btnAgregarTratamientoMedicamento = new System.Windows.Forms.Button();
            this.cboCantidadComprimidos = new System.Windows.Forms.ComboBox();
            this.cboConcentracion = new System.Windows.Forms.ComboBox();
            this.CantidadComprimidos = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.txtDenominadorCantidad3 = new System.Windows.Forms.TextBox();
            this.txtNumeradorCantidad3 = new System.Windows.Forms.TextBox();
            this.txtDenominadorCantidad1 = new System.Windows.Forms.TextBox();
            this.txtNumeradorCantidad1 = new System.Windows.Forms.TextBox();
            this.txtDenominadorCantidad2 = new System.Windows.Forms.TextBox();
            this.txtNumeradorCantidad2 = new System.Windows.Forms.TextBox();
            this.cboPresentacionMedicamento1 = new System.Windows.Forms.ComboBox();
            this.mtbHora3 = new System.Windows.Forms.MaskedTextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.mtbHora2 = new System.Windows.Forms.MaskedTextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.mtbHora1 = new System.Windows.Forms.MaskedTextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.cboMomentoDia1 = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.cboMomentoDia2 = new System.Windows.Forms.ComboBox();
            this.cboPresentacionMedicamento3 = new System.Windows.Forms.ComboBox();
            this.cboMomentoDia3 = new System.Windows.Forms.ComboBox();
            this.cboPresentacionMedicamento2 = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.cboFrecuencia = new System.Windows.Forms.ComboBox();
            this.cboPresentacionMedicamento = new System.Windows.Forms.ComboBox();
            this.cboFormaAdministración = new System.Windows.Forms.ComboBox();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.cboNombreComercial = new System.Windows.Forms.ComboBox();
            this.cboNombreGenerico = new System.Windows.Forms.ComboBox();
            this.label90 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarTerapia = new System.Windows.Forms.Button();
            this.dgvListaTratamientos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.grbTratamientoFarmacologico.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTratamientos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terapia:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Indicaciones:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Motivo inicio:";
            // 
            // cboTerapia
            // 
            this.cboTerapia.FormattingEnabled = true;
            this.cboTerapia.Location = new System.Drawing.Point(64, 12);
            this.cboTerapia.Name = "cboTerapia";
            this.cboTerapia.Size = new System.Drawing.Size(214, 21);
            this.cboTerapia.TabIndex = 4;
            this.cboTerapia.SelectedIndexChanged += new System.EventHandler(this.cboTerapia_SelectedIndexChanged);
            // 
            // txtIndicacionesTerapia
            // 
            this.txtIndicacionesTerapia.Location = new System.Drawing.Point(85, 39);
            this.txtIndicacionesTerapia.Multiline = true;
            this.txtIndicacionesTerapia.Name = "txtIndicacionesTerapia";
            this.txtIndicacionesTerapia.Size = new System.Drawing.Size(588, 34);
            this.txtIndicacionesTerapia.TabIndex = 5;
            // 
            // mtbFechaInicio
            // 
            this.mtbFechaInicio.Location = new System.Drawing.Point(381, 12);
            this.mtbFechaInicio.Name = "mtbFechaInicio";
            this.mtbFechaInicio.Size = new System.Drawing.Size(131, 20);
            this.mtbFechaInicio.TabIndex = 6;
            this.mtbFechaInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtMotivoInicio
            // 
            this.txtMotivoInicio.Location = new System.Drawing.Point(85, 79);
            this.txtMotivoInicio.Multiline = true;
            this.txtMotivoInicio.Name = "txtMotivoInicio";
            this.txtMotivoInicio.Size = new System.Drawing.Size(588, 36);
            this.txtMotivoInicio.TabIndex = 7;
            // 
            // grbTratamientoFarmacologico
            // 
            this.grbTratamientoFarmacologico.Controls.Add(this.btnAgregarTratamientoMedicamento);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboCantidadComprimidos);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboConcentracion);
            this.grbTratamientoFarmacologico.Controls.Add(this.CantidadComprimidos);
            this.grbTratamientoFarmacologico.Controls.Add(this.groupBox17);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboFrecuencia);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboPresentacionMedicamento);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboFormaAdministración);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboUnidadMedida);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboNombreComercial);
            this.grbTratamientoFarmacologico.Controls.Add(this.cboNombreGenerico);
            this.grbTratamientoFarmacologico.Controls.Add(this.label90);
            this.grbTratamientoFarmacologico.Controls.Add(this.label89);
            this.grbTratamientoFarmacologico.Controls.Add(this.label85);
            this.grbTratamientoFarmacologico.Controls.Add(this.label83);
            this.grbTratamientoFarmacologico.Controls.Add(this.label82);
            this.grbTratamientoFarmacologico.Controls.Add(this.label81);
            this.grbTratamientoFarmacologico.Location = new System.Drawing.Point(12, 171);
            this.grbTratamientoFarmacologico.Name = "grbTratamientoFarmacologico";
            this.grbTratamientoFarmacologico.Size = new System.Drawing.Size(661, 280);
            this.grbTratamientoFarmacologico.TabIndex = 8;
            this.grbTratamientoFarmacologico.TabStop = false;
            this.grbTratamientoFarmacologico.Text = "Tratamiento Farmacológico";
            // 
            // btnAgregarTratamientoMedicamento
            // 
            this.btnAgregarTratamientoMedicamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTratamientoMedicamento.Image")));
            this.btnAgregarTratamientoMedicamento.Location = new System.Drawing.Point(261, 234);
            this.btnAgregarTratamientoMedicamento.Name = "btnAgregarTratamientoMedicamento";
            this.btnAgregarTratamientoMedicamento.Size = new System.Drawing.Size(43, 45);
            this.btnAgregarTratamientoMedicamento.TabIndex = 1;
            this.btnAgregarTratamientoMedicamento.UseVisualStyleBackColor = true;
            this.btnAgregarTratamientoMedicamento.Click += new System.EventHandler(this.btnAgregarTratamientoMedicamento_Click);
            // 
            // cboCantidadComprimidos
            // 
            this.cboCantidadComprimidos.FormattingEnabled = true;
            this.cboCantidadComprimidos.Location = new System.Drawing.Point(476, 73);
            this.cboCantidadComprimidos.Name = "cboCantidadComprimidos";
            this.cboCantidadComprimidos.Size = new System.Drawing.Size(49, 21);
            this.cboCantidadComprimidos.TabIndex = 76;
            // 
            // cboConcentracion
            // 
            this.cboConcentracion.FormattingEnabled = true;
            this.cboConcentracion.Location = new System.Drawing.Point(416, 18);
            this.cboConcentracion.Name = "cboConcentracion";
            this.cboConcentracion.Size = new System.Drawing.Size(49, 21);
            this.cboConcentracion.TabIndex = 75;
            // 
            // CantidadComprimidos
            // 
            this.CantidadComprimidos.AutoSize = true;
            this.CantidadComprimidos.Location = new System.Drawing.Point(334, 78);
            this.CantidadComprimidos.Name = "CantidadComprimidos";
            this.CantidadComprimidos.Size = new System.Drawing.Size(110, 13);
            this.CantidadComprimidos.TabIndex = 73;
            this.CantidadComprimidos.Text = "Cantidad comprimidos";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.txtDenominadorCantidad3);
            this.groupBox17.Controls.Add(this.txtNumeradorCantidad3);
            this.groupBox17.Controls.Add(this.txtDenominadorCantidad1);
            this.groupBox17.Controls.Add(this.txtNumeradorCantidad1);
            this.groupBox17.Controls.Add(this.txtDenominadorCantidad2);
            this.groupBox17.Controls.Add(this.txtNumeradorCantidad2);
            this.groupBox17.Controls.Add(this.cboPresentacionMedicamento1);
            this.groupBox17.Controls.Add(this.mtbHora3);
            this.groupBox17.Controls.Add(this.label86);
            this.groupBox17.Controls.Add(this.mtbHora2);
            this.groupBox17.Controls.Add(this.label87);
            this.groupBox17.Controls.Add(this.mtbHora1);
            this.groupBox17.Controls.Add(this.label91);
            this.groupBox17.Controls.Add(this.label103);
            this.groupBox17.Controls.Add(this.cboMomentoDia1);
            this.groupBox17.Controls.Add(this.label102);
            this.groupBox17.Controls.Add(this.cboMomentoDia2);
            this.groupBox17.Controls.Add(this.cboPresentacionMedicamento3);
            this.groupBox17.Controls.Add(this.cboMomentoDia3);
            this.groupBox17.Controls.Add(this.cboPresentacionMedicamento2);
            this.groupBox17.Controls.Add(this.label92);
            this.groupBox17.Controls.Add(this.label96);
            this.groupBox17.Controls.Add(this.label94);
            this.groupBox17.Controls.Add(this.label93);
            this.groupBox17.Location = new System.Drawing.Point(6, 121);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(647, 107);
            this.groupBox17.TabIndex = 56;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Régimen de consumo";
            // 
            // txtDenominadorCantidad3
            // 
            this.txtDenominadorCantidad3.Location = new System.Drawing.Point(398, 74);
            this.txtDenominadorCantidad3.Name = "txtDenominadorCantidad3";
            this.txtDenominadorCantidad3.Size = new System.Drawing.Size(32, 20);
            this.txtDenominadorCantidad3.TabIndex = 62;
            // 
            // txtNumeradorCantidad3
            // 
            this.txtNumeradorCantidad3.Location = new System.Drawing.Point(360, 74);
            this.txtNumeradorCantidad3.Name = "txtNumeradorCantidad3";
            this.txtNumeradorCantidad3.Size = new System.Drawing.Size(32, 20);
            this.txtNumeradorCantidad3.TabIndex = 61;
            // 
            // txtDenominadorCantidad1
            // 
            this.txtDenominadorCantidad1.Location = new System.Drawing.Point(398, 15);
            this.txtDenominadorCantidad1.Name = "txtDenominadorCantidad1";
            this.txtDenominadorCantidad1.Size = new System.Drawing.Size(32, 20);
            this.txtDenominadorCantidad1.TabIndex = 60;
            // 
            // txtNumeradorCantidad1
            // 
            this.txtNumeradorCantidad1.Location = new System.Drawing.Point(360, 14);
            this.txtNumeradorCantidad1.Name = "txtNumeradorCantidad1";
            this.txtNumeradorCantidad1.Size = new System.Drawing.Size(32, 20);
            this.txtNumeradorCantidad1.TabIndex = 59;
            // 
            // txtDenominadorCantidad2
            // 
            this.txtDenominadorCantidad2.Location = new System.Drawing.Point(398, 44);
            this.txtDenominadorCantidad2.Name = "txtDenominadorCantidad2";
            this.txtDenominadorCantidad2.Size = new System.Drawing.Size(32, 20);
            this.txtDenominadorCantidad2.TabIndex = 58;
            // 
            // txtNumeradorCantidad2
            // 
            this.txtNumeradorCantidad2.Location = new System.Drawing.Point(360, 44);
            this.txtNumeradorCantidad2.Name = "txtNumeradorCantidad2";
            this.txtNumeradorCantidad2.Size = new System.Drawing.Size(32, 20);
            this.txtNumeradorCantidad2.TabIndex = 57;
            // 
            // cboPresentacionMedicamento1
            // 
            this.cboPresentacionMedicamento1.FormattingEnabled = true;
            this.cboPresentacionMedicamento1.Location = new System.Drawing.Point(436, 14);
            this.cboPresentacionMedicamento1.Name = "cboPresentacionMedicamento1";
            this.cboPresentacionMedicamento1.Size = new System.Drawing.Size(121, 21);
            this.cboPresentacionMedicamento1.TabIndex = 46;
            // 
            // mtbHora3
            // 
            this.mtbHora3.Location = new System.Drawing.Point(599, 74);
            this.mtbHora3.Mask = "00:00";
            this.mtbHora3.Name = "mtbHora3";
            this.mtbHora3.Size = new System.Drawing.Size(38, 20);
            this.mtbHora3.TabIndex = 55;
            this.mtbHora3.ValidatingType = typeof(System.DateTime);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(5, 51);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(87, 13);
            this.label86.TabIndex = 6;
            this.label86.Text = "Momento del día";
            // 
            // mtbHora2
            // 
            this.mtbHora2.Location = new System.Drawing.Point(599, 44);
            this.mtbHora2.Mask = "00:00";
            this.mtbHora2.Name = "mtbHora2";
            this.mtbHora2.Size = new System.Drawing.Size(38, 20);
            this.mtbHora2.TabIndex = 54;
            this.mtbHora2.ValidatingType = typeof(System.DateTime);
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(5, 20);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(87, 13);
            this.label87.TabIndex = 7;
            this.label87.Text = "Momento del día";
            // 
            // mtbHora1
            // 
            this.mtbHora1.Location = new System.Drawing.Point(599, 13);
            this.mtbHora1.Mask = "00:00";
            this.mtbHora1.Name = "mtbHora1";
            this.mtbHora1.Size = new System.Drawing.Size(38, 20);
            this.mtbHora1.TabIndex = 53;
            this.mtbHora1.ValidatingType = typeof(System.DateTime);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(5, 77);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(87, 13);
            this.label91.TabIndex = 25;
            this.label91.Text = "Momento del día";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(563, 48);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(30, 13);
            this.label103.TabIndex = 50;
            this.label103.Text = "Hora";
            // 
            // cboMomentoDia1
            // 
            this.cboMomentoDia1.FormattingEnabled = true;
            this.cboMomentoDia1.Location = new System.Drawing.Point(93, 17);
            this.cboMomentoDia1.Name = "cboMomentoDia1";
            this.cboMomentoDia1.Size = new System.Drawing.Size(121, 21);
            this.cboMomentoDia1.TabIndex = 26;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(563, 80);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(30, 13);
            this.label102.TabIndex = 49;
            this.label102.Text = "Hora";
            // 
            // cboMomentoDia2
            // 
            this.cboMomentoDia2.FormattingEnabled = true;
            this.cboMomentoDia2.Location = new System.Drawing.Point(93, 48);
            this.cboMomentoDia2.Name = "cboMomentoDia2";
            this.cboMomentoDia2.Size = new System.Drawing.Size(121, 21);
            this.cboMomentoDia2.TabIndex = 27;
            // 
            // cboPresentacionMedicamento3
            // 
            this.cboPresentacionMedicamento3.FormattingEnabled = true;
            this.cboPresentacionMedicamento3.Location = new System.Drawing.Point(436, 74);
            this.cboPresentacionMedicamento3.Name = "cboPresentacionMedicamento3";
            this.cboPresentacionMedicamento3.Size = new System.Drawing.Size(121, 21);
            this.cboPresentacionMedicamento3.TabIndex = 48;
            // 
            // cboMomentoDia3
            // 
            this.cboMomentoDia3.FormattingEnabled = true;
            this.cboMomentoDia3.Location = new System.Drawing.Point(93, 77);
            this.cboMomentoDia3.Name = "cboMomentoDia3";
            this.cboMomentoDia3.Size = new System.Drawing.Size(121, 21);
            this.cboMomentoDia3.TabIndex = 28;
            // 
            // cboPresentacionMedicamento2
            // 
            this.cboPresentacionMedicamento2.FormattingEnabled = true;
            this.cboPresentacionMedicamento2.Location = new System.Drawing.Point(436, 44);
            this.cboPresentacionMedicamento2.Name = "cboPresentacionMedicamento2";
            this.cboPresentacionMedicamento2.Size = new System.Drawing.Size(121, 21);
            this.cboPresentacionMedicamento2.TabIndex = 47;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(301, 20);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(49, 13);
            this.label92.TabIndex = 29;
            this.label92.Text = "Cantidad";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(563, 17);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(30, 13);
            this.label96.TabIndex = 36;
            this.label96.Text = "Hora";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(301, 80);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(49, 13);
            this.label94.TabIndex = 44;
            this.label94.Text = "Cantidad";
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(301, 51);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(49, 13);
            this.label93.TabIndex = 42;
            this.label93.Text = "Cantidad";
            // 
            // cboFrecuencia
            // 
            this.cboFrecuencia.FormattingEnabled = true;
            this.cboFrecuencia.Location = new System.Drawing.Point(400, 101);
            this.cboFrecuencia.Name = "cboFrecuencia";
            this.cboFrecuencia.Size = new System.Drawing.Size(147, 21);
            this.cboFrecuencia.TabIndex = 23;
            // 
            // cboPresentacionMedicamento
            // 
            this.cboPresentacionMedicamento.FormattingEnabled = true;
            this.cboPresentacionMedicamento.Location = new System.Drawing.Point(152, 78);
            this.cboPresentacionMedicamento.Name = "cboPresentacionMedicamento";
            this.cboPresentacionMedicamento.Size = new System.Drawing.Size(117, 21);
            this.cboPresentacionMedicamento.TabIndex = 22;
            // 
            // cboFormaAdministración
            // 
            this.cboFormaAdministración.FormattingEnabled = true;
            this.cboFormaAdministración.Location = new System.Drawing.Point(458, 46);
            this.cboFormaAdministración.Name = "cboFormaAdministración";
            this.cboFormaAdministración.Size = new System.Drawing.Size(117, 21);
            this.cboFormaAdministración.TabIndex = 18;
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(471, 18);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(84, 21);
            this.cboUnidadMedida.TabIndex = 14;
            // 
            // cboNombreComercial
            // 
            this.cboNombreComercial.FormattingEnabled = true;
            this.cboNombreComercial.Location = new System.Drawing.Point(104, 51);
            this.cboNombreComercial.Name = "cboNombreComercial";
            this.cboNombreComercial.Size = new System.Drawing.Size(121, 21);
            this.cboNombreComercial.TabIndex = 12;
            this.cboNombreComercial.SelectedIndexChanged += new System.EventHandler(this.cboNombreComercial_SelectedIndexChanged);
            // 
            // cboNombreGenerico
            // 
            this.cboNombreGenerico.FormattingEnabled = true;
            this.cboNombreGenerico.Location = new System.Drawing.Point(104, 23);
            this.cboNombreGenerico.Name = "cboNombreGenerico";
            this.cboNombreGenerico.Size = new System.Drawing.Size(121, 21);
            this.cboNombreGenerico.TabIndex = 11;
            this.cboNombreGenerico.SelectedIndexChanged += new System.EventHandler(this.cboNombreGenerico_SelectedIndexChanged);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(334, 50);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(121, 13);
            this.label90.TabIndex = 10;
            this.label90.Text = "Forma de administración";
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(11, 84);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(135, 13);
            this.label89.TabIndex = 9;
            this.label89.Text = "Presentación medicamento";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(334, 104);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(60, 13);
            this.label85.TabIndex = 5;
            this.label85.Text = "Frecuencia";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(334, 21);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(76, 13);
            this.label83.TabIndex = 3;
            this.label83.Text = "Concentración";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(11, 54);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(92, 13);
            this.label82.TabIndex = 2;
            this.label82.Text = "Nombre comercial";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(11, 26);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(88, 13);
            this.label81.TabIndex = 1;
            this.label81.Text = "Nombre genérico";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(679, 388);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(52, 49);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(737, 388);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(52, 49);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAgregarTerapia
            // 
            this.btnAgregarTerapia.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarTerapia.Image")));
            this.btnAgregarTerapia.Location = new System.Drawing.Point(273, 120);
            this.btnAgregarTerapia.Name = "btnAgregarTerapia";
            this.btnAgregarTerapia.Size = new System.Drawing.Size(43, 45);
            this.btnAgregarTerapia.TabIndex = 11;
            this.btnAgregarTerapia.UseVisualStyleBackColor = true;
            this.btnAgregarTerapia.Click += new System.EventHandler(this.btnAgregarTratamiento_Click);
            // 
            // dgvListaTratamientos
            // 
            this.dgvListaTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaTratamientos.Location = new System.Drawing.Point(679, 39);
            this.dgvListaTratamientos.Name = "dgvListaTratamientos";
            this.dgvListaTratamientos.Size = new System.Drawing.Size(194, 344);
            this.dgvListaTratamientos.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(676, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tratamientos iniciados:";
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(794, 388);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(52, 49);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegistrarTratamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 452);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvListaTratamientos);
            this.Controls.Add(this.btnAgregarTerapia);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grbTratamientoFarmacologico);
            this.Controls.Add(this.txtMotivoInicio);
            this.Controls.Add(this.mtbFechaInicio);
            this.Controls.Add(this.txtIndicacionesTerapia);
            this.Controls.Add(this.cboTerapia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrarTratamiento";
            this.Text = "RegistrarTratamiento";
            this.Load += new System.EventHandler(this.RegistrarTratamiento_Load);
            this.grbTratamientoFarmacologico.ResumeLayout(false);
            this.grbTratamientoFarmacologico.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTratamientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTerapia;
        private System.Windows.Forms.TextBox txtIndicacionesTerapia;
        private System.Windows.Forms.MaskedTextBox mtbFechaInicio;
        private System.Windows.Forms.TextBox txtMotivoInicio;
        private System.Windows.Forms.GroupBox grbTratamientoFarmacologico;
        private System.Windows.Forms.ComboBox cboCantidadComprimidos;
        private System.Windows.Forms.ComboBox cboConcentracion;
        private System.Windows.Forms.Label CantidadComprimidos;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox txtDenominadorCantidad3;
        private System.Windows.Forms.TextBox txtNumeradorCantidad3;
        private System.Windows.Forms.TextBox txtDenominadorCantidad1;
        private System.Windows.Forms.TextBox txtNumeradorCantidad1;
        private System.Windows.Forms.TextBox txtDenominadorCantidad2;
        private System.Windows.Forms.TextBox txtNumeradorCantidad2;
        private System.Windows.Forms.ComboBox cboPresentacionMedicamento1;
        private System.Windows.Forms.MaskedTextBox mtbHora3;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.MaskedTextBox mtbHora2;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.MaskedTextBox mtbHora1;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.ComboBox cboMomentoDia1;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.ComboBox cboMomentoDia2;
        private System.Windows.Forms.ComboBox cboPresentacionMedicamento3;
        private System.Windows.Forms.ComboBox cboMomentoDia3;
        private System.Windows.Forms.ComboBox cboPresentacionMedicamento2;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.ComboBox cboFrecuencia;
        private System.Windows.Forms.ComboBox cboPresentacionMedicamento;
        private System.Windows.Forms.ComboBox cboFormaAdministración;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.ComboBox cboNombreComercial;
        private System.Windows.Forms.ComboBox cboNombreGenerico;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarTerapia;
        private System.Windows.Forms.DataGridView dgvListaTratamientos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarTratamientoMedicamento;
        private System.Windows.Forms.Button btnSalir;
    }
}