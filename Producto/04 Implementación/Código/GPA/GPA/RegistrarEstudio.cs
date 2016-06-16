using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using DAO;
namespace GPA
{
    public partial class RegistrarEstudio : Form
    {
        Entidades.Manejadores.ManejadorRegistrarEstudio manejador;
        public RegistrarEstudio()
        {
            InitializeComponent();
            manejador = new Entidades.Manejadores.ManejadorRegistrarEstudio();
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
            DateTime? fecha = null;

            if (string.IsNullOrEmpty(txtNombreEstudio.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del estudio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombreEstudio.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(mtbFechaEstudio.Text))
                fecha = Convert.ToDateTime(mtbFechaEstudio);

            if (string.IsNullOrEmpty(txtDoctorACargo.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del doctor a cargo del estudio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDoctorACargo.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInforme.Text))
            {
                MessageBox.Show("Debe ingresar el informe del estudio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtInforme.Focus();
                return;
            }
            manejador.nombreEstudioIngresado(txtNombreEstudio.Text);
            manejador.fechaEstudioIngresado(Convert.ToDateTime(mtbFechaEstudio));
            manejador.doctorACargoIngresado(txtDoctorACargo.Text);
            manejador.InformeIngresado(txtInforme.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarInstitucion_Click(object sender, EventArgs e)
        {
            int id_institucion = Convert.ToInt32(cboInstitucion.SelectedValue);
            List<Entidades.Clases.Domicilio> domicilio = InstitucionDAO.buscarDomicilioInstitucion(id_institucion);

            if (domicilio.Count() > 0)
            {
                txtCalle.Text = domicilio[0].calle;
                txtNumero.Text = domicilio[0].numero;

            }
        }
    }
}
