using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class TemperaturaLN
    {
        public static string determinarResultado(float valorTemperatura)
        {
            string nombreClasificacionTemperatura = TemperaturaDAO.mostrarClasificacionDeTemperatura(valorTemperatura);

            if (string.IsNullOrEmpty(nombreClasificacionTemperatura))
            {
                nombreClasificacionTemperatura = "";
                return nombreClasificacionTemperatura;
            }
            else
            {
                return nombreClasificacionTemperatura;
            }

        }
        public static int ObtenerIdResultadoTemperatura(String resultado)
        {
            try
            {
                return TemperaturaDAO.ObtenerIdResultadoTemperatura(resultado);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
