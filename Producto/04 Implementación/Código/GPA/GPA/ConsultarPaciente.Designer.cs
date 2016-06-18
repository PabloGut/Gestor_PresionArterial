namespace GPA
{
    partial class ConsultarPaciente
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
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCrearHC = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número de documento";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Location = new System.Drawing.Point(126, 24);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cboTipoDoc.TabIndex = 2;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(141, 60);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(106, 20);
            this.txtNroDoc.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.cboTipoDoc);
            this.groupBox1.Controls.Add(this.txtNroDoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar Paciente";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(290, 22);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCrearHC);
            this.groupBox2.Controls.Add(this.txtApellido);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 116);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Paciente";
            // 
            // btnCrearHC
            // 
            this.btnCrearHC.Location = new System.Drawing.Point(263, 36);
            this.btnCrearHC.Name = "btnCrearHC";
            this.btnCrearHC.Size = new System.Drawing.Size(102, 55);
            this.btnCrearHC.TabIndex = 9;
            this.btnCrearHC.Text = "Crear Historia Clínica";
            this.btnCrearHC.UseVisualStyleBackColor = true;
            this.btnCrearHC.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(70, 75);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 8;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(70, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(290, 51);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // ConsultarPaciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 254);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultarPaciente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultarPaciente";
            this.Load += new System.EventHandler(this.ConsultarPaciente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrearHC;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}