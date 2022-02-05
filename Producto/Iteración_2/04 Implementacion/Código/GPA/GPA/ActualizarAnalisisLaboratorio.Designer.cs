namespace GPA
{
    partial class ActualizarAnalisisLaboratorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarAnalisisLaboratorio));
            this.btnSalirAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnCancelarAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnEliminarAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.btnGuardarAnalisisLaboratorio = new System.Windows.Forms.Button();
            this.dgvListaAnalisisLaboratorio = new System.Windows.Forms.DataGridView();
            this.txtAnalisisLaboratorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcionAnalisisLaboratorio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAnalisisLaboratorio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalirAnalisisLaboratorio
            // 
            this.btnSalirAnalisisLaboratorio.Location = new System.Drawing.Point(263, 243);
            this.btnSalirAnalisisLaboratorio.Name = "btnSalirAnalisisLaboratorio";
            this.btnSalirAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnSalirAnalisisLaboratorio.TabIndex = 13;
            this.btnSalirAnalisisLaboratorio.Text = "Salir";
            this.btnSalirAnalisisLaboratorio.UseVisualStyleBackColor = true;
            // 
            // btnCancelarAnalisisLaboratorio
            // 
            this.btnCancelarAnalisisLaboratorio.Location = new System.Drawing.Point(182, 243);
            this.btnCancelarAnalisisLaboratorio.Name = "btnCancelarAnalisisLaboratorio";
            this.btnCancelarAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarAnalisisLaboratorio.TabIndex = 12;
            this.btnCancelarAnalisisLaboratorio.Text = "Cancelar";
            this.btnCancelarAnalisisLaboratorio.UseVisualStyleBackColor = true;
            // 
            // btnEliminarAnalisisLaboratorio
            // 
            this.btnEliminarAnalisisLaboratorio.Location = new System.Drawing.Point(99, 243);
            this.btnEliminarAnalisisLaboratorio.Name = "btnEliminarAnalisisLaboratorio";
            this.btnEliminarAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarAnalisisLaboratorio.TabIndex = 11;
            this.btnEliminarAnalisisLaboratorio.Text = "Eliminar";
            this.btnEliminarAnalisisLaboratorio.UseVisualStyleBackColor = true;
            // 
            // btnGuardarAnalisisLaboratorio
            // 
            this.btnGuardarAnalisisLaboratorio.Location = new System.Drawing.Point(14, 243);
            this.btnGuardarAnalisisLaboratorio.Name = "btnGuardarAnalisisLaboratorio";
            this.btnGuardarAnalisisLaboratorio.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarAnalisisLaboratorio.TabIndex = 10;
            this.btnGuardarAnalisisLaboratorio.Text = "Guardar";
            this.btnGuardarAnalisisLaboratorio.UseVisualStyleBackColor = true;
            this.btnGuardarAnalisisLaboratorio.Click += new System.EventHandler(this.btnGuardarAnalisisLaboratorio_Click);
            // 
            // dgvListaAnalisisLaboratorio
            // 
            this.dgvListaAnalisisLaboratorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaAnalisisLaboratorio.Location = new System.Drawing.Point(63, 87);
            this.dgvListaAnalisisLaboratorio.Name = "dgvListaAnalisisLaboratorio";
            this.dgvListaAnalisisLaboratorio.ReadOnly = true;
            this.dgvListaAnalisisLaboratorio.Size = new System.Drawing.Size(246, 150);
            this.dgvListaAnalisisLaboratorio.TabIndex = 9;
            this.dgvListaAnalisisLaboratorio.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaAnalisisLaboratorio_CellClick);
            // 
            // txtAnalisisLaboratorio
            // 
            this.txtAnalisisLaboratorio.Location = new System.Drawing.Point(99, 22);
            this.txtAnalisisLaboratorio.Name = "txtAnalisisLaboratorio";
            this.txtAnalisisLaboratorio.Size = new System.Drawing.Size(207, 20);
            this.txtAnalisisLaboratorio.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre método:";
            // 
            // txtDescripcionAnalisisLaboratorio
            // 
            this.txtDescripcionAnalisisLaboratorio.Location = new System.Drawing.Point(99, 61);
            this.txtDescripcionAnalisisLaboratorio.Name = "txtDescripcionAnalisisLaboratorio";
            this.txtDescripcionAnalisisLaboratorio.Size = new System.Drawing.Size(207, 20);
            this.txtDescripcionAnalisisLaboratorio.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Descripción:";
            // 
            // ActualizarAnalisisLaboratorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 278);
            this.Controls.Add(this.txtDescripcionAnalisisLaboratorio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalirAnalisisLaboratorio);
            this.Controls.Add(this.btnCancelarAnalisisLaboratorio);
            this.Controls.Add(this.btnEliminarAnalisisLaboratorio);
            this.Controls.Add(this.btnGuardarAnalisisLaboratorio);
            this.Controls.Add(this.dgvListaAnalisisLaboratorio);
            this.Controls.Add(this.txtAnalisisLaboratorio);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualizarAnalisisLaboratorio";
            this.Text = "ActualizarAnalisisLaboratorio";
            this.Load += new System.EventHandler(this.ActualizarAnalisisLaboratorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaAnalisisLaboratorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalirAnalisisLaboratorio;
        private System.Windows.Forms.Button btnCancelarAnalisisLaboratorio;
        private System.Windows.Forms.Button btnEliminarAnalisisLaboratorio;
        private System.Windows.Forms.Button btnGuardarAnalisisLaboratorio;
        private System.Windows.Forms.DataGridView dgvListaAnalisisLaboratorio;
        private System.Windows.Forms.TextBox txtAnalisisLaboratorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcionAnalisisLaboratorio;
        private System.Windows.Forms.Label label2;
    }
}