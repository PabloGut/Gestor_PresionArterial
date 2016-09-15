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
    }
}
