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
    public class PosicionLN
    {
        public static List<Posicion> MostrarPosiciones()
        {
            try
            {
                return PosicionDAO.MostrarPosiciones();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
