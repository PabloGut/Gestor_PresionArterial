using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class ParteDelCuerpoLN
    {   
        /*
         * Método para buscar las partes del cuerpo humano.
         * No recibe parámetros.
         * Retorna una lista de objetos ParteDelCuerpo.
         */
        public static List<ParteDelCuerpo> mostrarPartesDelCuerpoHumano()
        {
            return ParteDelCuerpoDAO.mostrarPartesDelCuerpoHumano();
        }
        public static List<ParteDelCuerpo> presentarPartesDelCuerpo()
        {
            return ParteDelCuerpoDAO.presentarPartesDelCuerpo();
        }
        public static void insertParteDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            ParteDelCuerpoDAO.insertPartesDelCuerpo(parteDelCuerpo);
        }
        public static void updateParteDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            ParteDelCuerpoDAO.updatePartesDelCuerpo(parteDelCuerpo);
        }
        public static void deleteParteDelCuerpo(ParteDelCuerpo parteDelCuerpo)
        {
            ParteDelCuerpoDAO.deletePartesDelCuerpo(parteDelCuerpo);
        }
    }
}
