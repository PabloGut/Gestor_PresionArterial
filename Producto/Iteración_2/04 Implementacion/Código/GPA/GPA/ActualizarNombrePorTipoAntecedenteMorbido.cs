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
    public partial class ActualizarNombrePorTipoAntecedenteMorbido : Form
    {
        private Operacion Operacion{ set; get; }
        private Traumatismo Traumatismo { set; get; }
        private Enfermedad Enfermedad { set; get; }

        private Boolean Actualizar;

        public ActualizarNombrePorTipoAntecedenteMorbido()
        {
            InitializeComponent();
        }

        private void ActualizarNombrePorTipoAntecedenteMorbido_Load(object sender, EventArgs e)
        {
            cargarColumnasGrilla();
            presentarTipoAntecedenteMorbido(cboTipoAntecedenteMorbido, TipoAntecedenteMorbidoLN.mostrarTiposAntecedentesMorbidos(), "id_tipoAntecedenteMorbido", "nombre");
            CargarGrilla();

            Actualizar = false;
        }
        public void presentarTipoAntecedenteMorbido(ComboBox combo, List<TipoAntecedenteMorbido> tiposAntecedentesMorbidos, string valueMember, string displayMember)
        {
            cargarCombo(combo, tiposAntecedentesMorbidos, valueMember, displayMember);
        }
        public void cargarCombo<T>(ComboBox combo, List<T> lista, string valueMember, string displayMember)
        {
            combo.DataSource = lista;
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
        }
        public void cargarColumnasGrilla()
        {
            List<String> columnas = new List<string>();
            columnas.Add("id");
            columnas.Add("Nombre");
            //columnas.Add("Descripcion");
            columnas.Add("idTipo");
            Utilidades.agregarColumnasDataGridView(dgvTipoAntecedenteMorbido, columnas);
            dgvTipoAntecedenteMorbido.Columns[0].Visible = false;
            dgvTipoAntecedenteMorbido.Columns[2].Visible = false;
        }
        public void CargarGrilla()
        {
            dgvTipoAntecedenteMorbido.Rows.Clear();

            if (dgvTipoAntecedenteMorbido.Columns.Count==0)
            {
                cargarColumnasGrilla();
            }
            TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
            if (tipo.id_tipoAntecedenteMorbido==1)
            {
                List<Enfermedad> enfermedades = EnfermedadLN.mostrarEnfermedades(tipo.id_tipoAntecedenteMorbido);
                foreach (Enfermedad e in enfermedades)
                {
                    dgvTipoAntecedenteMorbido.Rows.Add(e.id_enfermedad, e.nombre,e.id_tipoAntecedenteMorbido);
                }
            }

            if (tipo.id_tipoAntecedenteMorbido == 2)
            {
                List<Operacion> operaciones = OperacionLN.mostrarOperaciones(tipo.id_tipoAntecedenteMorbido);
                foreach (Operacion o in operaciones)
                {
                    dgvTipoAntecedenteMorbido.Rows.Add(o.id_operacion, o.nombre, o.id_tipoAntecedenteMorbido);
                }
            }

            if (tipo.id_tipoAntecedenteMorbido == 3)
            {
                List<Traumatismo> traumatismos = TraumatismoLN.mostrarTraumatismos(tipo.id_tipoAntecedenteMorbido);
                foreach (Traumatismo t in traumatismos)
                {
                    dgvTipoAntecedenteMorbido.Rows.Add(t.id_traumatismo, t.nombre, t.id_tipoAntecedenteMorbido);
                }
            }

            //dgvUnidadesDeMedida.DataSource = unidades;
        }

        private void cboTipoAntecedenteMorbido_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTipoAntecedenteMorbido.Rows.Clear();
            TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
            switch (tipo.nombre)
            {
                case "Enfermedad":
                    List<Enfermedad> enfermedades = EnfermedadLN.mostrarEnfermedades(tipo.id_tipoAntecedenteMorbido);
                    foreach (Enfermedad enf in enfermedades)
                    {
                        dgvTipoAntecedenteMorbido.Rows.Add(enf.id_enfermedad, enf.nombre, enf.id_tipoAntecedenteMorbido);
                    }
                    break;
                case "Operación":
                    List<Operacion> operaciones = OperacionLN.mostrarOperaciones(tipo.id_tipoAntecedenteMorbido);
                    foreach (Operacion o in operaciones)
                    {
                        dgvTipoAntecedenteMorbido.Rows.Add(o.id_operacion, o.nombre, o.id_tipoAntecedenteMorbido);
                    }
                    break;
                case "Traumatismo":
                    List<Traumatismo> traumatismos = TraumatismoLN.mostrarTraumatismos(tipo.id_tipoAntecedenteMorbido);
                    foreach (Traumatismo t in traumatismos)
                    {
                        dgvTipoAntecedenteMorbido.Rows.Add(t.id_traumatismo, t.nombre, t.id_tipoAntecedenteMorbido);
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
            if (Actualizar == false)
            {
                if (tipo.id_tipoAntecedenteMorbido == 1 && Enfermedad == null)
                {
                    Enfermedad = new Enfermedad();
                    if (!String.IsNullOrEmpty(txtAntecedenteMórbido.Text))
                        Enfermedad.nombre = txtAntecedenteMórbido.Text;

                    Enfermedad.id_tipoAntecedenteMorbido = tipo.id_tipoAntecedenteMorbido;
                    EnfermedadLN.RegistrarEnfermedad(Enfermedad);
                    Enfermedad = null;
                }
                if (tipo.id_tipoAntecedenteMorbido== 2 && Operacion == null)
                {
                    Operacion = new Operacion();

                    if (!String.IsNullOrEmpty(txtAntecedenteMórbido.Text))
                        Operacion.nombre = txtAntecedenteMórbido.Text;

                    Operacion.id_tipoAntecedenteMorbido = tipo.id_tipoAntecedenteMorbido;

                    OperacionLN.RegistraOperacion(Operacion);
                    Operacion = null;
                }
              
                if (tipo.id_tipoAntecedenteMorbido == 3 && Traumatismo == null)
                {
                    Traumatismo = new Traumatismo();
                    if (!String.IsNullOrEmpty(txtAntecedenteMórbido.Text))
                        Traumatismo.nombre = txtAntecedenteMórbido.Text;

                    Traumatismo.id_tipoAntecedenteMorbido = tipo.id_tipoAntecedenteMorbido;
                    TraumatismoLN.RegistrarTraumatismo(Traumatismo);
                    Traumatismo = null;
                }
            }
            else
            {
                if (tipo.id_tipoAntecedenteMorbido == 1 && Enfermedad != null)
                {
                    Enfermedad.nombre = txtAntecedenteMórbido.Text;
                    EnfermedadLN.ActualizarEnfermedad(Enfermedad);
                }
                if (tipo.id_tipoAntecedenteMorbido == 2 && Operacion != null)
                {
                    Operacion.nombre = txtAntecedenteMórbido.Text;
                    OperacionLN.ActualizarOperacion(Operacion);
                }
                if(tipo.id_tipoAntecedenteMorbido == 3 && Traumatismo !=null)
                {
                    Traumatismo.nombre = txtAntecedenteMórbido.Text;
                    TraumatismoLN.ActualizarTraumatismo(Traumatismo);
                }
            }
            CargarGrilla();
            Nueva();
        }
        public void Nueva()
        {
            txtAntecedenteMórbido.Clear();
            Operacion = null;
            Traumatismo = null;
            Enfermedad = null;
        }
        private void dgvTipoAntecedenteMorbido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTipoAntecedenteMorbido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TipoAntecedenteMorbido tipo = (TipoAntecedenteMorbido)cboTipoAntecedenteMorbido.SelectedItem;
            if (tipo.id_tipoAntecedenteMorbido == 1)
            {
                Enfermedad = new Enfermedad();
                Enfermedad.id_enfermedad= (int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[0].Value;
                Enfermedad.nombre=(string)dgvTipoAntecedenteMorbido.CurrentRow.Cells[1].Value;
                Enfermedad.id_tipoAntecedenteMorbido=(int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[2].Value;
                Actualizar = true;
            }

            if (tipo.id_tipoAntecedenteMorbido == 2)
            {
                Operacion = new Operacion();
                Operacion.id_operacion = (int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[0].Value;
                Operacion.nombre = (string)dgvTipoAntecedenteMorbido.CurrentRow.Cells[1].Value;
                Operacion.id_tipoAntecedenteMorbido = (int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[2].Value;
                Actualizar = true;
            }

            if (tipo.id_tipoAntecedenteMorbido == 3)
            {
                Traumatismo = new Traumatismo();
                Traumatismo.id_traumatismo = (int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[0].Value;
                Traumatismo.nombre = (string)dgvTipoAntecedenteMorbido.CurrentRow.Cells[1].Value;
                Traumatismo.id_tipoAntecedenteMorbido = (int)dgvTipoAntecedenteMorbido.CurrentRow.Cells[2].Value;
                Actualizar = true;
            }
            txtAntecedenteMórbido.Text= (string) dgvTipoAntecedenteMorbido.CurrentRow.Cells[1].Value;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nueva();
        }

        private void brnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
