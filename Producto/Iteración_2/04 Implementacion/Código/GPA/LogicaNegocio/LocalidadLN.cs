using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class LocalidadLN
    {
        public static List<Localidad> buscarLocalidades()
        {
            return LocalidadDAO.buscarLocalidades();
        }
    }
}
