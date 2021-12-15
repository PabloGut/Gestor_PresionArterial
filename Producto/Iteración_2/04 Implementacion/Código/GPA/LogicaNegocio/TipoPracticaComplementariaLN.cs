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
    public class TipoPracticaComplementariaLN
    {
        public static List<TipoPracticaComplementaria> MostrarPracticasComplementarias()
        {
            try
            {
                return TipoPracticaComplementariaDAO.MostrarPracticasComplementarias();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static int mostrarTipoPracticaComplementaria(string nombre)
        {
            return TipoPracticaComplementariaDAO.mostrarPracticaComplementaria(nombre);
        }
    }
}
