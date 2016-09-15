using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
