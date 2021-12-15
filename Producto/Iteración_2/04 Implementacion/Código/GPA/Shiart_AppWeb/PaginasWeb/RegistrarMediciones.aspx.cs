using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shiart_AppWeb.Clases;
using System.IO.Ports;
using Entidades.Clases;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Reflection;

namespace Shiart_AppWeb.PaginasWeb
{
    public partial class RegistrarMediciones : System.Web.UI.Page
    {
        public MedicionesTensiometro medicionesTensiometro;
        public string infoMediciones;

        private static SerialPort myPort;
        private static string in_data;
        public string texto;
        private Boolean primeraIteracion = true;

        public int cantMediciones;
        public MedicionDePresionArterial medicion;
        public DetalleMedicionPresionArterial detalle;
        public int NroDeMedicion = 0;
        public int nroIteracion = 0;
        public string fechaHoraMedicion;

        public String sistolica;
        public String diastolica;
        public string pulso;

        public Boolean registroFecha = false;
        public Boolean registroSistolica = false;
        public Boolean registroDiastolica = false;
        public Boolean registroNroMedicion = false;

        public int posicion;
        public int momentoDia;
        public int sitioMedicion;
        public int extremidad;
        public int ubicacionExtremidad;
        public int hc;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCombos();
            }
        }
        public void cargarCombos()
        {
            
            cargarCombo(ddlExtremidad, ExtremidadLN.MostrarExtremidades(),"id_extremidad", "nombre");
            cargarCombo(ddlPosicion, PosicionLN.MostrarPosiciones(), "id_posicion","nombre");
            cargarCombo(ddlMomentoDia, MomentoDiaLN.MostrarMomentosDelDia(),"idmomentoDia", "nombre");
            cargarCombo(ddlSitioMedicion, SitioMedicionLN.MostrarSitiosDeMedicion(), "id_sitioMedicion","nombre");
            
            if(Convert.ToInt32(ddlExtremidad.SelectedItem.Value)== 1)
            { 
                cargarCombo(ddlUbicacion, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(ddlExtremidad.SelectedItem.Value)), "id_ubicacionExtremidad", "nombre");
            }
        }
        public static void cargarCombo<T>(DropDownList combo, List<T> lista, string valueMember, string displayMember)
        {
            combo.DataSource = lista;
            combo.DataTextField = displayMember;
            combo.DataValueField = valueMember;
            combo.DataBind();
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {

            String  resultado=validar();
           
            if (resultado.Equals("")==false)
            {
                generarAlerta(resultado);
                return;
            }

            if (medicionesTensiometro == null)
            {
                if (Session["pacienteLogueado"] != null)
                {
                    Paciente paciente = (Paciente)Session["pacienteLogueado"];

                    posicion= Convert.ToInt32(ddlPosicion.SelectedValue);
                    momentoDia=Convert.ToInt32(ddlMomentoDia.SelectedValue);
                    sitioMedicion=Convert.ToInt32(ddlSitioMedicion.SelectedValue);
                    extremidad=Convert.ToInt32(ddlExtremidad.SelectedValue);
                    ubicacionExtremidad=Convert.ToInt32(ddlUbicacion.SelectedValue);
                    hc=paciente.id_hc;
                }
            }
            iniciar();
        }

        protected void ddlExtremidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCombo(ddlUbicacion, UbicacionExtremidadLN.buscarUbicacionesExtremidadDeExtremidad(Convert.ToInt32(ddlExtremidad.SelectedItem.Value)), "id_ubicacionExtremidad", "nombre");
        }

        public void iniciar()
        {
            myPort = new SerialPort();
            myPort.BaudRate = 115200;
            myPort.PortName = "COM3";
            //myPort.DataReceived += myPort_DataReceived;
            myPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            try
            {
                myPort.Open();
            }
            catch (Exception a)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al leer puerto COM')", true);
                generarAlerta("Error al leer el puerto COM");
            }
           
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Obtenemos el puerto serie que lanza el evento
            if (myPort != null)
            {
                SerialPort currentSerialPort = (SerialPort)sender;

                // Leemos el dato recibido del puerto serie
                in_data = currentSerialPort.ReadLine();
                obtenerCadena();
            }
        }
        public Boolean buscarCadena(String cadena)
        {
            return cadena.Contains("Number of measures");
        }
        public void obtenerCadena()
        {
            if (primeraIteracion == true && buscarCadena(in_data) && in_data.Length == 23)
            {
                texto = in_data;
                recorrerTexto();
            }
            else
            {
                if (primeraIteracion == false)
                {
                    texto = in_data;
                    recorrerTexto();
                }
            }
            texto = "";
        }
        public void recorrerTexto()
        {   
            if(detalle==null)
            {
                detalle = new DetalleMedicionPresionArterial();
            }

            if (primeraIteracion == true)
            {
                if (Convert.ToInt32(texto[21].ToString()) > 0)
                {
                    cantMediciones = Convert.ToInt32(texto[21].ToString());
                    medicion = new MedicionDePresionArterial();
                    primeraIteracion = false;
                }
            }
            else
            {
                if (texto.Contains("Measure number") == true)
                {
                    NroDeMedicion = Convert.ToInt32(texto.Substring(15, 1));
                    detalle.id_nroMedicion = NroDeMedicion;
                    registroNroMedicion = true;
                }
                if (texto.Contains("Date") && registroNroMedicion == true)
                {
                    
                    //fechaHoraMedicion = texto.Substring(8, 26);
                    fechaHoraMedicion = texto.Substring(8, texto.Substring(8).Length);

                    DateTime date = obtenerFecha(fechaHoraMedicion);
                    detalle.hora = Convert.ToDateTime(date.ToShortTimeString());

                    if (NroDeMedicion == 1)
                    {
                        medicion.fecha = Convert.ToDateTime(date.ToShortDateString());
                        medicion.horaInicio = Convert.ToDateTime(date.ToShortTimeString());
                    }

                    registroFecha = true;
                }
                if (texto.Contains("Systolic value") && registroFecha == true)
                {
                    sistolica = texto.Substring(17, 3);
                    detalle.valorMaximo = Convert.ToInt32(sistolica);
                    registroSistolica = true;
                }
                if (texto.Contains("Diastolic value") && registroFecha == true && registroSistolica == true)
                {
                    diastolica = texto.Substring(17, 3);
                    detalle.valorMinimo = Convert.ToInt32(diastolica);
                    registroDiastolica = true;
                }
                if (texto.Contains("Pulse value") && registroFecha == true && registroSistolica == true && registroDiastolica == true)
                {
                    pulso = texto.Substring(14, 3);
                    detalle.pulso = Convert.ToInt32(pulso);

                    medicion.mediciones.Add(detalle);
                    registroNroMedicion = false;
                    registroDiastolica = false;
                    registroSistolica = false;
                    registroFecha = false;

                    nroIteracion++;
                    detalle = null;
                }

                if (cantMediciones == nroIteracion)
                {
                    //fin carga
                    myPort.Close();
                    Posicion p = new Posicion();
                    p.id_posicion = posicion;
                    p.nombre = ddlPosicion.SelectedItem.Text;
                    MomentoDia m = new MomentoDia();
                    m.idMomentoDia = momentoDia;
                    m.nombre = ddlMomentoDia.SelectedItem.Text;
                    Extremidad ex = new Extremidad();
                    ex.id_extremidad = extremidad;
                    ex.nombre = ddlExtremidad.SelectedItem.Text;
                    UbicacionExtremidad uex = new UbicacionExtremidad();
                    uex.id_ubicacionExtremidad = ubicacionExtremidad;
                    uex.nombre = ddlUbicacion.SelectedItem.Text;
                    SitioMedicion s = new SitioMedicion();
                    s.id_sitioMedicion = sitioMedicion;
                    s.nombre = ddlSitioMedicion.SelectedItem.Text;

                    medicion.posicion = p;
                    medicion.momento = m;
                    medicion.extremidad = ex;
                    medicion.ubicacion = uex;
                    medicion.sitio = s;
                    medicion.idHc = hc;
                    MedicionDePresionArterialLN.RegistrarMedicionPresionArterialEnHistoriaClinicia(medicion);
                    generarAlerta("Carga finalizada!!!");
                    Session["medicionesPresionArterial"] = medicion;
                }
            }
        }
        public DateTime obtenerFecha(string fecha)
        {
            string cadenaFecha = "";
            string nroDia = "";
            string mes = "";
            string año = "";
            string hora = "";

            cadenaFecha = fecha.Substring(0);/// caracter 7 es el espacio en blanco

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

            while (j < cadenaFecha.Length && (char.IsNumber(cadenaFecha[j]) || char.IsPunctuation(cadenaFecha[j])))
            {
                hora += cadenaFecha[j];
                j++;
            }

            mes = obtenerMes(mes);

            fecha = nroDia + "/" + mes + "/" + año + " " + hora;
            return Convert.ToDateTime(fecha);
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

        protected void btnMostrarMediciones_Click(object sender, EventArgs e)
        {
            if(Session["medicionesPresionArterial"]!=null)
            {
                medicion = (MedicionDePresionArterial) Session["medicionesPresionArterial"];
                gvMediciones.DataSource = obtenerDataTable(medicion);
                //gvMediciones.DataKeyNames= new string[] { "id_nroMedicion" };
                gvMediciones.DataBind();
            }
        }
        public DataTable obtenerDataTable(MedicionDePresionArterial medicion)
        {
            DataTable datatable = new DataTable();
            DataRow fila;

            datatable.Columns.Add("Fecha de Medición");
            datatable.Columns.Add("Extremidad");
            datatable.Columns.Add("Ubicación Extremidad");
            datatable.Columns.Add("Posición");
            datatable.Columns.Add("Momento del día");
            datatable.Columns.Add("Sitio Medición");
            datatable.Columns.Add("Número");
            datatable.Columns.Add("Hora");
            datatable.Columns.Add("Sistólica");
            datatable.Columns.Add("Diastólica");
            datatable.Columns.Add("Pulso");

            foreach(DetalleMedicionPresionArterial detalle in  medicion.mediciones)
            {
                fila = datatable.NewRow();
                fila["Fecha de Medición"] = medicion.fecha.ToShortDateString();
                fila["Extremidad"] = medicion.extremidad.nombre;
                fila["Ubicación Extremidad"] = medicion.ubicacion.nombre;
                fila["Posición"] = medicion.posicion.nombre;
                fila["Sitio Medición"] = medicion.sitio.nombre;
                fila["Momento del día"] = medicion.momento.nombre;
                fila["Número"] = detalle.id_nroMedicion;
                fila["Hora"] = detalle.hora.ToShortTimeString();
                fila["Sistólica"] = detalle.valorMaximo;
                fila["Diastólica"] = detalle.valorMinimo;
                fila["Pulso"] = detalle.pulso;

                datatable.Rows.Add(fila);
            }
            return datatable;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Session["medicionesPresionArterial"] != null)
            {
                medicion = (MedicionDePresionArterial)Session["medicionesPresionArterial"];
                gvMediciones.DataSource = obtenerDataTable(medicion);
                gvMediciones.DataBind();
            }
        }
        public String validar()
        {
            if (ddlExtremidad.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar Extremidad";
            }
            if (ddlUbicacion.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar Ubicación";
            }
            if (ddlPosicion.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar Posición";
            }
            if (ddlMomentoDia.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar Momento del día";
            }
            if (ddlSitioMedicion.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar Sitio de medición";
            }
            if (ddlSitioMedicion.SelectedItem.ToString().Equals("--Seleccionar--"))
            {
                return "Falta seleccionar el Sitio de medición";
            }
            return "";
        }
        public void generarAlerta(String Mensaje)
        {
            String script = string.Format(@"<script type='text/javascript'>
                                    alert('{0}')
                                    </script>", Mensaje);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", script, false);
        }

    }
}