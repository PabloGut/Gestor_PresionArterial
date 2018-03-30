using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades.Clases;

namespace GPA
{
    public partial class ActualizarUnidadMedida : Form
    {
        private UnidadDeMedida unidadDeMedida{set;get;}

        public ActualizarUnidadMedida()
        {
            InitializeComponent();
        }

        private void btnRegistrarUnidadMedida_Click(object sender, EventArgs e)
        {   
            if (string.IsNullOrEmpty(txtNombreUnidadMedida.Text) == true)
            {
                MessageBox.Show("Falta ingresar las siglas de la unidad de medida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (unidadDeMedida == null)
            {
                unidadDeMedida = new UnidadDeMedida();
                unidadDeMedida.nombre = txtNombreUnidadMedida.Text;

                if (!string.IsNullOrEmpty(txtDescripcionUnidadMedida.Text))
                    unidadDeMedida.descripcion = txtDescripcionUnidadMedida.Text;

                UnidadMedidaLN.registrarUnidadDeMedida(unidadDeMedida);

                unidadDeMedida = null;
            }
            else
            {
                unidadDeMedida.nombre = txtNombreUnidadMedida.Text;
                unidadDeMedida.descripcion = txtDescripcionUnidadMedida.Text;
                UnidadMedidaLN.updateUnidadMedida(unidadDeMedida);
               
            }
            nuevo();
            cargarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (unidadDeMedida != null)
            {
                UnidadMedidaLN.deleteUnidadMedida(unidadDeMedida.id_unidadMedida);
                //cargar grilla con unidades.
            }


        }
        public void cargarColumnasGrilla()
        {
            List<String> columnas = new List<string>();
            columnas.Add("id");
            columnas.Add("Nombre");
            columnas.Add("Descripción");
            Utilidades.agregarColumnasDataGridView(dgvUnidadesDeMedida,columnas);
            dgvUnidadesDeMedida.Columns[0].Visible = false;
        }
        public void cargarGrilla()
        {
            dgvUnidadesDeMedida.Rows.Clear();
            List<UnidadDeMedida> unidades= UnidadMedidaLN.mostrarUnidadesDeMedida();
            foreach (UnidadDeMedida unidad in unidades)
            {
                dgvUnidadesDeMedida.Rows.Add(unidad.id_unidadMedida, unidad.nombre, unidad.descripcion);
            }
            //dgvUnidadesDeMedida.DataSource = unidades;
        }

        private void ActualizarUnidadMedida_Load(object sender, EventArgs e)
        {
            cargarColumnasGrilla();
            cargarGrilla();
            nuevo();
           
        }

        private void dgvUnidadesDeMedida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            unidadDeMedida= new UnidadDeMedida();
            unidadDeMedida.id_unidadMedida = (int)dgvUnidadesDeMedida.CurrentRow.Cells[0].Value;
            unidadDeMedida.nombre = (string)dgvUnidadesDeMedida.CurrentRow.Cells[1].Value;
            unidadDeMedida.descripcion = (string)dgvUnidadesDeMedida.CurrentRow.Cells[2].Value;

            txtNombreUnidadMedida.Text = unidadDeMedida.nombre;
            txtDescripcionUnidadMedida.Text = unidadDeMedida.descripcion;
            btnEliminar.Enabled = true;
        }
        public void nuevo()
        {
            txtNombreUnidadMedida.Clear();
            txtDescripcionUnidadMedida.Clear();
            btnEliminar.Enabled = false;
            unidadDeMedida = null;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
