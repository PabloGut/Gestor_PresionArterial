namespace GPA
{
    partial class ActualizarUnidadMedida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarUnidadMedida));
            this.txtNombreUnidadMedida = new System.Windows.Forms.TextBox();
            this.txtDescripcionUnidadMedida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegistrarUnidadMedida = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvUnidadesDeMedida = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadesDeMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombreUnidadMedida
            // 
            this.txtNombreUnidadMedida.Location = new System.Drawing.Point(166, 35);
            this.txtNombreUnidadMedida.Name = "txtNombreUnidadMedida";
            this.txtNombreUnidadMedida.Size = new System.Drawing.Size(100, 20);
            this.txtNombreUnidadMedida.TabIndex = 0;
            // 
            // txtDescripcionUnidadMedida
            // 
            this.txtDescripcionUnidadMedida.Location = new System.Drawing.Point(81, 79);
            this.txtDescripcionUnidadMedida.Name = "txtDescripcionUnidadMedida";
            this.txtDescripcionUnidadMedida.Size = new System.Drawing.Size(185, 20);
            this.txtDescripcionUnidadMedida.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Siglas de la unidad de medida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción";
            // 
            // btnRegistrarUnidadMedida
            // 
            this.btnRegistrarUnidadMedida.Location = new System.Drawing.Point(12, 135);
            this.btnRegistrarUnidadMedida.Name = "btnRegistrarUnidadMedida";
            this.btnRegistrarUnidadMedida.Size = new System.Drawing.Size(71, 23);
            this.btnRegistrarUnidadMedida.TabIndex = 4;
            this.btnRegistrarUnidadMedida.Text = "Guardar";
            this.btnRegistrarUnidadMedida.UseVisualStyleBackColor = true;
            this.btnRegistrarUnidadMedida.Click += new System.EventHandler(this.btnRegistrarUnidadMedida_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(89, 135);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(75, 23);
            this.btnNueva.TabIndex = 5;
            this.btnNueva.Text = "Nueva";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(170, 135);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvUnidadesDeMedida
            // 
            this.dgvUnidadesDeMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadesDeMedida.Location = new System.Drawing.Point(12, 193);
            this.dgvUnidadesDeMedida.Name = "dgvUnidadesDeMedida";
            this.dgvUnidadesDeMedida.ReadOnly = true;
            this.dgvUnidadesDeMedida.Size = new System.Drawing.Size(320, 150);
            this.dgvUnidadesDeMedida.TabIndex = 7;
            this.dgvUnidadesDeMedida.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnidadesDeMedida_CellClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(251, 135);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // ActualizarUnidadMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 355);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvUnidadesDeMedida);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNueva);
            this.Controls.Add(this.btnRegistrarUnidadMedida);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcionUnidadMedida);
            this.Controls.Add(this.txtNombreUnidadMedida);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualizarUnidadMedida";
            this.Text = "Actualizar Unidad Medida";
            this.Load += new System.EventHandler(this.ActualizarUnidadMedida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadesDeMedida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreUnidadMedida;
        private System.Windows.Forms.TextBox txtDescripcionUnidadMedida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegistrarUnidadMedida;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvUnidadesDeMedida;
        private System.Windows.Forms.Button btnSalir;
    }
}