using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public class EstadisticasLN
    {
        public static void InsertarEstadisticas()
        {
            try
            {
                EstadisticasDAO.InsertarEstadisticas();
            }
            catch (SqlException e)
            {
                throw e;
            }

        }
        public static List<EstadisticaPromedioEdad> MostrarEstadisticaEdadPromedio()
        {
            try
            {
                return EstadisticasDAO.MostrarEstadisticaPromedio();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCantidadPorSexo> MostrarCantidadFemenino()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesFemenino();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCantidadPorSexo> MostrarCantidadMasculino()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesMasculino();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaModaEdad> MostrarEstadisticaEdadModa()
        {
            try
            {
                return EstadisticasDAO.ModaEdad();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaCantidadMasculinoDataTable()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesMasculinoDataTable();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaCantidadFemeninoDataTable()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesFemeninoDataTable();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPorcentajePacientesPorSexo()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorSexoDataTable();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPacientesPorCategoria()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoría();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPacientesPorCategoriaDataTableConExamen()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoríaDataTableConExamen();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPacientesPorCategoriaDataTableSinExamen()
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoríaDataTableSinExamen();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarPromedioMedicionesConYSinExamen()
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesConYSinExamen();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPromedioSitioExtremidad()
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesSitioExtremidad();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPromedioSitio()
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesSitio();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static void InsertarEstadisticasMedicionesPromedioCategoria()
        {
            try
            {
                EstadisticasDAO.InsertarEstadisticasMedicionesPromedioCategoria();
            }
            catch (SqlException e)
            {
                throw e;
            }

        }
        public static void InsertarEstadisticasSitioMedicionPromedio()
        {
            try
            {
                EstadisticasDAO.InsertarEstadisticasSitioMedicionPromedio();
            }
            catch (SqlException e)
            {
                throw e;
            }

        }
        public static Boolean ExisteCantidadPacientesPorSexo()
        {
            try
            {
                return EstadisticasDAO.ExisteCantidadPacientesPorSexo();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static Boolean ExisteMedicionesPorCategoria()
        {
            try
            {
                return EstadisticasDAO.ExisteMedicionesPorCategoria();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static Boolean ExistePromedioSitioMedicion()
        {
            try
            {
                return EstadisticasDAO.ExistePromedioSitioMedicion();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
    }
}
   

