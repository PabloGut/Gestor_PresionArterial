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
        public static int mostrarIdEstadoDiagnostico(string nombreEstado)
        {
            return EstadoDiagnosticoDAO.mostrarIdEstadoDiagnostico(nombreEstado);
        }
        public static List<EstadoDiagnostico> obtenerEstadosDiagnostico()
        {
            return EstadoDiagnosticoDAO.obtenerEstadosDiagnosticos();
        }
    }
}
