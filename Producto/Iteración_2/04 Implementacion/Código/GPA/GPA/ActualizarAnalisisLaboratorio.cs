using Entidades.Clases;
using LogicaNegocio;
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
    public partial class ActualizarAnalisisLaboratorio : Form
    {
        private AnalisisLaboratorio analisis;
        public ActualizarAnalisisLaboratorio()
        {
            InitializeComponent();
        }

        private void ActualizarAnalisisLaboratorio_Load(object sender, EventArgs e)
        {
            agregarColumnas();
            nuevo();
        }
        public void agregarColumnas()
        {
            List<string> columnasDataDgv = new List<string>();
            columnasDataDgv.Add("id_analisis");
            columnasDataDgv.Add("nombre");
            columnasDataDgv.Add("descripción");

            Utilidades.agregarColumnasDataGridView(dgvListaAnalisisLaboratorio, columnasDataDgv);
            dgvListaAnalisisLaboratorio.Columns[0].Visible = false;
        }
        public void nuevo()
        {
            cargarGrilla();
            txtAnalisisLaboratorio.Clear();
            txtDescripcionAnalisisLaboratorio.Clear();
            btnEliminarAnalisisLaboratorio.Enabled = false;
            analisis = null;
        }
        private void cargarGrilla()
        {
            dgvListaAnalisisLaboratorio.Rows.Clear();

            List<AnalisisLaboratorio> listaAnalisis = AnalisisLaboratorioLN.MostrarAnalisisLaboratorio();

            foreach (AnalisisLaboratorio m in listaAnalisis)
            {   
                if(m.nombre.Equals("--Seleccionar--")==false)
                    dgvListaAnalisisLaboratorio.Rows.Add(m.id_analisis, m.nombre,m.descripcion);
            }
        }

        private void btnGuardarAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            if (analisis == null)
            {
                analisis = new AnalisisLaboratorio();
                if (!string.IsNullOrEmpty(txtAnalisisLaboratorio.Text))
                {
                    analisis.nombre = txtAnalisisLaboratorio.Text;
                    analisis.descripcion = txtDescripcionAnalisisLaboratorio.Text;
                }
                else
                {
                    MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AnalisisLaboratorioLN.insertAnalisisLaboratorio(analisis);
                cargarGrilla();
                txtAnalisisLaboratorio.Clear();
                txtDescripcionAnalisisLaboratorio.Clear();
                
            }
            else
            {
                if (!string.IsNullOrEmpty(txtAnalisisLaboratorio.Text))
                {
                    analisis.nombre = txtAnalisisLaboratorio.Text;
                    analisis.descripcion = txtDescripcionAnalisisLaboratorio.Text;

                }
                else
                {
                    MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                AnalisisLaboratorioLN.updateAnalisisLaboratorio(analisis);
                cargarGrilla();
            }
            analisis = null;
        }

        private void dgvListaAnalisisLaboratorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvListaAnalisisLaboratorio.CurrentRow.Cells[0].Value;
            analisis = AnalisisLaboratorioLN.obtenerAnalisisLaboratorioPorId(id);
            if (analisis != null)
            {
                txtAnalisisLaboratorio.Text = analisis.nombre;
                txtDescripcionAnalisisLaboratorio.Text = analisis.descripcion;
            }
            btnEliminarAnalisisLaboratorio.Enabled = true;
        }
    }
}
