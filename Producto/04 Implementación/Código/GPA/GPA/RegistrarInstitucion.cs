using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPA;
using Entidades.Clases;

namespace GPA
{
    public partial class RegistrarInstitucion : Form
    {
        private  ManejadorRegistrarEstudio manejador= new ManejadorRegistrarEstudio();
        private ManejadorRegistrarInstitucion manejadorIns = new ManejadorRegistrarInstitucion();
        private ComboBox comboIns;
        public RegistrarInstitucion(ComboBox cboInstituciones)
        {
            InitializeComponent();
            comboIns = cboInstituciones;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Institucion ins = crearInstitucion();
            Domicilio dom = crearDomicilio();

            manejadorIns.registrarInstitucion(ins, dom);

            MessageBox.Show("Se registro correctamente la Institucion", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

            cargarComboInstituciones();

            
        }
        public void cargarComboInstituciones()
        {
            comboIns.DataSource = manejadorIns.buscarInstituciones();
            comboIns.ValueMember = "id_institucion";
            comboIns.DisplayMember = "nombre";
        }
        public Institucion crearInstitucion()
        {
            Institucion ins = new Institucion();
            ins.nombre = txtNombre.Text;
            ins.descripcion = txtDescripcion.Text;

            return ins;

        }
        public Domicilio crearDomicilio()
        {
            Domicilio dom = new Domicilio();

            dom.calle = txtCalle.Text;
            dom.numero = txtNumero.Text;
            dom.codigoPostal =Convert.ToInt32( txtCodigoPostal.Text);

            if (!String.IsNullOrEmpty(txtPiso.Text))
            {
                dom.piso = Convert.ToInt32(txtPiso.Text);
            }
            else
            {
                dom.piso =-1;
            }
            
            dom.departamento = txtDepto.Text;
            dom.id_barrio =Convert.ToInt32(cboBarrio.SelectedValue);

            return dom;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistrarInstitucion_Load(object sender, EventArgs e)
        {
            cargarComboBarrio();
            cargarComboLocalidades();
        }
        public void cargarComboBarrio()
        {
            
            cboBarrio.DataSource = manejador.buscarBarrios();
            cboBarrio.ValueMember = "id_barrio";
            cboBarrio.DisplayMember = "nombre";
        }
        public void cargarComboLocalidades()
        {
            cboLocalidad.DataSource = manejador.buscarLocalidades();
            cboLocalidad.ValueMember = "id_localidad";
            cboLocalidad.DisplayMember = "nombre";
        }
    }
}
