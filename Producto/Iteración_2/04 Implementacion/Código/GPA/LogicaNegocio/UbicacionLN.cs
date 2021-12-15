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
    public class UbicacionLN
    {
        public static List<Ubicacion> mostrarUbicaciones()
        {
            try
            {
                return UbicacionDAO.mostrarUbicaciones();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
