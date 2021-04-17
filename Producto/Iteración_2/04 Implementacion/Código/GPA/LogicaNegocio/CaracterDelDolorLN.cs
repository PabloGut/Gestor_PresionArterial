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
        public static void updateCaracterDolor(CaracterDelDolor caracter)
        {
            CaracterDelDolorDAO.updateCaracterDolor(caracter);
        }
        public static void insertarCaracterDolor(CaracterDelDolor caracter)
        {
            CaracterDelDolorDAO.insertCaracterDolor(caracter);
        }
        public static void deleteCaracterDolor(CaracterDelDolor caracter)
        {
            CaracterDelDolorDAO.deleteCaracterDolor(caracter);
        }
        
    }
}
