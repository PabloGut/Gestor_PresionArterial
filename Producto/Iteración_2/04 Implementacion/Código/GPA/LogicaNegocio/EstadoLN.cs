using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class EstadoLN
    {
        public static List<Estado> buscarEstados()
        {
            return EstadoDAO.buscarEstados();
        }

        public static Estado buscarEstadoPorNombre(string nombre)
        {
            return EstadoDAO.buscarEstadoPorNombre(nombre);
        }
    }
}
