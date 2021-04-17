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

        public CaracterDelDolor caracterDelDolor { get; set; }

        public DescripcionDelTiempo DescripcionTiempo { get; set; }

        public ModificacionSintoma Modificacion { get; set; }

        public ElementoDeModificacion ElementoModificacion { get; set; }
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
                    List<TipoSintoma> tipos = TipoSintomaLN.presentarTipoSintoma();
                    presentarDatosGrilla(tipos);
                    break;
                case "Actualizar parte del cuerpo donde presenta el síntoma":
                    lblCaracteristica.Text = "Parte del cuerpo";
                    List<ParteDelCuerpo> partes = ParteDelCuerpoLN.presentarPartesDelCuerpo();
                    presentarDatosGrilla(partes);
                    break;
                case "Caracter del dolor":
                    lblCaracteristica.Text = "Caracter del dolor";
                    List<CaracterDelDolor> tiposDolor = CaracterDelDolorLN.mostrarCaracterDelDolor();
                    presentarDatosGrilla(tiposDolor);
                    break;
                case "Comienzo Síntoma":
                    lblCaracteristica.Text = "Comienzo Síntoma";
                    List<DescripcionDelTiempo> descripcionesTiempo = DescripcionDelTiempoLN.MostrarDescripcionesDelTiempo();
                    presentarDatosGrilla(descripcionesTiempo);
                    break;
                case "Como se Modifica":
                    lblCaracteristica.Text = "Como se Modifica";
                    List<ModificacionSintoma> modificacionSintoma = ModificacionSintomaLN.mostrarModificacionesDelSintoma();
                    presentarDatosGrilla(modificacionSintoma);
                    break;
                case "Elemento Modificacion":
                    lblCaracteristica.Text = "Elemento Modificacion";
                    List<ElementoDeModificacion> elemento = ElementoDeModificacionLN.mostrarElementosDeModificacion();
                    presentarDatosGrilla(elemento);
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
            if (lista[0].GetType().Equals(typeof(CaracterDelDolor)))
            {
                List<CaracterDelDolor> tiposDolor = lista.Cast<CaracterDelDolor>().ToList();
                foreach (CaracterDelDolor caracter in tiposDolor)
                {
                    dgvGrilla.Rows.Add(caracter.id_caracterDelDolor, caracter.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(DescripcionDelTiempo)))
            {
                List<DescripcionDelTiempo> descripcionesTiempo = lista.Cast<DescripcionDelTiempo>().ToList();
                foreach (DescripcionDelTiempo descripcion in descripcionesTiempo)
                {
                    dgvGrilla.Rows.Add(descripcion.id_descripcionDelTiempo, descripcion.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(ModificacionSintoma)))
            {
                List<ModificacionSintoma> modificacionSintoma = lista.Cast<ModificacionSintoma>().ToList();
                foreach (ModificacionSintoma modificacion in modificacionSintoma)
                {
                    dgvGrilla.Rows.Add(modificacion.id_modificacionSintoma, modificacion.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(ElementoDeModificacion)))
            {
                List<ElementoDeModificacion> Elementos = lista.Cast<ElementoDeModificacion>().ToList();
                foreach (ElementoDeModificacion elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_elementoDeModificacion, elemento.nombre);
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

            if (this.Text.Equals("Caracter del dolor"))
            {
                if (DescripcionTiempo == null)
                {
                    DescripcionTiempo = new DescripcionDelTiempo();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        DescripcionTiempo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    CaracterDelDolorLN.insertarCaracterDolor(caracterDelDolor);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        caracterDelDolor.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    CaracterDelDolorLN.updateCaracterDolor(caracterDelDolor);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Comienzo Síntoma"))
            {
                if (DescripcionTiempo == null)
                {
                    DescripcionTiempo = new DescripcionDelTiempo();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        DescripcionTiempo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DescripcionDelTiempoLN.InsertarDescripcionDelTiempo(DescripcionTiempo);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        DescripcionTiempo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    DescripcionDelTiempoLN.UpdateDescripcionTiempo(DescripcionTiempo);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Como se Modifica"))
            {
                if (Modificacion == null)
                {
                    Modificacion = new ModificacionSintoma();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Modificacion.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ModificacionSintomaLN.InsertModificacionSintoma(Modificacion);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Modificacion.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    ModificacionSintomaLN.UpdateModificacionSintoma(Modificacion);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }

            if (this.Text.Equals("Elemento Modificacion"))
            {
                if (ElementoModificacion == null)
                {
                    ElementoModificacion = new ElementoDeModificacion();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        ElementoModificacion.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    ElementoDeModificacionLN.InsertElementoModificacion(ElementoModificacion);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        ElementoModificacion.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el metodo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    ElementoDeModificacionLN.UpdateElementoModificacion(ElementoModificacion);
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
            if (this.Text.Equals("Caracter del dolor"))
            {
                caracterDelDolor = new CaracterDelDolor();
                caracterDelDolor.id_caracterDelDolor = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                caracterDelDolor.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (caracterDelDolor != null)
                {
                    txtCaracteristica.Text = caracterDelDolor.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Comienzo Síntoma"))
            {
                DescripcionTiempo= new DescripcionDelTiempo();
                DescripcionTiempo.id_descripcionDelTiempo = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                DescripcionTiempo.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (DescripcionTiempo != null)
                {
                    txtCaracteristica.Text = DescripcionTiempo.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Como se Modifica"))
            {
                Modificacion = new ModificacionSintoma();
                Modificacion.id_modificacionSintoma = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                Modificacion.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (Modificacion != null)
                {
                    txtCaracteristica.Text = Modificacion.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Elemento Modificacion"))
            {
                ElementoModificacion = new ElementoDeModificacion();
                ElementoModificacion.id_elementoDeModificacion = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                ElementoModificacion.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (ElementoModificacion != null)
                {
                    txtCaracteristica.Text = ElementoModificacion.nombre;
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
                    DialogResult = DialogResult.OK;
                }
            }

            if (this.Text.Equals("Actualizar parte del cuerpo donde presenta el síntoma"))
            {
                if (parteDelCuerpo != null)
                {
                    ParteDelCuerpoLN.deleteParteDelCuerpo(parteDelCuerpo);
                    nuevo();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Caracter del dolor"))
            {
                if (caracterDelDolor != null)
                {
                    CaracterDelDolorLN.deleteCaracterDolor(caracterDelDolor);
                    nuevo();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Comienzo Síntoma"))
            {
                if (DescripcionTiempo != null)
                {
                    DescripcionDelTiempoLN.DeleteDescripcionTiempo(DescripcionTiempo);
                    nuevo();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Como se Modifica"))
            {
                if (Modificacion != null)
                {
                    ModificacionSintomaLN.DeleteMoficicacionSintoma (Modificacion);
                    nuevo();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Elemento Modificacion"))
            {
                if (ElementoModificacion != null)
                {
                    ElementoDeModificacionLN.DeleteElementoModificacion(ElementoModificacion);
                    nuevo();
                    DialogResult = DialogResult.OK;
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
