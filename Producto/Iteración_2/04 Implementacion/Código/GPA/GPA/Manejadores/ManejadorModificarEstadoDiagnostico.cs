using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorModificarEstadoDiagnostico
    {
        public List<EstadoDiagnostico> presentarEstadoDiagnostico()
        {
            return EstadoDiagnosticoLN.obtenerEstadosDiagnostico();
        }
        public List<EstudioDiagnosticoPorImagen> presentarEstudiosDiagnosticoPorImagen(int idHc)
        {
            return EstudioDiagnosticoPorImagenLN.obtenerEstudiosDiagnosticoPorImagen(idHc);
        }
    }
}
