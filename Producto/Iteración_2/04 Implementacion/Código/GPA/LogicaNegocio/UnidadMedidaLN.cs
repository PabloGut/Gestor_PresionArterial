using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class UnidadMedidaLN
    {
        public static void registrarUnidadDeMedida(UnidadDeMedida unidadDeMedida)
        {
            UnidadMedidaDAO.registrarUnidadDeMedida(unidadDeMedida);
        }
        public static List<UnidadDeMedida> mostrarUnidadesDeMedida()
        {
            return UnidadMedidaDAO.mostrarUnidadesDeMedida();
        }
        public static void deleteUnidadMedida(int id)
        {
            UnidadMedidaDAO.deleteUnidadMedida(id);
        }
        public static void updateUnidadMedida(UnidadDeMedida unidad)
        {
            UnidadMedidaDAO.updateUnidadMedida(unidad);
        }
    }
}
