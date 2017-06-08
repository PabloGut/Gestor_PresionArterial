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
    public class HabitoActividadFisicaLN
    {
        public static void registrarHabitosActividadFisica(List<HabitoActividadFisica> habitos, int idHc)
        {
            HabitoActividadFisicaDAO.registrarHabitosActividadFisica(habitos, idHc);
        }
    }
}
