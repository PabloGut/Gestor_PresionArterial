namespace GPA
{
    partial class Consultar_EstadisticasMedicionesPromedioConFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultar_EstadisticasMedicionesPromedioConFiltro));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mtbFechaHasta = new System.Windows.Forms.MaskedTextBox();
            this.mtbFechaDesde = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPromedioConExamen = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvPromedioSinExamen = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chBarraSinExamen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chBarraConExamen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chCantCategoriaSinExamen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chCantCategoriaConExamen = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvCantCategoriaConExamen = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCantCategoriaSinExamen = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromedioConExamen)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromedioSinExamen)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chBarraSinExamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBarraConExamen)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chCantCategoriaSinExamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCantCategoriaConExamen)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantCategoriaConExamen)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantCategoriaSinExamen)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(578, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "FechaHasta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(277, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "FechaDesde";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.mtbFechaHasta);
            this.panel1.Controls.Add(this.mtbFechaDesde);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 104);
            this.panel1.TabIndex = 14;
            // 
            // mtbFechaHasta
            // 
            this.mtbFechaHasta.Location = new System.Drawing.Point(668, 19);
            this.mtbFechaHasta.Mask = "00/00/0000";
            this.mtbFechaHasta.Name = "mtbFechaHasta";
            this.mtbFechaHasta.Size = new System.Drawing.Size(164, 20);
            this.mtbFechaHasta.TabIndex = 12;
            this.mtbFechaHasta.ValidatingType = typeof(System.DateTime);
            // 
            // mtbFechaDesde
            // 
            this.mtbFechaDesde.Location = new System.Drawing.Point(371, 19);
            this.mtbFechaDesde.Mask = "00/00/0000";
            this.mtbFechaDesde.Name = "mtbFechaDesde";
            this.mtbFechaDesde.Size = new System.Drawing.Size(164, 20);
            this.mtbFechaDesde.TabIndex = 11;
            this.mtbFechaDesde.ValidatingType = typeof(System.DateTime);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(532, 49);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(52, 48);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgvPromedioConExamen);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 239);
            this.panel2.TabIndex = 15;
            // 
            // dgvPromedioConExamen
            // 
            this.dgvPromedioConExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromedioConExamen.Location = new System.Drawing.Point(18, 48);
            this.dgvPromedioConExamen.Name = "dgvPromedioConExamen";
            this.dgvPromedioConExamen.Size = new System.Drawing.Size(507, 175);
            this.dgvPromedioConExamen.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Promedio de presión Sistólica y Diastólica en Examen Médico:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgvPromedioSinExamen);
            this.panel3.Location = new System.Drawing.Point(563, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 239);
            this.panel3.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Promedio de presión Sistólica y Diastólica sin Examen Médico:";
            // 
            // dgvPromedioSinExamen
            // 
            this.dgvPromedioSinExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromedioSinExamen.Location = new System.Drawing.Point(18, 48);
            this.dgvPromedioSinExamen.Name = "dgvPromedioSinExamen";
            this.dgvPromedioSinExamen.Size = new System.Drawing.Size(528, 175);
            this.dgvPromedioSinExamen.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 117);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 554);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chBarraSinExamen);
            this.tabPage1.Controls.Add(this.chBarraConExamen);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1113, 528);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Promedio Sistólica / Diastólica";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chBarraSinExamen
            // 
            chartArea5.Name = "ChartArea1";
            this.chBarraSinExamen.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chBarraSinExamen.Legends.Add(legend5);
            this.chBarraSinExamen.Location = new System.Drawing.Point(583, 277);
            this.chBarraSinExamen.Name = "chBarraSinExamen";
            this.chBarraSinExamen.Size = new System.Drawing.Size(517, 225);
            this.chBarraSinExamen.TabIndex = 18;
            this.chBarraSinExamen.Text = "chart2";
            // 
            // chBarraConExamen
            // 
            chartArea6.Name = "ChartArea1";
            this.chBarraConExamen.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chBarraConExamen.Legends.Add(legend6);
            this.chBarraConExamen.Location = new System.Drawing.Point(16, 277);
            this.chBarraConExamen.Name = "chBarraConExamen";
            this.chBarraConExamen.Size = new System.Drawing.Size(517, 225);
            this.chBarraConExamen.TabIndex = 17;
            this.chBarraConExamen.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chCantCategoriaSinExamen);
            this.tabPage2.Controls.Add(this.chCantCategoriaConExamen);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1113, 528);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cantidad pacientes por categoría";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chCantCategoriaSinExamen
            // 
            chartArea7.Name = "ChartArea1";
            this.chCantCategoriaSinExamen.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chCantCategoriaSinExamen.Legends.Add(legend7);
            this.chCantCategoriaSinExamen.Location = new System.Drawing.Point(554, 274);
            this.chCantCategoriaSinExamen.Name = "chCantCategoriaSinExamen";
            this.chCantCategoriaSinExamen.Size = new System.Drawing.Size(546, 215);
            this.chCantCategoriaSinExamen.TabIndex = 4;
            this.chCantCategoriaSinExamen.Text = "chart5";
            // 
            // chCantCategoriaConExamen
            // 
            chartArea8.Name = "ChartArea1";
            this.chCantCategoriaConExamen.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chCantCategoriaConExamen.Legends.Add(legend8);
            this.chCantCategoriaConExamen.Location = new System.Drawing.Point(16, 274);
            this.chCantCategoriaConExamen.Name = "chCantCategoriaConExamen";
            this.chCantCategoriaConExamen.Size = new System.Drawing.Size(532, 215);
            this.chCantCategoriaConExamen.TabIndex = 3;
            this.chCantCategoriaConExamen.Text = "chart6";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dgvCantCategoriaConExamen);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 239);
            this.panel4.TabIndex = 19;
            // 
            // dgvCantCategoriaConExamen
            // 
            this.dgvCantCategoriaConExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantCategoriaConExamen.Location = new System.Drawing.Point(18, 48);
            this.dgvCantCategoriaConExamen.Name = "dgvCantCategoriaConExamen";
            this.dgvCantCategoriaConExamen.Size = new System.Drawing.Size(507, 175);
            this.dgvCantCategoriaConExamen.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(536, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cantidad de Pacientes por Categoría de Hipertension Arterial (En examen General):" +
    "\r\n";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.dgvCantCategoriaSinExamen);
            this.panel5.Location = new System.Drawing.Point(563, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(543, 239);
            this.panel5.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Cantidad de Pacientes por Categoría de Hipertension Arterial (Sin examen General)" +
    ":";
            // 
            // dgvCantCategoriaSinExamen
            // 
            this.dgvCantCategoriaSinExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCantCategoriaSinExamen.Location = new System.Drawing.Point(11, 48);
            this.dgvCantCategoriaSinExamen.Name = "dgvCantCategoriaSinExamen";
            this.dgvCantCategoriaSinExamen.Size = new System.Drawing.Size(524, 175);
            this.dgvCantCategoriaSinExamen.TabIndex = 2;
            // 
            // Consultar_EstadisticasMedicionesPromedioConFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 683);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consultar_EstadisticasMedicionesPromedioConFiltro";
            this.Text = "Consultar_EstadisticasMedicionesPromedioConFiltro";
            this.Load += new System.EventHandler(this.Consultar_EstadisticasMedicionesPromedioConFiltro_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromedioConExamen)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromedioSinExamen)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chBarraSinExamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chBarraConExamen)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chCantCategoriaSinExamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chCantCategoriaConExamen)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantCategoriaConExamen)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCantCategoriaSinExamen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPromedioConExamen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvPromedioSinExamen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvCantCategoriaConExamen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCantCategoriaSinExamen;
        private System.Windows.Forms.MaskedTextBox mtbFechaHasta;
        private System.Windows.Forms.MaskedTextBox mtbFechaDesde;
        private System.Windows.Forms.DataVisualization.Charting.Chart chCantCategoriaSinExamen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chCantCategoriaConExamen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chBarraSinExamen;
        private System.Windows.Forms.DataVisualization.Charting.Chart chBarraConExamen;
    }
}