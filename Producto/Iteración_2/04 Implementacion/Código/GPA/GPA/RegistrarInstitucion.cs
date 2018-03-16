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
        
        //private  ManejadorRegistrarEstudio manejador= new ManejadorRegistrarEstudio();
        private ManejadorRegistrarInstitucion manejadorRegistrarInstitucion;
        private Institucion institucion;
        public RegistrarInstitucion()
        {
            InitializeComponent();
            manejadorRegistrarInstitucion = new ManejadorRegistrarInstitucion();
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

            agregarColumnasAGrilla();
            agregarInstitucionesRegistradas();
           
        }
        public void agregarColumnasAGrilla()
        {
            List<String> columnas = new List<string>();
            columnas.Add("id");
            columnas.Add("Nombre");
            columnas.Add("Descripción");

            Utilidades.agregarColumnasDataGridView(dgvInstituciones, columnas);
        }
        public void agregarInstitucionesRegistradas()
        {
            List<Institucion> instituciones = manejadorRegistrarInstitucion.obtenerInstituciones();
            foreach (Institucion ins in instituciones)
            {
                dgvInstituciones.Rows.Add(ins.id, ins.nombre, ins.descripcion);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (institucion == null)
            {
                institucion = new Institucion();
                institucion.nombre = txtNombre.Text;
                institucion.descripcion = txtDescripcion.Text;

                manejadorRegistrarInstitucion.registrarInstitucion(institucion);
            }
            else
            {
                
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    institucion.nombre = txtNombre.Text;
                else
                {
                    MessageBox.Show("Falta ingresar el nombre!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!string.IsNullOrEmpty(txtDescripcion.Text))
                    institucion.descripcion = txtDescripcion.Text;

                manejadorRegistrarInstitucion.editarInstitucion(institucion);
            }
            dgvInstituciones.Rows.Clear();
            agregarInstitucionesRegistradas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
          
        }

        private void dgvInstituciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((int)dgvInstituciones.CurrentRow.Cells[0].Value > 0)
            {
                int id = (int)dgvInstituciones.CurrentRow.Cells[0].Value;
                institucion = manejadorRegistrarInstitucion.buscarIdInstitucion(id);
                txtNombre.Text = institucion.nombre;
                txtDescripcion.Text = institucion.descripcion;
            }


        }
     
    }
}
