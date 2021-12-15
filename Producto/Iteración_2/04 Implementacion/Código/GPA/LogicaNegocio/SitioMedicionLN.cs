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
    public class SitioMedicionLN
    {
        public static List<SitioMedicion> MostrarSitiosDeMedicion()
        {
            try
            {
                return SitioMedicionDAO.MostrarSitiosDeMedicion();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
