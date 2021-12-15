using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using DAO;
namespace LogicaNegocio
{
    public class TemperaturaPielLN
    {
        public static List<TemperaturaPiel> ObtenerTemperaturasPiel()
        {
            try
            {
                return TemperaturaPielDAO.obtenerTemperaturaPiel();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
