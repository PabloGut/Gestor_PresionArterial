using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
using LogicaNegocio;
namespace GPA
{
    public class ManejadorRegistrarInstitucion
    {
        public void registrarInstitucion(Institucion ins)
        {
            InstitucionDAO.InsertarInstitucion(ins);
        }
        public DataTable buscarInstituciones()
        {
            DataTable dt = InstitucionDAO.buscarInstituciones();
            return dt;
        }
        public Institucion buscarIdInstitucion(int id)
        {
            return InstitucionLN.buscarIdInstitucion(id);
        }
        public List<Institucion> obtenerInstituciones()
        {
            return InstitucionLN.obtenerInstituciones();
        }
        public void editarInstitucion(Institucion institucion)
        {
            InstitucionLN.editarInstitucion(institucion);
        }
    }
}
