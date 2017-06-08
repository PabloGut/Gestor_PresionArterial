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
    public class CaracterDelDolorLN
    {
        public static List<CaracterDelDolor> mostrarCaracterDelDolor()
        {
            return CaracterDelDolorDAO.mostrarCaracterDelDolor();
        }
    }
}
