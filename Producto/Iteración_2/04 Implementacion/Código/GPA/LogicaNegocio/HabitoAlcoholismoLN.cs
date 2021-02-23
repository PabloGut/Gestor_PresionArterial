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
    public class HabitoAlcoholismoLN
    {
        public static void registrasHabitosAlcoholismo(List<HabitoAlcoholismo> habitosAlcoholismo, int idHc)
        {
            HabitoAlcoholismoDAO.registrarHabitosAlcoholismo(habitosAlcoholismo, idHc);
        }
        public static DataTable MostrarHabitosAlcoholismo(int idHc)
        {
            return HabitoAlcoholismoDAO.MostrarHabitosAlcoholismo(idHc);
        }
    }
}
