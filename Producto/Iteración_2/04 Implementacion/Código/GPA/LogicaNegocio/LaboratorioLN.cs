using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
namespace LogicaNegocio
{
    public class LaboratorioLN
    {
        public static List<Laboratorio> obtenerAnalisisLaboratorio(int idRazonamiento)
        {
            return LaboratorioDAO.obtenerAnalisisLaboratorio(idRazonamiento);
        }
        public static void updateLaboratorio(Laboratorio laboratorio)
        {
            LaboratorioDAO.updateLaboratorio(laboratorio);
        }
    }
}
