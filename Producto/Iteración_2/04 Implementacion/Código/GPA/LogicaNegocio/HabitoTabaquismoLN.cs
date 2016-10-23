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
    public class HabitoTabaquismoLN
    {
        public static void registrasHabitosTabaquismo(List<HabitoTabaquismo> habitosTabaquismo, int idHc)
        {
            HabitoTabaquismoDAO.registrarHabitosTabaquismo(habitosTabaquismo, idHc);
        }
    }
}
