using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Entidades.Clases;
using GPA.Manejadores;
using GPA;
namespace GPA
{
    public partial class RegistrarLaboratorio : Form
    {
        ManejadorRegistrarLaboratorio manejadorRegistrarLaboratorio;
        public RegistrarLaboratorio(string analisis)
        {
            InitializeComponent();
            txtAnalisisSolicitado.Text = analisis;
        }

        private void btnAgregarInstitucion_Click(object sender, EventArgs e)
        {
            RegistrarInstitucion ri = new RegistrarInstitucion();
            ri.ShowDialog();
            cargarComboInstituciones();
        }
        public void cargarComboInstituciones()
        {
            cboInstitucion.DataSource = InstitucionDAO.buscarInstituciones();
            cboInstitucion.ValueMember = "id_institucion";
            cboInstitucion.DisplayMember = "nombre";
        }
        private void RegistrarLaboratorio_Load(object sender, EventArgs e)
        {
            manejadorRegistrarLaboratorio = new ManejadorRegistrarLaboratorio();
            cargarComboInstituciones();
            cargarComboMetodosAnalisisLaboratorio();
            cargarColumnasGrillaItemEstudios();
            mtbFechaPractica.Text = DateTime.Now.ToShortDateString();
            obtenerItemLaboratorio();
            cargarComboUnidadDeMedida();
            cargarColumnasGrillaResultados();
        }
        private void btnAgregarMetodoAnalisisLaboratorio_Click(object sender, EventArgs e)
        {
            cargarColumnasGrillaItemEstudios();
            ActualizarMetodoAnalisisLaboratorio am = new ActualizarMetodoAnalisisLaboratorio();
            am.ShowDialog();
            cargarComboMetodosAnalisisLaboratorio();

        }
        public void cargarComboUnidadDeMedida()
        {
            Utilidades.cargarCombo(cboUnidadDeMedida, manejadorRegistrarLaboratorio.obtenerUnidadesDeMedida(), "id_unidadMedida", "nombre");
        }
        public void cargarComboMetodosAnalisisLaboratorio()
        {
            List<MetodoAnalisisLaboratorio> metodos = manejadorRegistrarLaboratorio.obtenerMetodosAnalisisLaboratorio();
            Utilidades.cargarCombo(cboMetodoAnalisisLaboratorio, metodos, "id_metodo", "nombre");
        }
        public void obtenerItemLaboratorio()
        {
            dgvListadoItemsEstudioLaboratorio.Rows.Clear();
            List<ItemLaboratorio> items = manejadorRegistrarLaboratorio.obtenerItemLaboratorio();

            if (items != null && items.Count > 0)
            {
                foreach(ItemLaboratorio i in items)
                {
                    dgvListadoItemsEstudioLaboratorio.Rows.Add(i.idItemLaboratorio, i.nombre);
                }
            }
            else
            {
                Utilidades.mostrarFilaNoSeEncontraronResultados(dgvListadoItemsEstudioLaboratorio);
            }
            dgvListadoItemsEstudioLaboratorio.Columns[0].Visible = false;
        }
        public void obtenerItemLaboratorio(string nombre)
        {
            dgvListadoItemsEstudioLaboratorio.Rows.Clear();
            List<ItemLaboratorio> items = manejadorRegistrarLaboratorio.buscarItemLaboratorio(nombre);

            if (items != null && items.Count > 0)
            {
                foreach (ItemLaboratorio i in items)
                {
                    dgvListadoItemsEstudioLaboratorio.Rows.Add(i.idItemLaboratorio, i.nombre);
                }
            }
            else
            {
                Utilidades.mostrarFilaNoSeEncontraronResultados(dgvListadoItemsEstudioLaboratorio);
            }
            dgvListadoItemsEstudioLaboratorio.Columns[0].Visible = false;
        }
        public void cargarColumnasGrillaItemEstudios()
        {
            List<String> columnas = new List<string>();
            columnas.Add("id");
            columnas.Add("nombre");

            Utilidades.agregarColumnasDataGridView(dgvListadoItemsEstudioLaboratorio, columnas);
        }
        public void cargarColumnasGrillaResultados()
        {
            List<String> columnas = new List<string>();

            columnas.Add("Nombre");
            columnas.Add("Resultado");
            columnas.Add("Unidad de Medida");
            columnas.Add("Método");

            Utilidades.agregarColumnasDataGridView(dgvListaResultadosAnalisis, columnas);
        }
        private void btnNuevoAnalisis_Click(object sender, EventArgs e)
        {
            Registrar_Análisis_de_Laboratorio ra = new Registrar_Análisis_de_Laboratorio();
            if (ra.ShowDialog() == DialogResult.OK)
            {
                dgvListadoItemsEstudioLaboratorio.Rows.Clear();
                obtenerItemLaboratorio();
            }
        }

        private void btnBuscarItemEstudioLaboratorio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEstudioBuscado.Text))
            {
                MessageBox.Show("Debe ingresar un estudio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            obtenerItemLaboratorio(txtEstudioBuscado.Text);

        }

        private void txtEstudioBuscado_TextChanged(object sender, EventArgs e)
        {
            obtenerItemLaboratorio(txtEstudioBuscado.Text);
        }

        private void dgvListadoItemsEstudioLaboratorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string valor=(string)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(valor))
            {
                txtEstudioSeleccionado.Text = valor;
            }
        }

        private void btnAgregarUnidadMedida_Click(object sender, EventArgs e)
        {
            ActualizarUnidadMedida au = new ActualizarUnidadMedida();
            if (au.ShowDialog() == DialogResult.OK)
            {
                cargarComboUnidadDeMedida();
            }
        }

        private void btnAgregarResultadoAnalisis_Click(object sender, EventArgs e)
        {
            MetodoAnalisisLaboratorio metodo = (MetodoAnalisisLaboratorio)cboMetodoAnalisisLaboratorio.SelectedItem;

            UnidadDeMedida unidad= (UnidadDeMedida) cboUnidadDeMedida.SelectedItem;

            dgvListaResultadosAnalisis.Rows.Add(txtEstudioSeleccionado.Text, txtResultado.Text, unidad.nombre, metodo.nombre);
        }
    }
}
