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
using LogicaNegocio;

namespace GPA
{
    public partial class RegistrarLaboratorio : Form
    {
        private ManejadorRegistrarLaboratorio manejadorRegistrarLaboratorio;
        public Laboratorio laboratorio{set;get;}
        private List<DetalleLaboratorio> listaDetalles;

        private List<DetalleResultadoEstudio> listaDetalleResultadoEstudio;

        private int idEstudioSeleccionado { set; get; }

        public RegistrarLaboratorio(Laboratorio laboratorio)
        {
            InitializeComponent();
            this.laboratorio = laboratorio;
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
            txtAnalisisSolicitado.Text = laboratorio.analisis.nombre;
            manejadorRegistrarLaboratorio = new ManejadorRegistrarLaboratorio();

            cargarComboInstituciones();
            cargarComboMetodosAnalisisLaboratorio();
            cargarColumnasGrillaItemEstudios();
            obtenerItemLaboratorio();
            cargarComboUnidadDeMedida();
            cargarColumnasGrillaResultados();

            List<String> columnas = new List<string>();
            columnas.Add("idDetalleItem");
            columnas.Add("nombre");

            cargarColumnasGrilla(columnas);

            mtbFechaPractica.Text = "20/01/2021";
            txtDoctorACargo.Text = "Juncos";
            txtObservaciones.Text = "Normal";
            dgvDetalleResultado.Columns[0].Visible = false;

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

            //Utilidades.agregarColumnasDataGridView(dgvListaResultadosAnalisis, columnas);
        }
        public void cargarColumnasGrilla(List<String> columnas)
        {
            Utilidades.agregarColumnasDataGridView(dgvDetalleResultado, columnas);
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
            if (dgvDetalleResultado.Rows.Count > 0)
                Utilidades.limpiarGrilla(dgvDetalleResultado);

            string valor = (string)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[1].Value;

            if (!string.IsNullOrEmpty(valor))
            {
                //txtEstudioSeleccionado.Text = valor;
                idEstudioSeleccionado = (int)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[0].Value;
                List<DetalleItemLaboratorio> listaDetalleItemLaboratorio = ItemLaboratorioLN.obtenerDetalleItemLaboratorio(idEstudioSeleccionado);

                if (listaDetalleItemLaboratorio != null && listaDetalleItemLaboratorio.Count > 0)
                {
                    foreach (DetalleItemLaboratorio i in listaDetalleItemLaboratorio)
                    {
                        dgvDetalleResultado.Rows.Add(i.id_detalleItemLaboratorio, i.nombre);
                    }
                }
                else
                {
                    Utilidades.mostrarFilaNoSeEncontraronResultados(dgvListadoItemsEstudioLaboratorio);
                }
                dgvListadoItemsEstudioLaboratorio.Columns[0].Visible = false;
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
            if (string.IsNullOrEmpty(txtEstudioSeleccionado.Text))
            {
                MessageBox.Show("Falta seleccionar un estudio!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           // MetodoAnalisisLaboratorio metodo = (MetodoAnalisisLaboratorio)cboMetodoAnalisisLaboratorio.SelectedItem;

            UnidadDeMedida unidad= (UnidadDeMedida) cboUnidadDeMedida.SelectedItem;

            if (string.IsNullOrEmpty(txtResultado.Text))
            {
                MessageBox.Show("Falta agregar el resultado del item seleccionado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            double resultado = Convert.ToDouble(txtResultado.Text);

            //dgvListaResultadosAnalisis.Rows.Add(txtEstudioSeleccionado.Text, resultado, unidad.nombre, metodo.nombre);

            if (listaDetalles == null)
                listaDetalles = new List<DetalleLaboratorio>();

            if (listaDetalleResultadoEstudio == null)
                listaDetalleResultadoEstudio = new List<DetalleResultadoEstudio>();


            // ItemEstudioLaboratorio nuevoItemEstudioLaboratorio = manejadorRegistrarLaboratorio.crearItemEstudioLaboratorio(idEstudioSeleccionado);
            //nuevoItemEstudioLaboratorio.id_itemEstudioLaboratorio = manejadorRegistrarLaboratorio.obteneridItemEstudioLaboratorio(txtEstudioSeleccionado.Text);

            if (dgvDetalleResultado.Rows.Count == 0 || dgvDetalleResultado.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("No seleccionó un item para agregar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DetalleResultadoEstudio nuevoDetalleResultadoEstudio = manejadorRegistrarLaboratorio.crearDetalleResultadoEstudio();
            nuevoDetalleResultadoEstudio.idDetalleItemLaboratorio = (int)dgvDetalleResultado.CurrentRow.Cells[0].Value;
            nuevoDetalleResultadoEstudio.idItemLaboratorio = (int)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[0].Value;
            nuevoDetalleResultadoEstudio.idUnidadMedida = unidad.id_unidadMedida;
            nuevoDetalleResultadoEstudio.valorResultado = resultado;

            if(EsItemAgregado(nuevoDetalleResultadoEstudio.idDetalleItemLaboratorio, listaDetalleResultadoEstudio, (string)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[1].Value))
            {
                MessageBox.Show("El item ha sido agregado al estudio anteriormente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                listaDetalleResultadoEstudio.Add(nuevoDetalleResultadoEstudio);
                eliminarItemResultadoGrilla(nuevoDetalleResultadoEstudio.idDetalleItemLaboratorio);
            }
        }
        public Boolean EsItemAgregado(int idItem, List<DetalleResultadoEstudio> lista, string nombreItem)
        {
            foreach(DetalleResultadoEstudio detalle in lista)
            {
                if(detalle.idDetalleItemLaboratorio == idItem)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public void eliminarItemResultadoGrilla(int idItemSeleccionado)
        {
            for(int i=0; i< dgvDetalleResultado.Rows.Count;i++)
            {
                if((int)dgvDetalleResultado.Rows[i].Cells[0].Value == idItemSeleccionado)
                {
                    dgvDetalleResultado.Rows.RemoveAt(i);
                    return;
                }
            }
        }
        private void btnGuardarInformeAnalisis_Click(object sender, EventArgs e)
        {
            if (mtbFechaPractica.MaskFull==false)
            {
                MessageBox.Show("Falta ingresar la fecha en que se realizó el estudio!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtbFechaPractica.Focus();
                return;
            }
            
            laboratorio.fechaRealizacion =Convert.ToDateTime(mtbFechaPractica.Text);
     
            laboratorio.observaciones = txtObservaciones.Text;

            MetodoAnalisisLaboratorio metodo = (MetodoAnalisisLaboratorio)cboMetodoAnalisisLaboratorio.SelectedItem;
            laboratorio.id_metodoLaboratorio = metodo.idMetodo;

            laboratorio.id_institucion =(int)cboInstitucion.SelectedValue;

            laboratorio.DoctorACargo = txtDoctorACargo.Text;

            laboratorio.id_analisisLaboratorio_fk = manejadorRegistrarLaboratorio.obtenerIdAnalisisLaboratorio(txtAnalisisSolicitado.Text);

            laboratorio.listaDetalle = listaDetalles;

            DialogResult = DialogResult.OK;

            //try
            //{
            //    manejadorRegistrarLaboratorio.insertResultadoEstudioLaboratorio(laboratorio);
            //    DialogResult = DialogResult.OK;
            //}
            //catch (Exception exe)
            //{
            //    MessageBox.Show("Error al insertar el resultado del estudio. Error: " + exe.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalleResultado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String detalleResultado = (string)dgvDetalleResultado.CurrentRow.Cells[1].Value;
            if (dgvDetalleResultado.Rows.Count > 0 && !string.IsNullOrEmpty(detalleResultado))
            {
                txtEstudioSeleccionado.Text = detalleResultado;
            }
        }

        private void btnAgregarEstudio_Click(object sender, EventArgs e)
        {
            if (listaDetalleResultadoEstudio != null && listaDetalleResultadoEstudio.Count > 0)
            {
                DetalleLaboratorio nuevoDetalleLaboratorio = manejadorRegistrarLaboratorio.crearDetalleLaboratorio();
                nuevoDetalleLaboratorio.idItemLaboratorio = (int)dgvListadoItemsEstudioLaboratorio.CurrentRow.Cells[0].Value;
                nuevoDetalleLaboratorio.detalleResultadoEstudios = listaDetalleResultadoEstudio;
                listaDetalles.Add(nuevoDetalleLaboratorio);

                MessageBox.Show("Agregado correctamente al estudio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Utilidades.limpiarGrilla(dgvDetalleResultado);


            } 
            else
            {
                MessageBox.Show("No seleccionó items para el estudio!!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }
    }
}
