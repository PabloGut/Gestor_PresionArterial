using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class EstudioDiagnosticoPorImagenLN
    {
        public static List<EstudioDiagnosticoPorImagen> obtenerEstudiosDiagnosticoPorImagen(int idRazonamiento)
        {
            return EstudioDiagnosticoPorImagenDAO.obtenerEstudioDiagnosticoPorImagen(idRazonamiento);
        }
        public static List<EstudioDiagnosticoPorImagen> obtenerEstudioDiagnosticoPorImagenIdConsulta(int idConsulta)
        {
            try
            {
                return EstudioDiagnosticoPorImagenDAO.obtenerEstudioDiagnosticoPorImagenIdConsulta(idConsulta);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

    }
}
