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
using GPA.Manejadores;

namespace GPA
{
    public partial class ActualizarMetodoAnalisisLaboratorio : Form
    {
        private  ManejadorActualizarMetodoAnalisisLaboratorio manejadorActualizarMetodo;
        private MetodoAnalisisLaboratorio metodoAnalisis;
        public ActualizarMetodoAnalisisLaboratorio()
        {
            InitializeComponent();
           
        }

        private void ActualizarMetodoAnalisisLaboratorio_Load(object sender, EventArgs e)
        {
            manejadorActualizarMetodo = new ManejadorActualizarMetodoAnalisisLaboratorio();
            agregarColumnas();
            nuevo();
        }
        public void agregarColumnas()
        {
            List<string> columnasDataDgv = new List<string>();
            columnasDataDgv.Add("id_metodo");
            columnasDataDgv.Add("nombre");

            Utilidades.agregarColumnasDataGridView(dgvListaMetodosAnalisisLaboratorio, columnasDataDgv);
            dgvListaMetodosAnalisisLaboratorio.Columns[0].Visible = false;
        }
        private void cargarGrilla()
        {
            dgvListaMetodosAnalisisLaboratorio.Rows.Clear();

            List<MetodoAnalisisLaboratorio> metodos = manejadorActualizarMetodo.obtenerMetodosAnalisisLaboratorio();

            foreach (MetodoAnalisisLaboratorio m in metodos)
            {
                dgvListaMetodosAnalisisLaboratorio.Rows.Add(m.idMetodo, m.nombre);
            }
        }
        public void nuevo()
        {
            cargarGrilla();
            txtMetodoAnalisisLaboratorio.Clear();
            btnEliminarMetodoAnalisisLaboratorio.Enabled = false;
            metodoAnalisis = null;
        }

        private void btnGuardarMetodoAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            if (metodoAnalisis == null)
            {
                metodoAnalisis = new MetodoAnalisisLaboratorio();
                if (!string.IsNullOrEmpty(txtMetodoAnalisisLaboratorio.Text))
                {
                    metodoAnalisis.nombre = txtMetodoAnalisisLaboratorio.Text;
                }
                else
                {
                    MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                manejadorActualizarMetodo.insertMetodoAnalisisLaboratorio(metodoAnalisis);
                cargarGrilla();
                txtMetodoAnalisisLaboratorio.Clear();
            }
            else
            {
                if (!string.IsNullOrEmpty(txtMetodoAnalisisLaboratorio.Text))
                {
                    metodoAnalisis.nombre = txtMetodoAnalisisLaboratorio.Text;
                }
                else
                {
                    MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                manejadorActualizarMetodo.updateMetodoAnalisisLaboratorio(metodoAnalisis);
                cargarGrilla();
            }
        }

        private void dgvListaMetodosAnalisisLaboratorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id =(int) dgvListaMetodosAnalisisLaboratorio.CurrentRow.Cells[0].Value;
            metodoAnalisis = manejadorActualizarMetodo.obtenerMetodoAnalisisLaboratorio(id);
            if (metodoAnalisis != null)
            {
                txtMetodoAnalisisLaboratorio.Text = metodoAnalisis.nombre;
            }
            btnEliminarMetodoAnalisisLaboratorio.Enabled = true;
        }

        private void btnEliminarMetodoAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            if (metodoAnalisis != null)
            {
                manejadorActualizarMetodo.deleteMetodoAnalisisLaboratorio(metodoAnalisis);
                nuevo();
            }
        }

        private void btnCancelarMetodoAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}
