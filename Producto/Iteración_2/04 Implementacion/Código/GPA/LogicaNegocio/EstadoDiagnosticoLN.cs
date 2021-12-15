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
    public class EstadoDiagnosticoLN
    {
        public static int MostrarIdEstadoDiagnostico(string nombreEstado)
        {
            return EstadoDiagnosticoDAO.MostrarIdEstadoDiagnostico(nombreEstado);
        }
        public static List<EstadoDiagnostico> ObtenerEstadosDiagnostico()
        {
            try
            {
                return EstadoDiagnosticoDAO.ObtenerEstadosDiagnosticos();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
