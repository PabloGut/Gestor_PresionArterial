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
    public class RazonamientoDiagnosticoLN
    {
        public static List<RazonamientoDiagnostico> obtenerDiagnosticos(int idHc)
        {
            return RazonamientoDiagnosticoDAO.obtenerDiagnosticos(idHc);
        }
        public static void updateRazonamientoDiagnostico(RazonamientoDiagnostico diagnostico)
        {
            RazonamientoDiagnosticoDAO.updateRazonamientoDiagnostico(diagnostico);
        }
        
    }
    
}
