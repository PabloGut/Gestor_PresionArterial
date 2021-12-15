using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class FamiliarLN
    {
        public static List<Familiar> mostrarFamiliares()
        {
            return FamiliarDAO.mostrarFamiliares();
        }
        public static void RegistrarFamiliar(Familiar familiar)
        {
            try
            {
                FamiliarDAO.RegistrarFamiliar(familiar);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static void ActualizarFamiliar(Familiar familiar)
        {
            try
            {
                FamiliarDAO.ActualizarFamiliar(familiar);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
