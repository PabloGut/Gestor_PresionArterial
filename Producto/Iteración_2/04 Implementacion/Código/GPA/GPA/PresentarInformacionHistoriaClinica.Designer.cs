namespace GPA
{
    partial class frmInformacionHistoriaClinica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInformacionHistoriaClinica));
            this.txtInfoHc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInfoHc
            // 
            this.txtInfoHc.Location = new System.Drawing.Point(12, 12);
            this.txtInfoHc.Multiline = true;
            this.txtInfoHc.Name = "txtInfoHc";
            this.txtInfoHc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoHc.Size = new System.Drawing.Size(574, 237);
            this.txtInfoHc.TabIndex = 0;
            // 
            // frmInformacionHistoriaClinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 261);
            this.Controls.Add(this.txtInfoHc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInformacionHistoriaClinica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Información de historia clínica";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInfoHc;

    }
}