namespace GPA
{
    partial class ActualizarMetodoAnalisisLaboratorio
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
            this.txtMetodoAnalisisLaboratorio = new System.Windows.Forms.TextBox();
            this.dgvListaMetodosAnalisisLaboratorio = new System.Windows.Forms.DataGridView();
            this.btnGuardarMetodoAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnEliminarMetodoAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnCancelarMetodoAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnSalirMetodoAnalisisLaboratorio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodosAnalisisLaboratorio)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre método:";
            // 
            // txtMetodoAnalisisLaboratorio
            // 
            this.txtMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(148, 22);
            this.txtMetodoAnalisisLaboratorio.Name = "txtMetodoAnalisisLaboratorio";
            this.txtMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(158, 20);
            this.txtMetodoAnalisisLaboratorio.TabIndex = 1;
            // 
            // dgvListaMetodosAnalisisLaboratorio
            // 
            this.dgvListaMetodosAnalisisLaboratorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMetodosAnalisisLaboratorio.Location = new System.Drawing.Point(60, 48);
            this.dgvListaMetodosAnalisisLaboratorio.Name = "dgvListaMetodosAnalisisLaboratorio";
            this.dgvListaMetodosAnalisisLaboratorio.ReadOnly = true;
            this.dgvListaMetodosAnalisisLaboratorio.Size = new System.Drawing.Size(246, 150);
            this.dgvListaMetodosAnalisisLaboratorio.TabIndex = 2;
            this.dgvListaMetodosAnalisisLaboratorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaMetodosAnalisisLaboratorio_CellClick);
            // 
            // btnGuardarMetodoAnalisisLaboratorio
            // 
            this.btnGuardarMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(15, 229);
            this.btnGuardarMetodoAnalisisLaboratorio.Name = "btnGuardarMetodoAnalisisLaboratorio";
            this.btnGuardarMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarMetodoAnalisisLaboratorio.TabIndex = 3;
            this.btnGuardarMetodoAnalisisLaboratorio.Text = "Guardar";
            this.btnGuardarMetodoAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnGuardarMetodoAnalisisLaboratorio.Click += new System.EventHandler(this.btnGuardarMetodoAnalisisLaboratorio_Click);
            // 
            // btnEliminarMetodoAnalisisLaboratorio
            // 
            this.btnEliminarMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(100, 229);
            this.btnEliminarMetodoAnalisisLaboratorio.Name = "btnEliminarMetodoAnalisisLaboratorio";
            this.btnEliminarMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarMetodoAnalisisLaboratorio.TabIndex = 4;
            this.btnEliminarMetodoAnalisisLaboratorio.Text = "Eliminar";
            this.btnEliminarMetodoAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnEliminarMetodoAnalisisLaboratorio.Click += new System.EventHandler(this.btnEliminarMetodoAnalisisLaboratorio_Click);
            // 
            // btnCancelarMetodoAnalisisLaboratorio
            // 
            this.btnCancelarMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(183, 229);
            this.btnCancelarMetodoAnalisisLaboratorio.Name = "btnCancelarMetodoAnalisisLaboratorio";
            this.btnCancelarMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarMetodoAnalisisLaboratorio.TabIndex = 5;
            this.btnCancelarMetodoAnalisisLaboratorio.Text = "Cancelar";
            this.btnCancelarMetodoAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnCancelarMetodoAnalisisLaboratorio.Click += new System.EventHandler(this.btnCancelarMetodoAnalisisLaboratorio_Click);
            // 
            // btnSalirMetodoAnalisisLaboratorio
            // 
            this.btnSalirMetodoAnalisisLaboratorio.Location = new System.Drawing.Point(264, 229);
            this.btnSalirMetodoAnalisisLaboratorio.Name = "btnSalirMetodoAnalisisLaboratorio";
            this.btnSalirMetodoAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnSalirMetodoAnalisisLaboratorio.TabIndex = 6;
            this.btnSalirMetodoAnalisisLaboratorio.Text = "Salir";
            this.btnSalirMetodoAnalisisLaboratorio.UseVisualStyleBackColor = true;
            // 
            // ActualizarMetodoAnalisisLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 264);
            this.Controls.Add(this.btnSalirMetodoAnalisisLaboratorio);
            this.Controls.Add(this.btnCancelarMetodoAnalisisLaboratorio);
            this.Controls.Add(this.btnEliminarMetodoAnalisisLaboratorio);
            this.Controls.Add(this.btnGuardarMetodoAnalisisLaboratorio);
            this.Controls.Add(this.dgvListaMetodosAnalisisLaboratorio);
            this.Controls.Add(this.txtMetodoAnalisisLaboratorio);
            this.Controls.Add(this.label1);
            this.Name = "ActualizarMetodoAnalisisLaboratorio";
            this.Text = "Actualizar Metodo Analisis Laboratorio";
            this.Load += new System.EventHandler(this.ActualizarMetodoAnalisisLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMetodosAnalisisLaboratorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMetodoAnalisisLaboratorio;
        private System.Windows.Forms.DataGridView dgvListaMetodosAnalisisLaboratorio;
        private System.Windows.Forms.Button btnGuardarMetodoAnalisisLaboratorio;
        private System.Windows.Forms.Button btnEliminarMetodoAnalisisLaboratorio;
        private System.Windows.Forms.Button btnCancelarMetodoAnalisisLaboratorio;
        private System.Windows.Forms.Button btnSalirMetodoAnalisisLaboratorio;
    }
}