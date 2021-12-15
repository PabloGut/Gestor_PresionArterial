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

        public Familiar Familiar { set; get; }

        public Alimento Alimento { get; set; }

        public SustaciaAmbiente sustanciaAmbiente { get; set; }

        public SustanciaContactoPiel SustanciaContactoPiel { get; set; }

        public Insecto Insecto { get; set; }

        public TipoBebida TipoBebida { get; set; }

        public MedicamentoAlergia Medicamento { set; get; }

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
                case "Familiar":
                    lblCaracteristica.Text = "Familiar";
                    List<Familiar> familiares = FamiliarLN.mostrarFamiliares();
                    presentarDatosGrilla(familiares);
                    break;
                case "Alergia Alimento":
                    lblCaracteristica.Text = "Alimento";
                    List<Alimento> alimentos = AlimentoLN.mostrarAlimentos();
                    presentarDatosGrilla(alimentos);
                    break;
                case "Alergia Sustancia Ambiente":
                    lblCaracteristica.Text = "Sustancia Ambiente";
                    List<SustaciaAmbiente> sustanciaAmbiente = SustanciaAmbienteLN.mostrarSustanciasDelAmbiente();
                    presentarDatosGrilla(sustanciaAmbiente);
                    break;
                case "Alergia SustanciaContacto Piel":
                    lblCaracteristica.Text = "Sustancia ";
                    List<SustanciaContactoPiel> sustanciaContactoPiel = SustanciaContactoPielLN.mostrarSustaciasContactoPiel();
                    presentarDatosGrilla(sustanciaContactoPiel);
                    break;
                case "Alergia Insecto":
                    lblCaracteristica.Text = "Insecto ";
                    List<Insecto> insecto = InsectoLN.mostrarInsectos();
                    presentarDatosGrilla(insecto);
                    break;
                case "Alergia Medicamento":
                    lblCaracteristica.Text = "Medicamento ";
                    List<MedicamentoAlergia> Medicamento = MedicamentoAlergiaLN.mostrarMedicamentosQueProducenAlergia();
                    presentarDatosGrilla(Medicamento);
                    break;
                case "Tipo Bebida":
                    lblCaracteristica.Text = "Tipo ";
                    List<TipoBebida> Tipo = TipoBebidaLN.mostrarTiposDeBebidas();
                    presentarDatosGrilla(Tipo);
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
            if (lista[0].GetType().Equals(typeof(Familiar)))
            {
                List<Familiar> Elementos = lista.Cast<Familiar>().ToList();
                foreach (Familiar elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_familiar, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(Alimento)))
            {
                List<Alimento> Elementos = lista.Cast<Alimento>().ToList();
                foreach (Alimento elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_alimento, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(SustaciaAmbiente)))
            {
                List<SustaciaAmbiente> Elementos = lista.Cast<SustaciaAmbiente>().ToList();
                foreach (SustaciaAmbiente elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_sustanciaAmbiente, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(SustanciaContactoPiel)))
            {
                List<SustanciaContactoPiel> Elementos = lista.Cast<SustanciaContactoPiel>().ToList();
                foreach (SustanciaContactoPiel elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_sustanciaContactoPiel, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(Insecto)))
            {
                List<Insecto> Elementos = lista.Cast<Insecto>().ToList();
                foreach (Insecto elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_insecto, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(MedicamentoAlergia)))
            {
                List<MedicamentoAlergia> Elementos = lista.Cast<MedicamentoAlergia>().ToList();
                foreach (MedicamentoAlergia elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.idMedicamentoAlergia, elemento.nombre);
                }
            }
            if (lista[0].GetType().Equals(typeof(TipoBebida)))
            {
                List<TipoBebida> Elementos = lista.Cast<TipoBebida>().ToList();
                foreach (TipoBebida elemento in Elementos)
                {
                    dgvGrilla.Rows.Add(elemento.id_tipoBebida, elemento.nombre);
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
            if(this.Text.Equals("Familiar"))
            {
                if(Familiar == null )
                {
                    Familiar = new Familiar();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Familiar.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FamiliarLN.RegistrarFamiliar(Familiar);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Familiar.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el Familiar a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    FamiliarLN.ActualizarFamiliar(Familiar);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Alergia Alimento"))
            {
                if (Alimento == null)
                {
                    Alimento = new Alimento();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Alimento.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    AlimentoLN.RegistrarAlimentoAlergia(Alimento);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Alimento.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar el Alimento a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    AlimentoLN.ActualizarAlimentoAlergia(Alimento);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Alergia Sustancia Ambiente"))
            {
                if (sustanciaAmbiente == null)
                {
                    SustaciaAmbiente sustancia = new SustaciaAmbiente();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        sustancia.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    SustanciaAmbienteLN.RegistrarSustanciaAmbienteAlergia(sustancia);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        sustanciaAmbiente.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar sustancia a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    SustanciaAmbienteLN.ActualizarSustanciaAmbienteAlergia(sustanciaAmbiente);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Alergia SustanciaContacto Piel"))
            {
                if (SustanciaContactoPiel == null)
                {
                    SustanciaContactoPiel sustancia = new SustanciaContactoPiel();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        sustancia.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    SustanciaContactoPielLN.RegistrarSustanciaContactoPielAlergia(sustancia);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        SustanciaContactoPiel.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar sustancia a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    SustanciaContactoPielLN.ActualizarSustanciaContactoPielAlergia(SustanciaContactoPiel);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Alergia Insecto"))
            {
                if (Insecto == null)
                {
                    Insecto insecto = new Insecto();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        insecto.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InsectoLN.RegistrarInsectoAlergia(insecto);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Insecto.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar nombre a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    InsectoLN.ActualizarInsectoAlergia(Insecto);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Alergia Medicamento"))
            {
                if (Medicamento == null)
                {
                    MedicamentoAlergia medicamento = new MedicamentoAlergia();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        medicamento.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el nombre", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MedicamentoAlergiaLN.RegistrarMedicamentoAlergia(medicamento);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Medicamento.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar nombre a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    MedicamentoAlergiaLN.ActualizarMedicamentoAlergia(Medicamento);
                    presentarCaracteristicas();
                    DialogResult = DialogResult.OK;
                }
            }
            if (this.Text.Equals("Tipo Bebida"))
            {
                if (TipoBebida == null)
                {
                    TipoBebida Tipo = new TipoBebida();
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        Tipo.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta ingresar el tipo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    TipoBebidaLN.RegistrarTipoBebida(Tipo);
                    presentarCaracteristicas();
                    txtCaracteristica.Clear();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCaracteristica.Text))
                    {
                        TipoBebida.nombre = txtCaracteristica.Text;
                    }
                    else
                    {
                        MessageBox.Show("Falta seleccionar Tipo a actualizar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //Desarrollar los metodos consultar insertar update y borrar
                    TipoBebidaLN.ActualizarTipoBebida(TipoBebida);
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
            if (this.Text.Equals("Familiar"))
            {
                Familiar = new Familiar();
                Familiar.id_familiar = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                Familiar.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (Familiar != null)
                {
                    txtCaracteristica.Text = Familiar.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Alergia Alimento"))
            {
                Alimento = new Alimento();
                Alimento.id_alimento = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                Alimento.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (Alimento != null)
                {
                    txtCaracteristica.Text = Alimento.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Alergia Sustancia Ambiente"))
            {
                sustanciaAmbiente = new SustaciaAmbiente();
                sustanciaAmbiente.id_sustanciaAmbiente = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                sustanciaAmbiente.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (sustanciaAmbiente != null)
                {
                    txtCaracteristica.Text = sustanciaAmbiente.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Alergia SustanciaContacto Piel"))
            {
                SustanciaContactoPiel = new SustanciaContactoPiel();
                SustanciaContactoPiel.id_sustanciaContactoPiel = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                SustanciaContactoPiel.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (SustanciaContactoPiel != null)
                {
                    txtCaracteristica.Text = SustanciaContactoPiel.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Alergia Insecto"))
            {
                Insecto = new Insecto();
                Insecto.id_insecto = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                Insecto.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (Insecto != null)
                {
                    txtCaracteristica.Text = Insecto.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Alergia Medicamento"))
            {
                Medicamento = new MedicamentoAlergia();
                Medicamento.idMedicamentoAlergia = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                Medicamento.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (Medicamento != null)
                {
                    txtCaracteristica.Text = Medicamento.nombre;
                }
                btnEliminar.Enabled = true;
            }
            if (this.Text.Equals("Tipo Bebida"))
            {
                TipoBebida = new TipoBebida();
                TipoBebida.id_tipoBebida = (int)dgvGrilla.CurrentRow.Cells[0].Value;
                TipoBebida.nombre = (string)dgvGrilla.CurrentRow.Cells[1].Value;

                if (TipoBebida != null)
                {
                    txtCaracteristica.Text = TipoBebida.nombre;
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

        private void dgvGrilla_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }
    }
}
