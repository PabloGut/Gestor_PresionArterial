using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace GPA
{
    public class ManejadorRegistrarInstitucion
    {
        public void registrarInstitucion(Institucion ins, Domicilio dom)
        {
            InstitucionDAO.InsertarInstitucion(ins.nombre,ins.descripcion, dom);
            
        }
        public DataTable buscarInstituciones()
        {
            DataTable dt = InstitucionDAO.buscarInstituciones();
            return dt;
        }

    }
}
