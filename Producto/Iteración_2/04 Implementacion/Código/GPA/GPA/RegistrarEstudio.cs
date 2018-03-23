using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Clases;
using DAO;
using GPA;

namespace GPA
{
    public partial class RegistrarEstudio : Form
    {
        private int idEstudio;

        public RegistrarEstudio(int idEstudio)
        {
            InitializeComponent();
            this.idEstudio = idEstudio;
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarComboInstituciones();
        }
        public void cargarComboInstituciones()
        {
            cboInstitucion.DataSource = InstitucionDAO.buscarInstituciones();
            cboInstitucion.ValueMember = "id_institucion";
            cboInstitucion.DisplayMember = "nombre";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        public void limpiar()
        {
            txtNombrePractica.Clear();
            txtInforme.Clear();
            txtDoctorACargo.Clear();
            
            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarInstitucion_Click(object sender, EventArgs e)
        {
   
        }
        private void btnRegInstitucion_Click(object sender, EventArgs e)
        {
          

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
        private void btnAgregarInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion ri = new RegistrarInstitucion();
            ri.ShowDialog();
            cargarComboInstituciones();
        }
    }
}
