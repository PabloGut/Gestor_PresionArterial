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
    public partial class RegistrarTratamiento : Form
    {
        public RegistrarTratamiento(ManejadorRegistrarExamenGeneral manejadorExamenGeneral)
        {
            InitializeComponent();

            if (manejadorExamenGeneral != null)
            {
                manejador = manejadorExamenGeneral;
            }
            else
            {
                manejador = new ManejadorRegistrarExamenGeneral();
            }
        }
        public List<Tratamiento> listaTratamientos { set; get; }
        public List<ProgramacionMedicamento> listaMedicamentos { set; get; }
        public ManejadorRegistrarExamenGeneral manejador { set; get; }

        private void RegistrarTratamiento_Load(object sender, EventArgs e)
        {
            List<String> columnas = new List<String>();
            columnas.Add("NombreTratamiento");
            columnas.Add("Descripción");

            Utilidades.agregarColumnasDataGridView(dgvListaTratamientos, columnas);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAgregarTratamiento_Click(object sender, EventArgs e)
        {
            agregarTerapiaDgvTratamiento();
        }
        public void agregarTerapiaDgvTratamiento()
        {
            string nombreTerapia;
            int id_terapia;
            string indicaciones = "";
            string motivoInicio = "";
            DateTime fechaInicio;

            if (cboTerapia.SelectedIndex > 0)
            {
                Terapia terapiaSeleccionada = (Terapia)cboTerapia.SelectedItem;
                nombreTerapia = terapiaSeleccionada.nombre;
                id_terapia = (int)cboTerapia.SelectedValue;

                if (!string.IsNullOrEmpty(txtIndicacionesTerapia.Text))
                {
                    indicaciones = txtIndicacionesTerapia.Text;
                }
                if (!string.IsNullOrEmpty(txtMotivoInicio.Text))
                {
                    motivoInicio = txtMotivoInicio.Text;
                }
                fechaInicio = Convert.ToDateTime(mtbFechaInicio.Text);

                Terapia terapia = manejador.crearTerapia(id_terapia, nombreTerapia);

                if(listaTratamientos==null)
                    listaTratamientos = manejador.crearListaTratamiento();

                Tratamiento tratamiento = manejador.crearTratamiento(terapia, indicaciones, fechaInicio, motivoInicio);

                dgvListaTratamientos.Rows.Add(nombreTerapia);

                listaTratamientos.Add(tratamiento);
            }
        }
        public void agregarDgvTratamientoFarmacologico()
        {

        }
        public void cargarTratamientoFarmacologico()
        {
            string nombreTerapia = "";
            if (cboTerapia.SelectedIndex > 0)
            {
                Terapia terapia = (Terapia)cboTerapia.SelectedItem;
                nombreTerapia = terapia.nombre;
            }
            ProgramacionMedicamento programacion = manejador.crearProgramacionMedicamento();

            EspecificacionMedicamento especificacion = manejador.crearEspecificacionMedicamento();

            Medicamento medicamentoSeleccionado = (Medicamento)cboNombreGenerico.SelectedItem;
            especificacion.id_medicamento_fk = medicamentoSeleccionado.id_medicamento;

            NombreComercial nombreComercialSeleccionado = (NombreComercial)cboNombreComercial.SelectedItem;
            especificacion.id_nombreComercial = nombreComercialSeleccionado.id_nombreComercial;

            int concentracionSeleccionada = (int)cboConcentracion.SelectedItem;
            especificacion.concentracion = concentracionSeleccionada;

            UnidadDeMedida unidadMedidaSeleccionada = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
            especificacion.id_unidadMedida_fk = unidadMedidaSeleccionada.id_unidadMedida;

            PresentacionMedicamento presentacionSeleccionada = (PresentacionMedicamento)cboPresentacionMedicamento.SelectedItem;
            especificacion.id_presentacionMedicamento = presentacionSeleccionada.id_presentacionMedicamento;

            FormaAdministracion formaAdmSeleccionada = (FormaAdministracion)cboFormaAdministración.SelectedItem;
            especificacion.id_formaAdministracion = formaAdmSeleccionada.id_formaAdministracion;

            int cantidadComprimidosSeleccionada = (int)cboCantidadComprimidos.SelectedItem;
            especificacion.cantidadComprimidos = cantidadComprimidosSeleccionada;

            manejador.buscarEspecificacionMedicamento(especificacion);

            programacion.id_especificacionMedicamento = especificacion.id_especificacion;
            programacion.id_medicamento = especificacion.id_medicamento_fk;

            Frecuencia frecuenciaSeleccionada = (Frecuencia)cboFrecuencia.SelectedItem;
            programacion.id_frecuencia = frecuenciaSeleccionada.id_Frecuencia;

            if (cboMomentoDia1.SelectedIndex > 0)
            {
                MomentoDia momentoDia1 = (MomentoDia)cboMomentoDia1.SelectedItem;
                programacion.id_momentoDia1 = momentoDia1.idMomentoDia;

                programacion.cantidad1Numerador = Convert.ToInt32(txtNumeradorCantidad1.Text);

                if (string.IsNullOrEmpty(txtDenominadorCantidad1.Text) == false)
                {
                    programacion.cantidad1Denominador = Convert.ToInt32(txtDenominadorCantidad1.Text);
                }

                PresentacionMedicamento presentacionSeleccionada1 = (PresentacionMedicamento)cboPresentacionMedicamento1.SelectedItem;
                programacion.id_presentacionMedicamento1 = presentacionSeleccionada1.id_presentacionMedicamento;

                programacion.hora1 = Convert.ToDateTime(mtbHora1.Text);
            }

            if (cboMomentoDia2.SelectedIndex > 0)
            {
                MomentoDia momentoDia2 = (MomentoDia)cboMomentoDia2.SelectedItem;
                programacion.id_momentoDia2 = momentoDia2.idMomentoDia;
                programacion.cantidad2Numerador = Convert.ToInt32(txtNumeradorCantidad2.Text);

                if (string.IsNullOrEmpty(txtDenominadorCantidad2.Text) == false)
                {
                    programacion.cantidad2Denominador = Convert.ToInt32(txtDenominadorCantidad2.Text);
                }
                PresentacionMedicamento presentacionSeleccionada2 = (PresentacionMedicamento)cboPresentacionMedicamento2.SelectedItem;
                programacion.id_presentacionMedicamento2 = presentacionSeleccionada2.id_presentacionMedicamento;
                programacion.hora2 = Convert.ToDateTime(mtbHora2.Text);
            }

            if (cboMomentoDia3.SelectedIndex > 0)
            {
                MomentoDia momentoDia3 = (MomentoDia)cboMomentoDia3.SelectedItem;
                programacion.id_momentoDia3 = momentoDia3.idMomentoDia;

                programacion.cantidad3Numerador = Convert.ToInt32(txtNumeradorCantidad3.Text);

                if (string.IsNullOrEmpty(txtDenominadorCantidad3.Text) == false)
                    programacion.cantidad3Denominador = Convert.ToInt32(txtDenominadorCantidad3.Text);


                PresentacionMedicamento presentacionSeleccionada3 = (PresentacionMedicamento)cboPresentacionMedicamento3.SelectedItem;
                programacion.id_presentacionMedicamento3 = presentacionSeleccionada3.id_presentacionMedicamento;

                programacion.hora3 = Convert.ToDateTime(mtbHora3.Text);
            }

            dgvListaTratamientos.Rows.Add(nombreTerapia, nombreComercialSeleccionado);

            if (listaMedicamentos == null)
                listaMedicamentos = manejador.crearListaProgramacionMedicamento();

            listaMedicamentos.Add(programacion);
        }
        private void btnAgregarTratamientoMedicamento_Click(object sender, EventArgs e)
        {
            string terapia = "";
            DateTime fecha;
            string indicaciones = "";
            string motivo = "";

            if (cboTerapia.SelectedIndex > 0)
            {
                Terapia terapiaSeleccionada = (Terapia)cboTerapia.SelectedItem;
                terapia = terapiaSeleccionada.nombre;

                fecha = Convert.ToDateTime(mtbFechaInicio.Text);

                if (!string.IsNullOrEmpty(txtIndicacionesTerapia.Text))
                {
                    indicaciones = txtIndicacionesTerapia.Text;
                }
                if (!string.IsNullOrEmpty(txtMotivoInicio.Text))
                {
                    motivo = txtMotivoInicio.Text;
                }

                cargarTratamientoFarmacologico();

                Tratamiento tratamiento = manejador.crearTratamiento(terapiaSeleccionada, indicaciones, fecha, motivo, listaMedicamentos);

                listaTratamientos.Add(tratamiento);
            }

        }
        public void limpiarContenidoComponentes()
        {
            txtIndicacionesTerapia.Clear();
            txtMotivoInicio.Clear();
        }
    }
}
