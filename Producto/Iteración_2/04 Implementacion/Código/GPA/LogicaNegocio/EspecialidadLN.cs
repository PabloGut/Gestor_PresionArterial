using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class EspecialidadLN
    {
        public static List<Especialidad> buscarEspecialidades()
        {
            return EspecialidadDAO.buscarEspecialidades();
        }
    }
}
