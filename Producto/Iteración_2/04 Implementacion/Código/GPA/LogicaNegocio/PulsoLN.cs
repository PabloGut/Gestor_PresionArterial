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
    public class PulsoLN
    {
        public static List<Pulso> mostrarPulsos()
        {
            try
            {
                return PulsoDAO.mostrarPulsos();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
