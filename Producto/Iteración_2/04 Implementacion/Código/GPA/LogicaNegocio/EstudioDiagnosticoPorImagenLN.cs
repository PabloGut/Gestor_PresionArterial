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
        public static List<EstudioDiagnosticoPorImagen> obtenerEstudiosDiagnosticoPorImagen(int idHc)
        {
            return EstudioDiagnosticoPorImagenDAO.obtenerEstudioDiagnosticoPorImagen(idHc);
        }
    }
}
