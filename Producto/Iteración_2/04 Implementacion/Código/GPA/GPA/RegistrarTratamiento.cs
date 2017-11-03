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
        public Tratamiento tratamientoMedicamento { set; get; }

        private void RegistrarTratamiento_Load(object sender, EventArgs e)
        {
            List<String> columnas = new List<String>();
            columnas.Add("NombreTratamiento");
            columnas.Add("Descripción");

            Utilidades.agregarColumnasDataGridView(dgvListaTratamientos, columnas);
            cargarCombosTratamientos();
            mtbFechaInicio.Text = DateTime.Now.ToShortDateString();
        }
        public void cargarCombosTratamientos()
        {
            Utilidades.cargarCombo(cboTerapia, manejador.mostrarTerapias(), "id_terapia", "nombre");
            Utilidades.cargarCombo(cboNombreGenerico, manejador.presentarNombreGenericoMedicamento(), "id_medicamento", "nombreGenerico");
            Utilidades.cargarCombo(cboFrecuencia, manejador.mostrarFrecuencias(), "id_frecuencia", "nombre");
            Utilidades.cargarCombo(cboMomentoDia1, manejador.mostrarMomentosDelDia(), "idMomentiDia", "nombre");
            Utilidades.cargarCombo(cboMomentoDia2, manejador.mostrarMomentosDelDia(), "idMomentiDia", "nombre");
            Utilidades.cargarCombo(cboMomentoDia3, manejador.mostrarMomentosDelDia(), "idMomentiDia", "nombre");
            Utilidades.cargarCombo(cboPresentacionMedicamento1, manejador.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");
            Utilidades.cargarCombo(cboPresentacionMedicamento2, manejador.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");
            Utilidades.cargarCombo(cboPresentacionMedicamento3, manejador.mostrarPresentacionesMedicamento(), "id_presentacionMedicamento", "nombre");

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAgregarTratamiento_Click(object sender, EventArgs e)
        {
            agregarTerapia();
            limpiarContenidoComponentes();
        }
        public void agregarTerapia()
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

                if (listaTratamientos == null)
                    listaTratamientos = manejador.crearListaTratamiento();

                Tratamiento tratamiento = manejador.crearTratamiento(terapia, indicaciones, fechaInicio, motivoInicio);

                if (nombreTerapia.Equals("Medicamentos") == false)
                {
                    dgvListaTratamientos.Rows.Add(tratamiento.terapia.nombre, tratamiento.indicaciones);
                    listaTratamientos.Add(tratamiento);
                }
                else
                {
                    tratamientoMedicamento = tratamiento;
                }

            }
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

            programacion.id_estado = manejador.buscarIdEstado("Activa");

            if (listaMedicamentos == null)
                listaMedicamentos = manejador.crearListaProgramacionMedicamento();
            
            listaMedicamentos.Add(programacion);
            dgvListaTratamientos.Rows.Add(tratamientoMedicamento.terapia.nombre, nombreComercialSeleccionado.nombre);
        }
        private void btnAgregarTratamientoMedicamento_Click(object sender, EventArgs e)
        {
            agregarTerapiaMedicamento();
        }
        public void agregarTerapiaMedicamento()
        {
            agregarTerapia();
            cargarTratamientoFarmacologico();
            tratamientoMedicamento.medicamentos = listaMedicamentos;

            listaTratamientos.Add(tratamientoMedicamento);

            cboFrecuencia.SelectedIndex = 0;
            cboMomentoDia1.SelectedIndex = 0;
            cboMomentoDia2.SelectedIndex = 0;
            cboMomentoDia3.SelectedIndex = 0;
            txtNumeradorCantidad1.Clear();
            txtNumeradorCantidad2.Clear();
            txtNumeradorCantidad3.Clear();

            txtDenominadorCantidad1.Clear();
            txtDenominadorCantidad2.Clear();
            txtDenominadorCantidad3.Clear();

            cboPresentacionMedicamento1.SelectedIndex = 0;
            cboPresentacionMedicamento2.SelectedIndex = 0;
            cboPresentacionMedicamento3.SelectedIndex = 0;

            mtbHora1.Clear();
            mtbHora2.Clear();
            mtbHora3.Clear();

            btnAgregarTerapia.Enabled = true;
            cboTerapia.Enabled = true;
            limpiarContenidoComponentes();
            btnAgregarTratamientoMedicamento.Enabled = false;
        }
        public void limpiarContenidoComponentes()
        {
            txtIndicacionesTerapia.Clear();
            txtMotivoInicio.Clear();
            cboTerapia.SelectedIndex = 0;
        }
        private void cboNombreGenerico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMedicamento;
            Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
            Utilidades.cargarCombo(cboNombreComercial, manejador.presentarNombreComercialMedicamento(idMedicamento), "id_nombreComercial", "nombre");
        }

        private void cboNombreComercial_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentarDatosDeLaEspecificacion();
        }
        public void presentarDatosDeLaEspecificacion()
        {
            int idMedicamento;
            int idNombreComercial;
            Int32.TryParse(cboNombreGenerico.SelectedValue.ToString(), out idMedicamento);
            Int32.TryParse(cboNombreComercial.SelectedValue.ToString(), out idNombreComercial);

            Utilidades.cargarCombo(cboUnidadMedida, manejador.mostrarUnidadMedidaParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_unidadMedida", "nombre");

            Utilidades.cargarCombo(cboFormaAdministración, manejador.mostrarFormasAdministracionParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_formaAdministracion", "nombre");

            Utilidades.cargarCombo(cboPresentacionMedicamento, manejador.mostrarPresentacionMedicamentoParaUnNombreGenericoYNombreComercial(idMedicamento, idNombreComercial), "id_presentacionMedicamento", "nombre");

            UnidadDeMedida unidad = (UnidadDeMedida)cboUnidadMedida.SelectedItem;
            PresentacionMedicamento presentacion = (PresentacionMedicamento)cboPresentacionMedicamento.SelectedItem;
            FormaAdministracion formaAdministracion = (FormaAdministracion)cboFormaAdministración.SelectedItem;

            cboConcentracion.DataSource = manejador.mostrarConcentracionMedicamento(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
            cboCantidadComprimidos.DataSource = manejador.mostrarCantidadComrpimidos(idMedicamento, idNombreComercial, unidad.id_unidadMedida, presentacion.id_presentacionMedicamento, formaAdministracion.id_formaAdministracion);
        }

        private void cboTerapia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Terapia terapia = (Terapia)cboTerapia.SelectedItem;
            if (terapia.nombre.Equals("Medicamentos"))
            {
                grbTratamientoFarmacologico.Enabled = true;
                btnAgregarTerapia.Enabled = false;
                cboTerapia.Enabled = false;
                if (btnAgregarTratamientoMedicamento.Enabled == false)
                {
                    btnAgregarTratamientoMedicamento.Enabled = true;
                }
            }
            else
            {
                grbTratamientoFarmacologico.Enabled = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }
        public void cancelar()
        {
            cboTerapia.SelectedIndex = 0;
            txtMotivoInicio.Clear();
            txtIndicacionesTerapia.Clear();
            cboFrecuencia.SelectedIndex = 0;
            cboMomentoDia1.SelectedIndex = 0;
            cboMomentoDia2.SelectedIndex = 0;
            cboMomentoDia3.SelectedIndex = 0;
            txtNumeradorCantidad1.Clear();
            txtNumeradorCantidad2.Clear();
            txtNumeradorCantidad3.Clear();
            txtDenominadorCantidad1.Clear();
            txtDenominadorCantidad2.Clear();
            txtDenominadorCantidad3.Clear();
            cboPresentacionMedicamento1.SelectedIndex = 0;
            cboPresentacionMedicamento2.SelectedIndex = 0;
            cboPresentacionMedicamento3.SelectedIndex = 0;
            mtbHora1.Clear();
            mtbHora2.Clear();
            mtbHora3.Clear();
            dgvListaTratamientos.Rows.Clear();
            tratamientoMedicamento = null;
            listaTratamientos = null;
            listaMedicamentos = null;
            cboTerapia.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
