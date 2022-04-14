namespace GPA
{
    partial class ConsultarEstadisticas_PromedioPorcentajeModa
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultarEstadisticas_PromedioPorcentajeModa));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEdadPromedio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadMujeres = new System.Windows.Forms.TextBox();
            this.txtCantidadVarones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPacientes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPorcetajeVarones = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPorcentajeMujeres = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtModaEdad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promedio de edad de pacientes con diagnóstico de hipertensión arterial";
            // 
            // txtEdadPromedio
            // 
            this.txtEdadPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdadPromedio.Location = new System.Drawing.Point(471, 17);
            this.txtEdadPromedio.Name = "txtEdadPromedio";
            this.txtEdadPromedio.Size = new System.Drawing.Size(76, 23);
            this.txtEdadPromedio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(391, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de mujeres con diagnóstico de hipertensión arterial\r\n";
            // 
            // txtCantidadMujeres
            // 
            this.txtCantidadMujeres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMujeres.Location = new System.Drawing.Point(471, 60);
            this.txtCantidadMujeres.Name = "txtCantidadMujeres";
            this.txtCantidadMujeres.Size = new System.Drawing.Size(76, 23);
            this.txtCantidadMujeres.TabIndex = 3;
            // 
            // txtCantidadVarones
            // 
            this.txtCantidadVarones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadVarones.Location = new System.Drawing.Point(960, 60);
            this.txtCantidadVarones.Name = "txtCantidadVarones";
            this.txtCantidadVarones.Size = new System.Drawing.Size(76, 23);
            this.txtCantidadVarones.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(562, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad de varones con diagnóstico de hipertensión arterial\r\n";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtTotalPacientes
            // 
            this.txtTotalPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPacientes.Location = new System.Drawing.Point(557, 19);
            this.txtTotalPacientes.Name = "txtTotalPacientes";
            this.txtTotalPacientes.Size = new System.Drawing.Size(76, 23);
            this.txtTotalPacientes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(540, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total de pacientes registrados en el sistema con diagnostico de hipertensión arte" +
    "rial";
            // 
            // txtPorcetajeVarones
            // 
            this.txtPorcetajeVarones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcetajeVarones.Location = new System.Drawing.Point(557, 87);
            this.txtPorcetajeVarones.Name = "txtPorcetajeVarones";
            this.txtPorcetajeVarones.Size = new System.Drawing.Size(76, 23);
            this.txtPorcetajeVarones.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(143, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(404, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Porcentaje de varones con diagnóstico de hipertensión arterial\r\n";
            // 
            // txtPorcentajeMujeres
            // 
            this.txtPorcentajeMujeres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPorcentajeMujeres.Location = new System.Drawing.Point(557, 53);
            this.txtPorcentajeMujeres.Name = "txtPorcentajeMujeres";
            this.txtPorcentajeMujeres.Size = new System.Drawing.Size(76, 23);
            this.txtPorcentajeMujeres.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(144, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(403, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Porcentaje de mujeres con diagnóstico de hipertensión arterial\r\n";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtModaEdad);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEdadPromedio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCantidadMujeres);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCantidadVarones);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1058, 121);
            this.panel1.TabIndex = 12;
            // 
            // txtModaEdad
            // 
            this.txtModaEdad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModaEdad.Location = new System.Drawing.Point(960, 17);
            this.txtModaEdad.Name = "txtModaEdad";
            this.txtModaEdad.Size = new System.Drawing.Size(76, 23);
            this.txtModaEdad.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(793, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Edad/es mas frecuentes";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTotalPacientes);
            this.panel2.Controls.Add(this.txtPorcetajeVarones);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPorcentajeMujeres);
            this.panel2.Location = new System.Drawing.Point(10, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 118);
            this.panel2.TabIndex = 13;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(25, 11);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(471, 300);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "Cantidad Pacientes por Sexo";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.chart1);
            this.panel3.Location = new System.Drawing.Point(10, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(514, 320);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.chart2);
            this.panel4.Location = new System.Drawing.Point(533, 263);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(535, 320);
            this.panel4.TabIndex = 16;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(14, 13);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart2.Series.Add(series1);
            this.chart2.Size = new System.Drawing.Size(498, 300);
            this.chart2.TabIndex = 14;
            this.chart2.Text = "Porcentajes pacientes por sexo";
            // 
            // ConsultarEstadisticas_PromedioPorcentajeModa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 595);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsultarEstadisticas_PromedioPorcentajeModa";
            this.Text = "Consultar Estadisticas";
            this.Load += new System.EventHandler(this.ConsultarEstadisticas_PromedioPorcentajeModa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEdadPromedio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadMujeres;
        private System.Windows.Forms.TextBox txtCantidadVarones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotalPacientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPorcetajeVarones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPorcentajeMujeres;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtModaEdad;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}