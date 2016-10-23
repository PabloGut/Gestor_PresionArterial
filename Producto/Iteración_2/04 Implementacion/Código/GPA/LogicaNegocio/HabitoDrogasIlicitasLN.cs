using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades.Clases;
using System.Data;

namespace LogicaNegocio
{
    public class HabitoDrogasIlicitasLN
    {
        public static void registrarHabitoDrogasIlicitas(List<HabitoDrogasIlicitas> habitos, int idHc)
        {
            HabitoDrogasIlicitasDAO.registrarHabitosDrogasIlicitas(habitos, idHc);
        }
    }
}
