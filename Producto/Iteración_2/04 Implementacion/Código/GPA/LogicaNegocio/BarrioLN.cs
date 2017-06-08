using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class BarrioLN
    {
        public static List<Barrio> buscarBarriosDeLocalidad(int id_localidad)
        {
            return BarrioDAO.buscarBarriosDeLocalidad(id_localidad);
        }
    }
}
