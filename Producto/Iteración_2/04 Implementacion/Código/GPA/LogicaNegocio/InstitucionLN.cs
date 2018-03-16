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
    public class InstitucionLN
    {
        public static DataTable presentarInstituciones()
        {
            return InstitucionDAO.buscarInstituciones();
        }
        public static void insertarInstitucion(Institucion institucion)
        {
            InstitucionDAO.InsertarInstitucion(institucion);
        }
        public static Institucion buscarIdInstitucion(int id)
        {
            return InstitucionDAO.buscarIdInstitucion(id);
        }
        public static List<Institucion> obtenerInstituciones()
        {
            return InstitucionDAO.obtenerInstituciones();
        }
        public static void editarInstitucion(Institucion institucion)
        {
            InstitucionDAO.updateInstitucion(institucion);
        }
    }
}
