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
    public class AlergiaInsectoLN
    {
        public static void registrarAlergiasInsectos(List<AlergiaInsecto> alergiaInsecto, int idHc)
        {
            AlergiaInsectoDAO.registrarAlergiaInsecto(alergiaInsecto, idHc);
        }
        public static DataTable mostrarAlergiasInsectos(int idHc)
        {
            return AlergiaInsectoDAO.mostrarAlegiasInsectos(idHc);
        }
    }
}
