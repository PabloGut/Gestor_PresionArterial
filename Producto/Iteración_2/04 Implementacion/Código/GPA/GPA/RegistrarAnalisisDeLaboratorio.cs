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
using LogicaNegocio;
using GPA.Manejadores;
namespace GPA
{
    public partial class Registrar_Análisis_de_Laboratorio : Form
    {
        private ManejadorEstudiosLaboratorio manejador;
        private List<ItemEstudioLaboratorio> listaItemsLaboratorio;
        private List<DetalleItemLaboratorio> listaDetalles;
        private List<DetalleValorReferenciaLaboratorio> listaDetalleValorReferencia;

        public Registrar_Análisis_de_Laboratorio()
        {
            InitializeComponent();
            manejador = new ManejadorEstudiosLaboratorio();
        }

        private void Registrar_Análisis_de_Laboratorio_Load(object sender, EventArgs e)
        {
            cargarCombosYGrilla();
            panelDetalleItem.Enabled = false;
            panelDetalleValorReferencia.Enabled = false;
            cbUnidadMedidaValorReferencia.Checked = true;
            cbUnidadMedidaDetalleValorReferencia.Checked = true;
        }
        public void cargarCombosYGrilla()
        {
            Utilidades.cargarCombo(cboUnidadMedida,UnidadMedidaLN.mostrarUnidadesDeMedida(),"id_unidadMedida","nombre");
            Utilidades.cargarCombo(cboUnidadMedidaDetalleValorReferencia, UnidadMedidaLN.mostrarUnidadesDeMedida(), "id_unidadMedida", "nombre");

            List<String> columnasValorReferencia= new List<string>();
            columnasValorReferencia.Add("Nombre");
            columnasValorReferencia.Add("Valor Mínimo");
            columnasValorReferencia.Add("Valor Máximo");
            columnasValorReferencia.Add("Unidad Medida");
            Utilidades.agregarColumnasDataGridView(dgvValoresReferencia, columnasValorReferencia);

            List<String> columnasDetalleValorReferencia = new List<string>();
            columnasDetalleValorReferencia.Add("Descripción");
            columnasDetalleValorReferencia.Add("Valor Mínimo");
            columnasDetalleValorReferencia.Add("Valor Máximo");
            columnasDetalleValorReferencia.Add("Unidad Medida");
            Utilidades.agregarColumnasDataGridView(dgvDetallesValorReferencia, columnasValorReferencia);
        }
        private void cbAgregarDetalles_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if (cbAgregarDetalles.Checked)
            {
                lblValoresReferencia.Hide();
                lblDesde.Hide();
                lblHasta.Hide();
                txtDesde.Hide();
                txtHasta.Hide();

                gbDetallesValoresDeReferencia.Show();

            }
            else
            {
                lblValoresReferencia.Show();
                lblDesde.Show();
                lblHasta.Show();
                txtDesde.Show();
                txtHasta.Show();

                gbDetallesValoresDeReferencia.Hide();
 
            }
           */
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La institución no se registró correctamente! \n Se cancela el registro del estudio de laboratorio.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            MessageBox.Show("El estudio de laboratorio se registró correctamente!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbAgregarValoresReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarValoresReferencia.Checked == true)
            {
                panelDetalleItem.Enabled = true;
                if (cbAgregarDetalleValorReferencia.Checked == true)
                {
                    panelDetalleValorReferencia.Enabled = true;
                }
            }
            else
            {
                panelDetalleItem.Enabled = false;
                panelDetalleValorReferencia.Enabled = false;
            }
        }

        private void cbAgregarDetalleValorReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgregarDetalleValorReferencia.Checked == true)
            {   
                panelDetalleValorReferencia.Enabled = true;
            }
            else
            {
                panelDetalleValorReferencia.Enabled = false;
            }
        }

        private void btnAgregarAnalisis_Click(object sender, EventArgs e)
        {
            agregarEstudioLaboratorio();
        }
        public void agregarEstudioLaboratorio()
        {
            if (listaItemsLaboratorio == null)
                listaItemsLaboratorio = new List<ItemEstudioLaboratorio>();

            string nombre=null;
            if (!string.IsNullOrEmpty(txtNombreEstudioLaboratorio.Text))
                nombre = txtNombreEstudioLaboratorio.Text;

            ItemEstudioLaboratorio item = manejador.crearItemEstudioLaboratorio(nombre);

            if (cbAgregarValoresReferencia.Checked == true && listaDetalles!=null && listaDetalles.Count>0)
            {
                item.detalles = listaDetalles;
            }
    
        }

        private void btnAgregarValorReferencia_Click(object sender, EventArgs e)
        {
            agregarDetalleItemLaboratorio();
        }
        public void agregarDetalleItemLaboratorio()
        {    
            string nombre=null;
            float valorMinimo=0;
            float valorMaximo=0;
            int unidadMedida=0;

            if (!string.IsNullOrEmpty(txtNombreDetalleItem.Text))
                nombre = txtNombreDetalleItem.Text;
            if (!string.IsNullOrEmpty(txtValorMinimoReferencia.Text))
                valorMinimo = float.Parse(txtValorMinimoReferencia.Text);
            if (!string.IsNullOrEmpty(txtValorMaximoReferencia.Text))
                valorMaximo = float.Parse(txtValorMaximoReferencia.Text);

            UnidadDeMedida unidad = null;
            if (cboUnidadMedida.Enabled==true)
            {
                unidad = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
                unidadMedida = unidad.id_unidadMedida;
            }

            if (listaDetalles == null)
                listaDetalles = new List<DetalleItemLaboratorio>();

            DetalleItemLaboratorio detalleItem = manejador.crearDetalleItemLaboratorio(nombre, valorMinimo, valorMaximo, unidadMedida);

            listaDetalles.Add(detalleItem);

            if (cboUnidadMedida.Enabled == true)
            {
                dgvValoresReferencia.Rows.Add(nombre, valorMinimo, valorMaximo, unidadMedida);
            }
            else
            {
                dgvValoresReferencia.Rows.Add(nombre, valorMinimo, valorMaximo, "No seleccionado");
            }
        }
        public void limpiar()
        {
            txtNombreDetalleItem.Clear();
            txtValorMinimoReferencia.Clear();
            txtValorMaximoReferencia.Clear();
            cboUnidadMedida.SelectedIndex = 0;
        }

        private void cbUnidadMedidaValorReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnidadMedidaValorReferencia.Checked == true)
            {
                cboUnidadMedida.Enabled = true;
            }
            else
            {
                cboUnidadMedida.Enabled = false;
            }
        }

        private void cbUnidadMedidaDetalleValorReferencia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUnidadMedidaDetalleValorReferencia.Checked == true)
            {
                cboUnidadMedidaDetalleValorReferencia.Enabled = true;
            }
            else
            {
                cboUnidadMedidaDetalleValorReferencia.Enabled = false;
            }
        }

        private void btnAgregarDetalleValorReferencia_Click(object sender, EventArgs e)
        {
            agregarDetalleValorReferencia();
        }
        public void agregarDetalleValorReferencia()
        {
            string descripcion=null;
            float valorMinimo=0;
            float valorMaximo=0;
            int unidadMedida=0;
            if (!string.IsNullOrEmpty(txtDescripcionDetalleValorReferencia.Text))
                descripcion = txtDescripcionDetalleValorReferencia.Text;
            if (!string.IsNullOrEmpty(txtValorMinimoDetalleValorReferencia.Text))
                valorMinimo = float.Parse(txtValorMinimoDetalleValorReferencia.Text);
            if (!string.IsNullOrEmpty(txtValorMaximoDetalleValorReferencia.Text))
                valorMaximo =float.Parse(txtValorMaximoDetalleValorReferencia.Text);

             UnidadDeMedida unidad=null;
            if (cboUnidadMedidaDetalleValorReferencia.Enabled == true)
            {
                unidad = (UnidadDeMedida)cboUnidadMedidaDetalleValorReferencia.SelectedItem;
                unidadMedida = unidad.id_unidadMedida;
            }

            if (listaDetalleValorReferencia == null)
                listaDetalleValorReferencia = new List<DetalleValorReferenciaLaboratorio>();

            DetalleValorReferenciaLaboratorio detalle = manejador.crearDetalleValorReferencia(descripcion, valorMinimo, valorMaximo, unidadMedida);

            listaDetalleValorReferencia.Add(detalle);

            if (cboUnidadMedidaDetalleValorReferencia.Enabled == true)
            {
                dgvDetallesValorReferencia.Rows.Add(descripcion, valorMinimo, valorMaximo, unidadMedida);
            }
            else
            {
                dgvDetallesValorReferencia.Rows.Add(descripcion, valorMinimo, valorMaximo, "No seleccionado");
            }
        }
    }
}
