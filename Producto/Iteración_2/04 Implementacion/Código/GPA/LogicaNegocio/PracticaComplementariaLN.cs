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
    public class PracticaComplementariaLN
    {
        public static List<PracticaComplementaria> obtenerPracticasComplementarias(int idRazonamiento)
        {
            return PracticaComplementariaDAO.obtenerPracticasComplementarias(idRazonamiento);
        }
        public static List<PracticaComplementaria> obtenerPracticaComplementariaIdConsulta(int idConsulta)
        {
            try
            {
                return PracticaComplementariaDAO.obtenerEstudioPracticaComplementariaIdConsulta(idConsulta);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
      
    }
}
