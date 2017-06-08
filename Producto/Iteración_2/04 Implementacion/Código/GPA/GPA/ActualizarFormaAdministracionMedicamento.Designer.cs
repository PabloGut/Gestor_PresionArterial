namespace GPA
{
    partial class ActualizarFormaAdministracionMedicamento
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
            this.txtFormaAdministracion = new System.Windows.Forms.TextBox();
            this.btnRegistrarFormaAdministracion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de administracion:";
            // 
            // txtFormaAdministracion
            // 
            this.txtFormaAdministracion.Location = new System.Drawing.Point(139, 38);
            this.txtFormaAdministracion.Name = "txtFormaAdministracion";
            this.txtFormaAdministracion.Size = new System.Drawing.Size(175, 20);
            this.txtFormaAdministracion.TabIndex = 1;
            // 
            // btnRegistrarFormaAdministracion
            // 
            this.btnRegistrarFormaAdministracion.Location = new System.Drawing.Point(89, 88);
            this.btnRegistrarFormaAdministracion.Name = "btnRegistrarFormaAdministracion";
            this.btnRegistrarFormaAdministracion.Size = new System.Drawing.Size(175, 23);
            this.btnRegistrarFormaAdministracion.TabIndex = 2;
            this.btnRegistrarFormaAdministracion.Text = "Registrar forma de administración";
            this.btnRegistrarFormaAdministracion.UseVisualStyleBackColor = true;
            this.btnRegistrarFormaAdministracion.Click += new System.EventHandler(this.btnRegistrarFormaAdministracion_Click);
            // 
            // ActualizarFormaAdministracionMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 165);
            this.Controls.Add(this.btnRegistrarFormaAdministracion);
            this.Controls.Add(this.txtFormaAdministracion);
            this.Controls.Add(this.label1);
            this.Name = "ActualizarFormaAdministracionMedicamento";
            this.Text = "ActualizarFormaAdministracionMedicamento";
            this.Load += new System.EventHandler(this.ActualizarFormaAdministracionMedicamento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFormaAdministracion;
        private System.Windows.Forms.Button btnRegistrarFormaAdministracion;
    }
}