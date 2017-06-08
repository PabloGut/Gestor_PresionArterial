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
    public class AlergiaAlimentoLN
    {
        public static void registrarAlergiaAlimentos(List<AlergiaAlimento> alergiaAlimentos, int idHc)
        {
            AlergiaAlimentoDAO.registrarAlergiaAlimentos(alergiaAlimentos, idHc);
        }
        public static DataTable mostrarAlergiasAlimentos(int idHc)
        {
            return AlergiaAlimentoDAO.mostrarAlegiasAlimentos(idHc);
        }
        
    }
}
