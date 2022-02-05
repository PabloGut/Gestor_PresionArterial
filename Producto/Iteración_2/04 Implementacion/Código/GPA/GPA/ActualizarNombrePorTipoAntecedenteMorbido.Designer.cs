namespace GPA
{
    partial class ActualizarNombrePorTipoAntecedenteMorbido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarNombrePorTipoAntecedenteMorbido));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAntecedenteMórbido = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.brnSalir = new System.Windows.Forms.Button();
            this.cboTipoAntecedenteMorbido = new System.Windows.Forms.ComboBox();
            this.dgvTipoAntecedenteMorbido = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoAntecedenteMorbido)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Antecedente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // txtAntecedenteMórbido
            // 
            this.txtAntecedenteMórbido.Location = new System.Drawing.Point(150, 68);
            this.txtAntecedenteMórbido.Name = "txtAntecedenteMórbido";
            this.txtAntecedenteMórbido.Size = new System.Drawing.Size(121, 20);
            this.txtAntecedenteMórbido.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(81, 111);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(162, 111);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 5;
            this.btnNuevo.Text = "Nueva";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // brnSalir
            // 
            this.brnSalir.Location = new System.Drawing.Point(243, 111);
            this.brnSalir.Name = "brnSalir";
            this.brnSalir.Size = new System.Drawing.Size(75, 23);
            this.brnSalir.TabIndex = 6;
            this.brnSalir.Text = "Salir";
            this.brnSalir.UseVisualStyleBackColor = true;
            this.brnSalir.Click += new System.EventHandler(this.brnSalir_Click);
            // 
            // cboTipoAntecedenteMorbido
            // 
            this.cboTipoAntecedenteMorbido.FormattingEnabled = true;
            this.cboTipoAntecedenteMorbido.Location = new System.Drawing.Point(150, 25);
            this.cboTipoAntecedenteMorbido.Name = "cboTipoAntecedenteMorbido";
            this.cboTipoAntecedenteMorbido.Size = new System.Drawing.Size(121, 21);
            this.cboTipoAntecedenteMorbido.TabIndex = 7;
            this.cboTipoAntecedenteMorbido.SelectedIndexChanged += new System.EventHandler(this.cboTipoAntecedenteMorbido_SelectedIndexChanged);
            // 
            // dgvTipoAntecedenteMorbido
            // 
            this.dgvTipoAntecedenteMorbido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTipoAntecedenteMorbido.Location = new System.Drawing.Point(12, 152);
            this.dgvTipoAntecedenteMorbido.Name = "dgvTipoAntecedenteMorbido";
            this.dgvTipoAntecedenteMorbido.Size = new System.Drawing.Size(413, 150);
            this.dgvTipoAntecedenteMorbido.TabIndex = 8;
            this.dgvTipoAntecedenteMorbido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoAntecedenteMorbido_CellClick);
            this.dgvTipoAntecedenteMorbido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTipoAntecedenteMorbido_CellContentClick);
            // 
            // ActualizarNombrePorTipoAntecedenteMorbido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 308);
            this.Controls.Add(this.dgvTipoAntecedenteMorbido);
            this.Controls.Add(this.cboTipoAntecedenteMorbido);
            this.Controls.Add(this.brnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtAntecedenteMórbido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActualizarNombrePorTipoAntecedenteMorbido";
            this.Load += new System.EventHandler(this.ActualizarNombrePorTipoAntecedenteMorbido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTipoAntecedenteMorbido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAntecedenteMórbido;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button brnSalir;
        private System.Windows.Forms.ComboBox cboTipoAntecedenteMorbido;
        private System.Windows.Forms.DataGridView dgvTipoAntecedenteMorbido;
    }
}