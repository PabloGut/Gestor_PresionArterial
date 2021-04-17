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
    public class DescripcionDelTiempoLN
    {
        public static List<DescripcionDelTiempo> MostrarDescripcionesDelTiempo()
        {
            return DescripcionDelTiempoDAO.MostrarDescripcionesDelTiempo();
        }
        public static void InsertarDescripcionDelTiempo(DescripcionDelTiempo descripcion)
        {
            DescripcionDelTiempoDAO.InsertDescripcionTiempo(descripcion);
        }
        public static void DeleteDescripcionTiempo(DescripcionDelTiempo Descripcion)
        {
            DescripcionDelTiempoDAO.DeleteDescripcionTiempo(Descripcion);
        }
        public static void UpdateDescripcionTiempo(DescripcionDelTiempo Descripcion)
        {
            DescripcionDelTiempoDAO.UpdateDescripcionTiempo(Descripcion);
        }
    }
   
}
