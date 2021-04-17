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
        public static DataTable MostrarTratamientos(int idHc)
        {
            try
            {
                return TratamientoDAO.MostrarTratamientos(idHc);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static DataTable MostrarTratamientoMedicamento(int idHc)
        {
            try
            {
                return ProgramacionMedicamentoDAO.MostrarTratamientoMedicamento(idHc);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
