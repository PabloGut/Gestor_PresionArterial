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
using Manejadores;

namespace GPA
{
    public partial class RegistrarEstudio : Form
    {
        ManejadorRegistrarEstudio manejador;

        public RegistrarEstudio()
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarEstudio();
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

            Estudio estudio = crearEstudio();
            manejador.registrarEstudio(estudio);
        }
        public Estudio crearEstudio()
        {
            Estudio est = new Estudio();
            est.nombre = txtNombreEstudio.Text;
            est.fecha = Convert.ToDateTime(mtbFechaEstudio.Text);
            est.doctorACargo = txtDoctorACargo.Text;
            est.informeEstudio = txtInforme.Text;
            est.id_institucion = Convert.ToInt32(cboInstitucion.SelectedValue);
            est.id_hc = 1;
            return est;


            
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarInstitucion_Click(object sender, EventArgs e)
        {
            int id_institucion = Convert.ToInt32(cboInstitucion.SelectedValue);
            List<Entidades.Clases.Domicilio> domicilio=manejador.obtenerDomicilioInstitucion(id_institucion);

            if (domicilio.Count() > 0)
            {
                txtCalle.Text = domicilio[0].calle;
                txtNumero.Text = domicilio[0].numero;

            }
        }

        private void btnRegInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion regIns = new RegistrarInstitucion(cboInstitucion);
            regIns.ShowDialog();


        }
    }
}
