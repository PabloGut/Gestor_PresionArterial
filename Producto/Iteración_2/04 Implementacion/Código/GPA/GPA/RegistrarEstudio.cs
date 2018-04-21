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
using GPA.Manejadores;

namespace GPA
{
    public partial class RegistrarEstudio : Form
    {
        public EstudioDiagnosticoPorImagen estudio{set;get;}
        public PracticaComplementaria practica { set; get; }
        private ManejadorRegistrarEstudiosPracticas manejador;
        public RegistrarEstudio(EstudioDiagnosticoPorImagen estudio)
        {
            InitializeComponent();
            this.estudio = estudio;
            practica = null;
            txtNombrePractica.Text = estudio.nombreEstudio.nombre;
            manejador = new ManejadorRegistrarEstudiosPracticas();
           
        }
        public RegistrarEstudio(PracticaComplementaria practica)
        {
            InitializeComponent();
            this.practica = practica;
            estudio = null;
            txtNombrePractica.Text = practica.tipo.nombre;
            manejador = new ManejadorRegistrarEstudiosPracticas();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cargarComboInstituciones();
            cargarDatosDePrueba();
        }
        public void cargarComboInstituciones()
        {
            cboInstitucion.DataSource = InstitucionDAO.buscarInstituciones();
            cboInstitucion.ValueMember = "id_institucion";
            cboInstitucion.DisplayMember = "nombre";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (estudio != null)
            {
                DateTime fechaRealizacion =Convert.ToDateTime(mtbFechaPractica.Text);
                string doctor = txtDoctorACargo.Text;
                int institucion = (int)cboInstitucion.SelectedValue;
                string observaciones = txtObservaciones.Text;
                string informe = txtInforme.Text;

                estudio.fechaRealizacion = fechaRealizacion;
                estudio.DoctorACargo = doctor;
                estudio.idInstitucion = institucion;
                estudio.observaciones = observaciones;
                estudio.informeEstudio = informe;

                estudio.id_nombreEstudio = manejador.obtenerNombreEstudio(txtNombrePractica.Text);

                DialogResult = DialogResult.OK;
            }

            if (practica != null)
            {
                DateTime fechaRealizacion = Convert.ToDateTime(mtbFechaPractica.Text);
                string doctor = txtDoctorACargo.Text;
                int institucion = (int)cboInstitucion.SelectedValue;
                string observaciones = txtObservaciones.Text;
                string informe = txtInforme.Text;

                practica.fechaRealizacion = fechaRealizacion;
                practica.DoctorACargo = doctor;
                practica.idInstitucion = institucion;
                practica.observaciones = observaciones;
                practica.informeEstudio = informe;

                practica.id_tipoPractica = manejador.obtenerTipoPracticaComplementaria(txtNombrePractica.Text);

                DialogResult = DialogResult.OK;
            }
        }
        public void limpiar()
        {
            txtNombrePractica.Clear();
            txtInforme.Clear();
            txtDoctorACargo.Clear();
            txtObservaciones.Clear();
            mtbFechaPractica.Clear();
            
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
            limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAgregarInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion ri = new RegistrarInstitucion();
            ri.ShowDialog();
            cargarComboInstituciones();
        }
        public void cargarDatosDePrueba()
        {
            mtbFechaPractica.Text = "20/04/2018";
            txtDoctorACargo.Text = "Juncos";
            txtInforme.Text = "Normales";
            txtObservaciones.Text = "Normales";
        }
    }
}
