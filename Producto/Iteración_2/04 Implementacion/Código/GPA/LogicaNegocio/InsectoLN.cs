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
    public class InsectoLN
    {
        public static List<Insecto> mostrarInsectos()
        {
            return InsectoDAO.mostrarInsectos();
        }
        public static void RegistrarInsectoAlergia(Insecto insecto)
        {
            try
            {
                InsectoDAO.RegistrarInsectoAlergia(insecto);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void ActualizarInsectoAlergia(Insecto insecto)
        {
            try
            {
                InsectoDAO.ActualizarInsectoAlergia(insecto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
