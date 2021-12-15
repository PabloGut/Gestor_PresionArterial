using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace LogicaNegocio
{
    public class ConsistenciaLN
    {
        public static List<Consistencia> MostrarConsistencia()
        {
            try
            {
                return ConsistenciaDAO.MostrarConsistencia();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
