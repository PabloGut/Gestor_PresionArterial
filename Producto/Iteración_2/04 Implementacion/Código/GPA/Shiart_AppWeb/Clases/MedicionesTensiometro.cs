using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO.Ports;
using System.IO;
using Entidades.Clases;
using LogicaNegocio;

namespace Shiart_AppWeb.Clases
{
    public class MedicionesTensiometro
    {
        private SerialPort myPort;
        private string in_data;
        public string texto;
        private Boolean primeraIteracion=true;

        public int cantMediciones;
        public MedicionDePresionArterial medicion;
        public DetalleMedicionPresionArterial detalle;
        public int NroDeMedicion = 0;
        public int nroIteracion = 0;
        public string fechaHoraMedicion;

        public String sistolica;
        public String diastolica;
        public string pulso;

        public Boolean registroFecha=false;
        public Boolean registroSistolica=false;
        public Boolean registroDiastolica=false;
        public Boolean registroNroMedicion = false;

        public int posicion;
        public int momentoDia;
        public int sitioMedicion;
        public int extremidad;
        public int ubicacionExtremidad;
        public int hc;
        public MedicionesTensiometro(int posicion, int momentoDia, int sitioMedicion, int extremidad, int ubicacionExtremidad, int hc)
        {
            this.posicion = posicion;
            this.momentoDia = momentoDia;
            this.sitioMedicion = sitioMedicion;
            this.extremidad = extremidad;
            this.ubicacionExtremidad = ubicacionExtremidad;
            this.hc = hc;
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

            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Obtenemos el puerto serie que lanza el evento
            if (myPort !=null)
            {
                SerialPort currentSerialPort = (SerialPort)sender;

                // Leemos el dato recibido del puerto serie
                in_data = currentSerialPort.ReadLine();
                obtenerCadena();
            }
           
        }
        private void myPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            in_data = myPort.ReadLine();
        }
        public MedicionDePresionArterial getMedicionPresionArterial()
        {
            return medicion;
        }
        public Boolean buscarCadena(String cadena)
        {
            return cadena.Contains("Number of measures");
        }
        public void obtenerCadena()
        {
            
            if (primeraIteracion == true && buscarCadena(in_data) && in_data.Length==23)
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
            if(primeraIteracion == true)
            {
                if (Convert.ToInt32(texto[21].ToString()) > 0)
                {
                    cantMediciones = Convert.ToInt32(texto[21].ToString());
                    medicion = new MedicionDePresionArterial();
                    detalle = new DetalleMedicionPresionArterial();
                    primeraIteracion = false;
                }
            }
            else
            {
                if(texto.Contains("Measure number")==true)
                {
                    NroDeMedicion = Convert.ToInt32(texto.Substring(15, 1));
                    detalle.id_nroMedicion = NroDeMedicion;
                    registroNroMedicion = true;
                }
                if(texto.Contains("Date") && registroNroMedicion==true)
                {
                    fechaHoraMedicion = texto.Substring(8, 26);
                    DateTime date= obtenerFecha(fechaHoraMedicion);
                    detalle.hora = Convert.ToDateTime(date.ToShortTimeString());

                    if (NroDeMedicion == 1)
                    {
                        medicion.fecha = Convert.ToDateTime(date.ToShortDateString());
                        medicion.horaInicio = Convert.ToDateTime(date.ToShortTimeString());
                    }

                    registroFecha = true;
                }
                if (texto.Contains("Systolic value") && registroFecha==true)
                {
                    sistolica = texto.Substring(17, 3);
                    detalle.valorMaximo = Convert.ToInt32(sistolica);
                    registroSistolica = true;
                }
                if (texto.Contains("Diastolic value") && registroFecha==true && registroSistolica==true)
                {
                    diastolica = texto.Substring(17, 3);
                    detalle.valorMinimo = Convert.ToInt32(diastolica);
                    registroDiastolica = true;
                }
                if (texto.Contains("Pulse value") && registroFecha == true && registroSistolica == true && registroDiastolica==true)
                {
                    pulso = texto.Substring(14, 3);
                    detalle.pulso = Convert.ToInt32(pulso);

                    medicion.mediciones.Add(detalle);
                    registroNroMedicion = false;
                    registroDiastolica = false;
                    registroSistolica = false;
                    registroFecha = false;

                    nroIteracion++;
                }

                if(cantMediciones==nroIteracion)
                {
                    //fin carga
                    myPort.Close();
                    Posicion p = new Posicion();
                    p.id_posicion = posicion;
                    MomentoDia m = new MomentoDia();
                    m.idMomentoDia = momentoDia;
                    Extremidad ex = new Extremidad();
                    ex.id_extremidad = extremidad;
                    UbicacionExtremidad uex = new UbicacionExtremidad();
                    uex.id_ubicacionExtremidad = ubicacionExtremidad;
                    SitioMedicion s = new SitioMedicion();
                    s.id_sitioMedicion = sitioMedicion;

                    medicion.posicion = p;
                    medicion.momento = m;
                    medicion.extremidad = ex;
                    medicion.ubicacion = uex;
                    medicion.sitio = s;
                    medicion.idHc = hc;
                    MedicionDePresionArterialLN.registrarMedicionPresionArterialEnHistoriaClinicia(medicion);
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

    }
    

}

