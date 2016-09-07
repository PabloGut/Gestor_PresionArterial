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
        ManejadorRegistrarEstudio manejador;
        MenuPrincipal referenciaMenuPrincipal;
        private int idhcPaciente;

        public RegistrarEstudio()
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarEstudio();
        }
        public RegistrarEstudio(MenuPrincipal mp)
        {
            InitializeComponent();
            manejador = new ManejadorRegistrarEstudio();
            referenciaMenuPrincipal = mp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarComboInstituciones();
            mtbFechaEstudio.Text = Convert.ToString(DateTime.Today);

            
        }
        public void IdHCPaciente(int idhc)
        {
            idhcPaciente = idhc;
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
            MessageBox.Show("Estudio registrado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiar();
        }
        public void limpiar()
        {
            txtNombreEstudio.Clear();
            txtInforme.Clear();
            txtDoctorACargo.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            
        }
        public Estudio crearEstudio()
        {
            Estudio est = new Estudio();
            est.nombre = txtNombreEstudio.Text;
            est.fecha = Convert.ToDateTime(mtbFechaEstudio.Text);
            est.doctorACargo = txtDoctorACargo.Text;
            est.informeEstudio = txtInforme.Text;
            est.id_institucion = Convert.ToInt32(cboInstitucion.SelectedValue);
            est.id_hc = idhcPaciente;

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
                //txtNumero.Text = domicilio[0].numero;

            }
        }

        private void btnRegInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion regIns = new RegistrarInstitucion(cboInstitucion);
            regIns.ShowDialog();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            referenciaMenuPrincipal.Show();
            this.Hide(); 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            referenciaMenuPrincipal.Show();
            
            
        }
    }
}
