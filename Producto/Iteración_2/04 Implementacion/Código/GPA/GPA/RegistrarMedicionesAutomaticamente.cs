using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Entidades.Clases;
using LogicaNegocio;
using GPA.Manejadores;
namespace GPA
{
    public partial class RegistrarMedicionesAutomaticamente : Form
    {
        private SerialPort myPort;
        private string in_data;
        public string texto;
        private string CadenaTotalMediciones;
        private int totalMediciones;

        private Boolean leer;
        private Boolean primeraFila;
        private int ciclo;

        private MedicionDePresionArterial medicion;
        private List<DetalleMedicionPresionArterial> listaDetalleMedicion;
        private Boolean registrarEnHc { set; get; }
        private ManejadorRegistrarMedicionPresionArterial manejador;
        private int idHc{set;get;}
        public RegistrarMedicionesAutomaticamente(int idHc)
        {
            InitializeComponent();
            txtMediciones.ScrollBars = ScrollBars.Vertical;
            leer = true;
            primeraFila = true;
            this.idHc = idHc;
            ciclo = 0;
            inicializarBarraProgreso();
            registrarEnHc = true;
        }
        public RegistrarMedicionesAutomaticamente()
        {
            InitializeComponent();
            txtMediciones.ScrollBars = ScrollBars.Vertical;
            leer = true;
            primeraFila = true;
            ciclo = 0;
            inicializarBarraProgreso();
            registrarEnHc = false;
        }
        public MedicionDePresionArterial getMedicion()
        {
            return medicion;
        }
        public void inicializarBarraProgreso()
        {
            pbBarraProgreso.Maximum = 10000;
            pbBarraProgreso.Minimum = 0;
            pbBarraProgreso.Value = 0;
            pbBarraProgreso.Step = 1;
        }
        public void iniciar()
        {
            myPort = new SerialPort();
            myPort.BaudRate = 115200;
            myPort.PortName = "COM6";
            myPort.DataReceived += myPort_DataReceived;

            try
            {
                myPort.Open();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error:" + a.Message);
            }
        }
        private void myPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myPort.ReadLine();
            this.Invoke(new EventHandler(display_dataevent));
        }

