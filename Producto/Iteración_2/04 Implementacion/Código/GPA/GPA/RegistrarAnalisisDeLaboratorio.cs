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
        private ItemEstudioLaboratorio itemEstudio;
        private DetalleItemLaboratorio detalleItemLaboratorio;
        private DetalleValorReferenciaLaboratorio detalleValorReferencia;

        private ManejadorEstudiosLaboratorio manejador;
        //private List<ItemEstudioLaboratorio> listaItemsLaboratorio;
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
            panelDetalleValorReferencia.Enabled = false;
            cbUnidadMedidaDetalleValorReferencia.Checked = true;
            //cbUnidadMedidaValorReferencia.Checked = true;
            //panelDetalleItem.Enabled = false;
           
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
            /*if (cbAgregarValoresReferencia.Checked == true)
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
            }*/
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

            if (cbAgregarDetalleValorReferencia.Checked == true && string.IsNullOrEmpty(txtDescripcionDetalleValorReferencia.Text))
            {
                MessageBox.Show("Falta datos del detalle del valor de referencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbAgregarDetalleValorReferencia.Checked==true && dgvDetallesValorReferencia.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("No hay datos en la grilla para agregar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (listaDetalles == null)
                listaDetalles = new List<DetalleItemLaboratorio>();

            if (cbAgregarDetalleValorReferencia.Checked == false)
                listaDetalles.Add(detalleItemLaboratorio);
            else
            {
                if (listaDetalleValorReferencia != null && listaDetalleValorReferencia.Count > 0)
                detalleItemLaboratorio.detalle = listaDetalleValorReferencia;
                listaDetalles.Add(detalleItemLaboratorio);
            }

            txtDescripcionDetalleValorReferencia.Clear();
            txtValorMaximoDetalleValorReferencia.Clear();
            txtValorMinimoDetalleValorReferencia.Clear();
            dgvDetallesValorReferencia.Rows.Clear();

            txtNombreDetalleItem.Clear();
            txtValorMaximoReferencia.Clear();
            txtValorMinimoReferencia.Clear();
            btnAgregarValorReferencia.Enabled = true;

            if (listaDetalleValorReferencia != null && listaDetalleValorReferencia.Count > 0)
                listaDetalleValorReferencia=null;
    
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
            else
                valorMinimo = -1;

            if (!string.IsNullOrEmpty(txtValorMaximoReferencia.Text))
                valorMaximo = float.Parse(txtValorMaximoReferencia.Text);
            else
                valorMaximo = -1;

            UnidadDeMedida unidad = null;
            if (cboUnidadMedida.Enabled == true)
            {
                unidad = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
                unidadMedida = unidad.id_unidadMedida;
            }
            else
            {
                unidadMedida = -1;
            }

            detalleItemLaboratorio = manejador.crearDetalleItemLaboratorio(nombre, valorMinimo, valorMaximo, unidadMedida);


            if (cboUnidadMedida.Enabled == true)
            {   
                dgvValoresReferencia.Rows.Add(nombre, valorMinimo, valorMaximo, unidad.nombre);
            }
            else
            {
                dgvValoresReferencia.Rows.Add(nombre, valorMinimo, valorMaximo, "No seleccionado");
            }
            btnAgregarValorReferencia.Enabled = false;

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
            if (string.IsNullOrEmpty(txtDescripcionDetalleValorReferencia.Text))
            {
                MessageBox.Show("Falta datos del detalle del valor de referencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
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
             else
             {
                 unidadMedida = -1;
             }
            if (listaDetalleValorReferencia == null)
                listaDetalleValorReferencia = new List<DetalleValorReferenciaLaboratorio>();

            detalleValorReferencia = manejador.crearDetalleValorReferencia(descripcion, valorMinimo, valorMaximo, unidadMedida);
            listaDetalleValorReferencia.Add(detalleValorReferencia);

            if (cboUnidadMedidaDetalleValorReferencia.Enabled == true)
            {
                dgvDetallesValorReferencia.Rows.Add(descripcion, valorMinimo, valorMaximo, unidad.nombre);
            }
            else
            {
                dgvDetallesValorReferencia.Rows.Add(descripcion, valorMinimo, valorMaximo, "No seleccionado");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarDatosParaRegistro() == false)
                return;

            string nombreEstudio="";
            nombreEstudio = txtNombreEstudioLaboratorio.Text;
            ItemLaboratorio itemLaboratorio = manejador.crearItemLaboratorio(nombreEstudio);

            itemEstudio = manejador.crearItemEstudioLaboratorio(itemLaboratorio);
            if (listaDetalles != null && listaDetalles.Count > 0)
                itemEstudio.detalles = listaDetalles;



            manejador.registrarItemEstudioLaboratorio(itemEstudio);

            MessageBox.Show("Registro completo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNombreEstudioLaboratorio.Clear();
            txtNombreDetalleItem.Clear();
            txtValorMaximoReferencia.Clear();
            txtValorMinimoReferencia.Clear();
            dgvValoresReferencia.Rows.Clear();
            cbAgregarDetalleValorReferencia.Checked = false;
            txtDescripcionDetalleValorReferencia.Clear();
            txtValorMaximoDetalleValorReferencia.Clear();
            txtValorMinimoDetalleValorReferencia.Clear();
            dgvDetallesValorReferencia.Rows.Clear();

            itemEstudio = null;
            detalleItemLaboratorio = null;
            detalleValorReferencia = null;
            listaDetalles = null;
            listaDetalleValorReferencia = null;
        }
        public Boolean validarDatosParaRegistro()
        {
            if (string.IsNullOrEmpty(txtNombreEstudioLaboratorio.Text))
            {
                MessageBox.Show("Faltan datos por ingresar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (dgvValoresReferencia.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("No hay datos cargados en la grilla", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void txtValorMinimoReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
