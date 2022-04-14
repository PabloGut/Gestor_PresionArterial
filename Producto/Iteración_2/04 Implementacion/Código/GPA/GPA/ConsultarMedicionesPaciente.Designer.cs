namespace GPA
{
    partial class ConsultarMedicionesPaciente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarMedicionesPaciente));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboSitioMedicion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMomentoDia = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboPosicion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUbicacionExtremidad = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboExtremidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtbFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.mtbFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvConsultarMediciones = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPromedioPulso = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPromedioDiastolica = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPromedioSistolica = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.txtSitioMedicion = new System.Windows.Forms.TextBox();
            this.txtMomentoDia = new System.Windows.Forms.TextBox();
            this.txtUbicacionExtremidad = new System.Windows.Forms.TextBox();
            this.txtExtremidad = new System.Windows.Forms.TextBox();
            this.mtbFecha = new System.Windows.Forms.MaskedTextBox();
            this.mtbHoraInicio = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvDetalleMediciones = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultarMediciones)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleMediciones)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboSitioMedicion);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboMomentoDia);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboPosicion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboUbicacionExtremidad);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboExtremidad);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.mtbFechaHasta);
            this.groupBox1.Controls.Add(this.mtbFechaDesde);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar mediciones";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(483, 129);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(59, 51);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(418, 129);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(59, 51);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboSitioMedicion
            // 
            this.cboSitioMedicion.FormattingEnabled = true;
            this.cboSitioMedicion.Location = new System.Drawing.Point(337, 103);
            this.cboSitioMedicion.Name = "cboSitioMedicion";
            this.cboSitioMedicion.Size = new System.Drawing.Size(100, 21);
            this.cboSitioMedicion.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Sitio de medición:";
            // 
            // cboMomentoDia
            // 
            this.cboMomentoDia.FormattingEnabled = true;
            this.cboMomentoDia.Location = new System.Drawing.Point(104, 103);
            this.cboMomentoDia.Name = "cboMomentoDia";
            this.cboMomentoDia.Size = new System.Drawing.Size(100, 21);
            this.cboMomentoDia.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Momento del día:";
            // 
            // cboPosicion
            // 
            this.cboPosicion.FormattingEnabled = true;
            this.cboPosicion.Location = new System.Drawing.Point(104, 144);
            this.cboPosicion.Name = "cboPosicion";
            this.cboPosicion.Size = new System.Drawing.Size(100, 21);
            this.cboPosicion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Posición:";
            // 
            // cboUbicacionExtremidad
            // 
            this.cboUbicacionExtremidad.FormattingEnabled = true;
            this.cboUbicacionExtremidad.Location = new System.Drawing.Point(337, 64);
            this.cboUbicacionExtremidad.Name = "cboUbicacionExtremidad";
            this.cboUbicacionExtremidad.Size = new System.Drawing.Size(100, 21);
            this.cboUbicacionExtremidad.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ubicación extremidad:";
            // 
            // cboExtremidad
            // 
            this.cboExtremidad.FormattingEnabled = true;
            this.cboExtremidad.Location = new System.Drawing.Point(104, 64);
            this.cboExtremidad.Name = "cboExtremidad";
            this.cboExtremidad.Size = new System.Drawing.Size(100, 21);
            this.cboExtremidad.TabIndex = 5;
            this.cboExtremidad.SelectedIndexChanged += new System.EventHandler(this.cboExtremidad_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Extremidad:";
            // 
            // mtbFechaHasta
            // 
            this.mtbFechaHasta.Location = new System.Drawing.Point(337, 25);
            this.mtbFechaHasta.Name = "mtbFechaHasta";
            this.mtbFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.mtbFechaHasta.TabIndex = 3;
            this.mtbFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // mtbFechaDesde
            // 
            this.mtbFechaDesde.Location = new System.Drawing.Point(104, 25);
            this.mtbFechaDesde.Name = "mtbFechaDesde";
            this.mtbFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.mtbFechaDesde.TabIndex = 2;
            this.mtbFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvConsultarMediciones);
            this.groupBox2.Location = new System.Drawing.Point(12, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mediciones";
            // 
            // dgvConsultarMediciones
            // 
            this.dgvConsultarMediciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultarMediciones.Location = new System.Drawing.Point(8, 19);
            this.dgvConsultarMediciones.Name = "dgvConsultarMediciones";
            this.dgvConsultarMediciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultarMediciones.Size = new System.Drawing.Size(534, 178);
            this.dgvConsultarMediciones.TabIndex = 0;
            this.dgvConsultarMediciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultarMediciones_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPromedioPulso);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.txtPromedioDiastolica);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtPromedioSistolica);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtPosicion);
            this.groupBox3.Controls.Add(this.txtSitioMedicion);
            this.groupBox3.Controls.Add(this.txtMomentoDia);
            this.groupBox3.Controls.Add(this.txtUbicacionExtremidad);
            this.groupBox3.Controls.Add(this.txtExtremidad);
            this.groupBox3.Controls.Add(this.mtbFecha);
            this.groupBox3.Controls.Add(this.mtbHoraInicio);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(566, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 234);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Medición Seleccionada";
            // 
            // txtPromedioPulso
            // 
            this.txtPromedioPulso.Location = new System.Drawing.Point(388, 189);
            this.txtPromedioPulso.Name = "txtPromedioPulso";
            this.txtPromedioPulso.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioPulso.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(302, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Promedio Pulso";
            // 
            // txtPromedioDiastolica
            // 
            this.txtPromedioDiastolica.Location = new System.Drawing.Point(115, 189);
            this.txtPromedioDiastolica.Name = "txtPromedioDiastolica";
            this.txtPromedioDiastolica.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioDiastolica.TabIndex = 26;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 193);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Promedio Diastólica:";
            // 
            // txtPromedioSistolica
            // 
            this.txtPromedioSistolica.Location = new System.Drawing.Point(388, 148);
            this.txtPromedioSistolica.Name = "txtPromedioSistolica";
            this.txtPromedioSistolica.Size = new System.Drawing.Size(100, 20);
            this.txtPromedioSistolica.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(291, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Promedio Sitólica:";
            // 
            // txtPosicion
            // 
            this.txtPosicion.Location = new System.Drawing.Point(115, 148);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(100, 20);
            this.txtPosicion.TabIndex = 22;
            // 
            // txtSitioMedicion
            // 
            this.txtSitioMedicion.Location = new System.Drawing.Point(388, 107);
            this.txtSitioMedicion.Name = "txtSitioMedicion";
            this.txtSitioMedicion.Size = new System.Drawing.Size(100, 20);
            this.txtSitioMedicion.TabIndex = 21;
            // 
            // txtMomentoDia
            // 
            this.txtMomentoDia.Location = new System.Drawing.Point(115, 107);
            this.txtMomentoDia.Name = "txtMomentoDia";
            this.txtMomentoDia.Size = new System.Drawing.Size(100, 20);
            this.txtMomentoDia.TabIndex = 20;
            // 
            // txtUbicacionExtremidad
            // 
            this.txtUbicacionExtremidad.Location = new System.Drawing.Point(388, 66);
            this.txtUbicacionExtremidad.Name = "txtUbicacionExtremidad";
            this.txtUbicacionExtremidad.Size = new System.Drawing.Size(100, 20);
            this.txtUbicacionExtremidad.TabIndex = 19;
            // 
            // txtExtremidad
            // 
            this.txtExtremidad.Location = new System.Drawing.Point(115, 66);
            this.txtExtremidad.Name = "txtExtremidad";
            this.txtExtremidad.Size = new System.Drawing.Size(100, 20);
            this.txtExtremidad.TabIndex = 18;
            // 
            // mtbFecha
            // 
            this.mtbFecha.Location = new System.Drawing.Point(388, 25);
            this.mtbFecha.Name = "mtbFecha";
            this.mtbFecha.Size = new System.Drawing.Size(100, 20);
            this.mtbFecha.TabIndex = 17;
            // 
            // mtbHoraInicio
            // 
            this.mtbHoraInicio.Location = new System.Drawing.Point(115, 25);
            this.mtbHoraInicio.Name = "mtbHoraInicio";
            this.mtbHoraInicio.Size = new System.Drawing.Size(100, 20);
            this.mtbHoraInicio.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Sitio de medición:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Momento del día:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 152);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Posición:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Ubicación extremidad:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(47, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Extremidad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Fecha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hora Inicio:";
            // 
            // dgvDetalleMediciones
            // 
            this.dgvDetalleMediciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleMediciones.Location = new System.Drawing.Point(6, 19);
            this.dgvDetalleMediciones.Name = "dgvDetalleMediciones";
            this.dgvDetalleMediciones.Size = new System.Drawing.Size(522, 129);
            this.dgvDetalleMediciones.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvDetalleMediciones);
            this.groupBox4.Location = new System.Drawing.Point(566, 249);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(534, 158);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Detalle Mediciones";
            // 
            // chart1
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 416);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1088, 210);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // ConsultarMedicionesPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 638);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarMedicionesPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ConsultarMedicionesPaciente";
            this.Load += new System.EventHandler(this.ConsultarMedicionesPaciente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultarMediciones)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleMediciones)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbFechaHasta;
        private System.Windows.Forms.MaskedTextBox mtbFechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboUbicacionExtremidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboExtremidad;
        private System.Windows.Forms.ComboBox cboPosicion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMomentoDia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSitioMedicion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvConsultarMediciones;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDetalleMediciones;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.TextBox txtSitioMedicion;
        private System.Windows.Forms.TextBox txtMomentoDia;
        private System.Windows.Forms.TextBox txtUbicacionExtremidad;
        private System.Windows.Forms.TextBox txtExtremidad;
        private System.Windows.Forms.MaskedTextBox mtbFecha;
        private System.Windows.Forms.MaskedTextBox mtbHoraInicio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPromedioPulso;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPromedioDiastolica;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPromedioSistolica;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnCancelar;
    }
}