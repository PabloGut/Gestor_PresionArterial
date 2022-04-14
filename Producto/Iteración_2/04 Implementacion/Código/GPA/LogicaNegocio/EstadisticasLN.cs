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
        public static List<EstadisticaPromedioEdad> MostrarEstadisticaEdadPromedio(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.MostrarEstadisticaPromedio(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCantidadPorSexo> MostrarCantidadFemenino(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesFemenino(FechaDesde, FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCantidadPorSexo> MostrarCantidadMasculino(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesMasculino(FechaDesde, FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaModaEdad> MostrarEstadisticaEdadModa(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.ModaEdad(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaCantidadMasculinoDataTable(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesMasculinoDataTable(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaCantidadFemeninoDataTable(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesFemeninoDataTable(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPorcentajePacientesPorSexo(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorSexoDataTable(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPacientesPorCategoria(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoría(FechaDesde, FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPacientesPorCategoriaDataTableConExamen(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoríaDataTableConExamen(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static DataTable MostrarEstadisticaPacientesPorCategoriaDataTableSinExamen(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.CantidadPacientesPorCategoríaDataTableSinExamen(FechaDesde,FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarPromedioMedicionesConYSinExamen(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesConYSinExamen(FechaDesde, FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPromedioSitioExtremidad(DateTime? FechaDesde,DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesSitioExtremidad(FechaDesde, FechaHasta);
            }
            catch (SqlException e)
            {
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> MostrarEstadisticaPromedioSitio(DateTime? FechaDesde, DateTime? FechaHasta)
        {
            try
            {
                return EstadisticasDAO.PromedioMedicionesSitio(FechaDesde, FechaHasta);
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
   

