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
        public List<EstudioDiagnosticoPorImagen> presentarEstudiosDiagnosticoPorImagen(int idRazonamiento)
        {
            return EstudioDiagnosticoPorImagenLN.obtenerEstudiosDiagnosticoPorImagen(idRazonamiento);
        }
        public List<RazonamientoDiagnostico> presentarDiagnosticos(int idHc)
        {
            return RazonamientoDiagnosticoLN.obtenerDiagnosticos(idHc);
        }
        public List<PracticaComplementaria> presentarPracticaComplementaria(int idRazonamiento)
        {
            return PracticaComplementariaLN.obtenerPracticasComplementarias(idRazonamiento);
        }
        public List<Laboratorio> presentarAnalisisLaboratorio(int idRazonamiento)
        {
            return LaboratorioLN.obtenerAnalisisLaboratorio(idRazonamiento);
        }
    }
}
