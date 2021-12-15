using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
using System.IO.Ports;
using System.IO;

namespace LogicaNegocio
{
    public class MedicionDePresionArterialLN
    {
        public static int CalcularPromedio(List<DetalleMedicionPresionArterial> mediciones)
        {
            int totalSistolica=0; int totalDiastolica=0; int cantMediciones=0;
            foreach(DetalleMedicionPresionArterial detalle in mediciones)
            {
                totalSistolica+=detalle.valorMinimo;
                totalDiastolica+=detalle.valorMaximo;
                cantMediciones+=2;
            }
            return (totalSistolica + totalDiastolica) / cantMediciones;
        }

        public static int CalcularPromedioValorMinimo(List<DetalleMedicionPresionArterial> mediciones)
        {
            int totalSistolica = 0; int cantMediciones = 0;
            foreach (DetalleMedicionPresionArterial detalle in mediciones)
            {
                totalSistolica += detalle.valorMinimo;
                cantMediciones += 1;
            }
            return totalSistolica/ cantMediciones;
        }

        public static int CalcularPromedioValorMaximo(List<DetalleMedicionPresionArterial> mediciones)
        {
            int totalDiastolica = 0; int cantMediciones = 0;
            foreach (DetalleMedicionPresionArterial detalle in mediciones)
            {
                totalDiastolica += detalle.valorMaximo;
                cantMediciones += 1;
            }
            return totalDiastolica / cantMediciones;
        }

        public static int RegistrarMedicionDePresionArterial(MedicionDePresionArterial medicion)
        {
            return MedicionDePresionArterialDAO.RegistrarMedicionDePresionArterial(medicion);
        }
        public static void RegistrarMedicionPresionArterialEnHistoriaClinicia(MedicionDePresionArterial medicion)
        {
            try
            {
                MedicionDePresionArterialDAO.RegistrarMedicionDePresionArterialEnHistoriaClinica(medicion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        public static DataTable ObtenerMedicionesPresionArterial(int idHc,DateTime? fechaDesde,DateTime? fechaHasta,String extremidad,String momentoDia,String posicion,String ubicacionExtremidad,String sitioMedicion)
        {
            try
            {
                return MedicionDePresionArterialDAO.ObtenerMedicionesPresionArterial(idHc, fechaDesde, fechaHasta, extremidad, momentoDia, posicion, ubicacionExtremidad, sitioMedicion);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static DataTable ObtenerDetalleMedicionesPresionArterial(int idHc, int idMedicion,DateTime? fechaDesde, DateTime? fechaHasta, String extremidad, String momentoDia, String posicion, String ubicacionExtremidad, String sitioMedicion)
        {
            return DetalleMedicionPresionArterialDAO.obtenerDetalleMedicionesPresionArterial(idHc, idMedicion, fechaDesde,fechaHasta,extremidad,momentoDia,posicion,ubicacionExtremidad,sitioMedicion);
        }
        public static DataTable ObtenerDetalleMedicionesConFiltro(int idHc)
        {
            return DetalleMedicionPresionArterialDAO.obtenerDetalleMedicionesConFiltro(idHc);
        }
        public static List<MedicionDePresionArterial> ObtenerMedicionesPresionArterialIdConsulta(int idConsulta)
        {
            try
            {
                return MedicionDePresionArterialDAO.ObtenerMedicionesPresionArterialIdConsulta(idConsulta);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static DataTable ObtenerMedicionesConFiltro(int idHistoriaClinica, DateTime? fechaDesde, DateTime? fechaHasta,String idExtremidad, String idMomentoDia, String idPosicion, String idUbicacionExtremidad, String idSitioMedicion)
        {
            try { 

             return MedicionDePresionArterialDAO.ObtenerMedicionesPresionArterialConFiltro(idHistoriaClinica, fechaDesde, fechaHasta, idExtremidad, idMomentoDia, idPosicion, idUbicacionExtremidad, idSitioMedicion);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static DataTable ObtenerMediciones(int idHc)
        {
            return MedicionDePresionArterialDAO.ObtenerMediciones(idHc);
        }

    }
}
