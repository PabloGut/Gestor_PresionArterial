using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;


namespace LogicaNegocio
{
    public class TratamientoLN
    {
        public static List<Tratamiento> mostrarTratamientos(int idRazonamientoDiagnostico)
        {
            try
            {
                return TratamientoDAO.mostrarTratamientos(idRazonamientoDiagnostico);
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
    }
}
