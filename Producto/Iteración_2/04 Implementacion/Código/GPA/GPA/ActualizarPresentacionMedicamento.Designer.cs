namespace GPA
{
    partial class ActualizarPresentacionMedicamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarPresentacionMedicamento));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFormaPresentacion = new System.Windows.Forms.TextBox();
            this.btnFormaPresentacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forma de presentación del medicamento:";
            // 
            // txtFormaPresentacion
            // 
            this.txtFormaPresentacion.Location = new System.Drawing.Point(216, 33);
            this.txtFormaPresentacion.Name = "txtFormaPresentacion";
            this.txtFormaPresentacion.Size = new System.Drawing.Size(176, 20);
            this.txtFormaPresentacion.TabIndex = 1;
            // 
            // btnFormaPresentacion
            // 
            this.btnFormaPresentacion.Location = new System.Drawing.Point(126, 86);
            this.btnFormaPresentacion.Name = "btnFormaPresentacion";
            this.btnFormaPresentacion.Size = new System.Drawing.Size(214, 23);
            this.btnFormaPresentacion.TabIndex = 2;
            this.btnFormaPresentacion.Text = "Registrar forma de presentación";
            this.btnFormaPresentacion.UseVisualStyleBackColor = true;
            this.btnFormaPresentacion.Click += new System.EventHandler(this.btnFormaPresentacion_Click);
            // 
            // ActualizarPresentacionMedicamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 153);
            this.Controls.Add(this.btnFormaPresentacion);
            this.Controls.Add(this.txtFormaPresentacion);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualizarPresentacionMedicamento";
            this.Text = "ActualizarPresentacionMedicamento";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFormaPresentacion;
        private System.Windows.Forms.Button btnFormaPresentacion;

    }
}