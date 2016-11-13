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
    public class UbicacionExtremidadLN
    {
        public static List<UbicacionExtremidad> buscarUbicacionesExtremidadDeExtremidad(int id_extremidad)
        {
            return UbicacionExtremidadDAO.buscarUbicacionesExtremidadDeExtremidad(id_extremidad);
        }
    }
}
