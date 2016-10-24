using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace LogicaNegocio
{
    public class HistoriaClinicaLN
    {   
        /*
         * Método para mostrar fecha actual.
         * No recibe parámetros.
         * Retorna un string.
         */
        public static string mostrarFechaActual()
        {
            return DateTime.Now.ToShortDateString();
        }
        /*
         * Método para mostrar hora actual.
         * No recibe parámetros.
         * Retorna un string.
         */
        public static string mostrarHoraActual()
        {
            return DateTime.Now.ToShortTimeString();
        }
        public static int registrarHistoriaClinica(HistoriaClinica hc)
        {
            return HistoriaClinicaDAO.registrarHistoriaClinica(hc);
        }
        public static int buscarNroHistoriaClinica()
        {
            return HistoriaClinicaDAO.buscarNroHC();
        }
        public static int calcularSiguienteNroHc()
        {
            int ultimoNro = buscarNroHistoriaClinica();

            int siguienteNroHc = ultimoNro + 1;

            return siguienteNroHc;
 
        }
    }
}
