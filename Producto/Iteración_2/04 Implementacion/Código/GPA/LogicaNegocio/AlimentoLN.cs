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
    public class AlimentoLN
    {
        public static List<Alimento> mostrarAlimentos()
        {
            return AlimentoDAO.mostrarAlimentos();
        }
        public static void RegistrarAlimentoAlergia(Alimento Alimento)
        {
            try
            {
                AlimentoDAO.RegistrarAlimentoAlergia(Alimento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void ActualizarAlimentoAlergia(Alimento Alimento)
        {
            try
            {
                AlimentoDAO.ActualizarAlimentoAlergia(Alimento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