        private void display_dataevent(object sender, EventArgs e)
        {
            if (leer == true)
            {
                texto += in_data;
                txtMediciones.AppendText(in_data + "\n");
                lstMediciones.Items.Add(in_data);
                //contar();
                contarConBarraProgreso();
            }
        }
        public void contarConBarraProgreso()
        {
            if (primeraFila == true)
            {
                string cantidadMediciones = lstMediciones.Items[0].ToString();

                CadenaTotalMediciones = Convert.ToString(cantidadMediciones[21]);
                totalMediciones = Convert.ToInt32(CadenaTotalMediciones);
                primeraFila = false;

                pbBarraProgreso.Step = pbBarraProgreso.Maximum / totalMediciones;
            }
            int indice = lstMediciones.Items.Count;

            string cadena = lstMediciones.Items[indice - 1].ToString();
            string subcadena = lstMediciones.Items[indice - 1].ToString().Substring(0, 5);

            if (subcadena.Equals("Pulse"))
            {
                ciclo++;
                pbBarraProgreso.PerformStep();
            }

            if (ciclo == totalMediciones)
            {
                leer = false;
                cargarDatos();
                MessageBox.Show("Carga completa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void cargarDatos()
        {
            int nroMedicion;
            string fecha = DateTime.Today.ToShortDateString();
            int sistolica;
            int diastolica;
            int pulso;

            string cadenaFecha = "";
            string nroDia = "";
            string mes = "";
            string año = "";
            string hora = "";

            txtNroMediciones.Text = lstMediciones.Items[0].ToString().Substring(20);

            int i = 2;
            //while
            while (i <= lstMediciones.Items.Count)
            {
                nroMedicion = Convert.ToInt32(lstMediciones.Items[i].ToString().Substring(15));
                i++;
                // Obtener Fecha

                cadenaFecha = lstMediciones.Items[i].ToString().Substring(8);/// caracter 7 es el espacio en blanco

                int j = 0;
                while (char.IsNumber(cadenaFecha[j]))
                {
                    nroDia += cadenaFecha[j];
                    j++;
                }

                if (char.IsWhiteSpace(cadenaFecha[j]))
                    j = j + 4;

                while (!char.IsWhiteSpace(cadenaFecha[j]))
                {
                    mes += cadenaFecha[j];
                    j++;
                }

                if (char.IsWhiteSpace(cadenaFecha[j]))
                    j = j + 4;

                while (char.IsNumber(cadenaFecha[j]))
                {
                    año += cadenaFecha[j];
                    j++;
                }

                if (char.IsWhiteSpace(cadenaFecha[j]))
                    j = j + 4;

                while (char.IsNumber(cadenaFecha[j]) || char.IsPunctuation(cadenaFecha[j]))
                {
                    hora += cadenaFecha[j];
                    j++;
                }

                mes = obtenerMes(mes);

                fecha = nroDia + "/" + mes + "/" + año + " " + hora;
                //txtNroMediciones.Text = fecha;
                //Fin obtener fecha

                i++;
                sistolica = Convert.ToInt32(lstMediciones.Items[i].ToString().Substring(17, 3));
                i++;

                diastolica = Convert.ToInt32(lstMediciones.Items[i].ToString().Substring(17, 3));
                i++;

                pulso = Convert.ToInt32(lstMediciones.Items[i].ToString().Substring(13, 3));
                //i++;

                dgvMediciones.Rows.Add(nroMedicion, fecha, sistolica, diastolica, pulso);
                i = i + 2;

                fecha = "";
                nroDia = "";
                mes = "";
                año = "";
                hora = "";
            }
            //fin while
        }
        public string obtenerMes(string fechaMedicion)
        {
            string fecha = "";

            switch (fechaMedicion)
            {
                case "January":
                    fecha = "01";
                    break;

                case "February":
                    fecha = "02";
                    break;

                case "March":
                    fecha = "03";
                    break;

                case "April":
                    fecha = "04";
                    break;

                case "May":
                    fecha = "05";
                    break;

                case "June":
                    fecha = "06";
                    break;

                case "July":
                    fecha = "07";
                    break;

                case "August":
                    fecha = "08";
                    break;

                case "September":
                    fecha = "09";
                    break;

                case "October":
                    fecha = "10";
                    break;

                case "November":
                    fecha = "11";
                    break;

                case "December":
                    fecha = "12";
                    break;

                default:
                    break;
            }

            return fecha;

        }
        public void cargarColumnas()
        {
            List<String> columnas = new List<string>();
            columnas.Add("Nro");
            columnas.Add("Fecha");
            columnas.Add("Sistólica");
            columnas.Add("Diastólica");
            columnas.Add("Pulso");

            Utilidades.agregarColumnasDataGridView(dgvMediciones, columnas);

        }
        private void RegistrarMedicionesAutomaticamente_Load(object sender, EventArgs e)
        {
            txtMediciones.Visible = false;
            cargarColumnas();
            Utilidades.cargarCombo(cmbExtremidadPresionArterial, ExtremidadLN.mostrarExtremidades(), "id_extremidad", "nombre");
            Utilidades.cargarCombo(cmbPosicionPresionArterial, PosicionLN.mostrarPosiciones(), "id_posicion", "nombre");
            Utilidades.cargarCombo(cmbSitioMedicionPresionArterial, SitioMedicionLN.mostrarSitiosDeMedicion(), "id_sitioMedicion", "nombre");
            Utilidades.cargarCombo(cmbMomentoDiaPresionArterial, MomentoDiaLN.mostrarMomentosDelDia(), "id_momentoDelDia", "nombre");

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                myPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        private void cmbExtremidadPresionArterial_SelectedIndexChanged(object sender, EventArgs e)
        {
           Utilidades.cargarCombo(cmbUbicacionPresionArterial,   UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(cmbExtremidadPresionArterial.SelectedValue)),"id_ubicacionExtremidad","nombre");
        }
        public void guardarMediciones()
        {
            Extremidad extremidadSeleccionada = (Extremidad)cmbExtremidadPresionArterial.SelectedItem;
            UbicacionExtremidad ubicacionSeleccionada = (UbicacionExtremidad)cmbUbicacionPresionArterial.SelectedItem;
            Posicion posicionSeleccionada = (Posicion)cmbPosicionPresionArterial.SelectedItem;
            MomentoDia momentoDiaSeleccionado = (MomentoDia)cmbMomentoDiaPresionArterial.SelectedItem;
            SitioMedicion sitioSeleccionado = (SitioMedicion)cmbSitioMedicionPresionArterial.SelectedItem;

            if (medicion == null)
                medicion = new MedicionDePresionArterial();

            medicion.extremidad = extremidadSeleccionada;
            medicion.ubicacion = ubicacionSeleccionada;
            medicion.posicion = posicionSeleccionada;
            medicion.momento = momentoDiaSeleccionado;
            medicion.sitio = sitioSeleccionado;
            medicion.horaInicio =Convert.ToDateTime(dgvMediciones.Rows[0].Cells[1].Value);
            medicion.fecha = DateTime.Now;
            if (listaDetalleMedicion == null)
                listaDetalleMedicion = new List<DetalleMedicionPresionArterial>();

            for (int i = 0; i < dgvMediciones.Rows.Count; i++)
            {
                DetalleMedicionPresionArterial nuevoDetalle = new DetalleMedicionPresionArterial();
                nuevoDetalle.id_nroMedicion = (int)dgvMediciones.Rows[i].Cells[0].Value;
                DateTime fechaHora = Convert.ToDateTime(dgvMediciones.Rows[i].Cells[1].Value);
                nuevoDetalle.hora =Convert.ToDateTime(fechaHora.ToShortTimeString());
                nuevoDetalle.valorMaximo = (int)dgvMediciones.Rows[i].Cells[2].Value;
                nuevoDetalle.valorMinimo = (int)dgvMediciones.Rows[i].Cells[3].Value;
                nuevoDetalle.pulso = (int)dgvMediciones.Rows[i].Cells[4].Value;

                listaDetalleMedicion.Add(nuevoDetalle);
            }

            medicion.mediciones = listaDetalleMedicion;
            if (registrarEnHc == true)
            {
                medicion.idHc = idHc;
                //Registrar las mediciones directamente en la historia clinica del paciente
                if (manejador == null)
                    manejador = new ManejadorRegistrarMedicionPresionArterial();

                manejador.registrarMedicioPresionArterialEnHistoriaClinica(medicion);
                MessageBox.Show("Registro de mediciones completo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                //solamente guardar las mediciones en la lista y pasarlas al Menú principal. Se registrarán como parte del un examen general.
                myPort.Close();
                DialogResult = DialogResult.OK;
            }
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarMediciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myPort.Close();
            this.Close();
        }
        public void limpiar()
        {
            in_data = null;
            texto = null;
            txtMediciones.Clear();
            lstMediciones = null;
            dgvMediciones.Rows.Clear();
            medicion = null;
        }
    }
}
