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
    public partial class ActualizarCaracteristicas : Form
    {
        public TipoSintoma tipoSintoma{set;get;}
        public ParteDelCuerpo parteDelCuerpo { set; get; }

        public ActualizarCaracteristicas()
        {
            InitializeComponent();
        }

        private void ActualizarCaracteristicas_Load(object sender, EventArgs e)
        {
            cargarColumnas();
            nuevo();
        }
        public void presentarCaracteristicas()
        {
            switch (this.Text)
            {
                case "Actualizar tipo de síntoma":
                    lblCaracteristica.Text = "Tipo de síntoma";
                    List<TipoSintoma> tipos=TipoSintomaLN.presentarTipoSintoma();
                    presentarDatosGrilla(tipos);
                    break;
                case  "Actualizar parte del cuerpo donde presenta el síntoma":
                    lblCaracteristica.Text = "Parte del cuerpo";
                    List<ParteDelCuerpo> partes = ParteDelCuerpoLN.presentarPartesDelCuerpo();
                    presentarDatosGrilla(partes);
                    break;
            }
        }
        public void presentarDatosGrilla<T>(List<T> lista)
        {
            dgvGrilla.Rows.Clear();
            Type t = lista[0].GetType();

            if (lista[0].GetType().Equals(typeof(TipoSintoma)))
            {
                List<TipoSintoma> tipos= lista.Cast<TipoSintoma>().ToList();
                    foreach (TipoSintoma tipo in tipos)
                    {
                        dgvGrilla.Rows.Add(tipo.id_tipoSintoma, tipo.nombre);
                    }
            }
            if (lista[0].GetType().Equals(typeof(ParteDelCuerpo)))
            {
                List<ParteDelCuerpo> partes = lista.Cast<ParteDelCuerpo>().ToList();
                foreach (ParteDelCuerpo parte in partes)
                {
                    dgvGrilla.Rows.Add(parte.id_parteCuerpo, parte.nombre);
                }
            }
        }
        public void cargarColumnas()
        {
            List<string> columnas = new List<string>();
            columnas.Add("id");
            columnas.Add("Nombre");

            Utilidades.agregarColumnasDataGridView(dgvGrilla, columnas);
            dgvGrilla.Columns[0].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("Actualizar tipo de síntoma"))
            {
                if (tipoSintoma == null)
                {
                    tipoSintoma = new TipoSintoma();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        tipoSintoma.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    TipoSintomaLN.insertTipoSintoma(tipoSintoma);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        tipoSintoma.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TipoSintomaLN.updateTipoSintoma(tipoSintoma);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }


            if (this.Text.Equals("Actualizar parte del cuerpo donde presenta el síntoma"))
            {
                if (parteDelCuerpo == null)
                {
                    parteDelCuerpo = new ParteDelCuerpo();

                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        parteDelCuerpo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ParteDelCuerpoLN.insertParteDelCuerpo(parteDelCuerpo);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        parteDelCuerpo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ParteDelCuerpoLN.updateParteDelCuerpo(parteDelCuerpo);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void dgvGrilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Text.Equals("Actualizar tipo de síntoma"))
            {
                tipoSintoma = new TipoSintoma();
                tipoSintoma.id_tipoSintoma = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                tipoSintoma.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (tipoSintoma != null)
                {
                    txtCaracteristica.Text = tipoSintoma.nombre;
                }
                btnEliminar.Enabled = true;
            }

            if (this.Text.Equals("Actualizar parte del cuerpo donde presenta el síntoma"))
            {
                parteDelCuerpo = new ParteDelCuerpo();
                parteDelCuerpo.id_parteCuerpo = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                parteDelCuerpo.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (parteDelCuerpo != null)
                {
                    txtCaracteristica.Text = parteDelCuerpo.nombre;
                }
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("Actualizar tipo de síntoma"))
            {
                if (tipoSintoma != null)
                {
                    TipoSintomaLN.deleteTipoSintoma(tipoSintoma);
                    nuevo();
                }
            }

            if (this.Text.Equals("Actualizar parte del cuerpo donde presenta el síntoma"))
            {
                if (parteDelCuerpo != null)
                {
                    ParteDelCuerpoLN.deleteParteDelCuerpo(parteDelCuerpo);
                    nuevo();
                }
            }
        }
        public void nuevo()
        {
            presentarCaracteristicas();
            txtCaracteristica.Clear();
            btnEliminar.Enabled = false;
            tipoSintoma = null;
            parteDelCuerpo = null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

    }
}
