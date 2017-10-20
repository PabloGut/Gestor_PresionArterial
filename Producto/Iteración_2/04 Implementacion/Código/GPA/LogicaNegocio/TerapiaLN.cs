using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class TerapiaLN
    {
        public static List<Terapia> mostrarTerapias()
        {
            return TerapiaDAO.mostrarTerapias();
        }
    }
}
