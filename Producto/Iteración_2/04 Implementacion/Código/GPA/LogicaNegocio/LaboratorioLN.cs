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
    public class LaboratorioLN
    {
        public static List<Laboratorio> obtenerAnalisisLaboratorio(int idRazonamiento)
        {
            return LaboratorioDAO.obtenerAnalisisLaboratorio(idRazonamiento);
        }
        public static void insertResultadosEstudioLaboratorio(Laboratorio laboratorio)
        {
            try
            {
                LaboratorioDAO.insertResultadosEstudioLaboratorio(laboratorio);
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public static List<Laboratorio> obtenerLaboratorioIdConsulta(int idConsulta)
        {
            try
            {
                return LaboratorioDAO.obtenerLaboratorioIdConsulta(idConsulta);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static DataTable MostrarEstudiosLaboratorio(int idHc)
        {
            return LaboratorioDAO.MostrarEstudiosLaboratorio(idHc);
        }
    }
}
