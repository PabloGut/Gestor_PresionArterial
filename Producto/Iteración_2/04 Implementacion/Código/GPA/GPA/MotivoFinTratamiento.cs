using Entidades.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPA
{
    public partial class MotivoFinTratamiento : Form
    {
        public Tratamiento tratamiento { get; set; }
        public MotivoFinTratamiento()
        {
            InitializeComponent();
        }

        private void MotivoFinTratamiento_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMotivoFinTratamiento.Text))
            {
                tratamiento = new Tratamiento();
                tratamiento.fechaFin = DateTime.Now;
                tratamiento.motivoFin = txtMotivoFinTratamiento.Text;

                DialogResult = DialogResult.OK;
            }
           
        }
    }
}
