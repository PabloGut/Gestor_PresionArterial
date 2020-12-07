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
        public static int calcularPromedio(List<DetalleMedicionPresionArterial> mediciones)
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

        public static int calcularPromedioValorMinimo(List<DetalleMedicionPresionArterial> mediciones)
        {
            int totalSistolica = 0; int cantMediciones = 0;
            foreach (DetalleMedicionPresionArterial detalle in mediciones)
            {
                totalSistolica += detalle.valorMinimo;
                cantMediciones += 1;
            }
            return totalSistolica/ cantMediciones;
        }

        public static int calcularPromedioValorMaximo(List<DetalleMedicionPresionArterial> mediciones)
        {
            int totalDiastolica = 0; int cantMediciones = 0;
            foreach (DetalleMedicionPresionArterial detalle in mediciones)
            {
                totalDiastolica += detalle.valorMaximo;
                cantMediciones += 1;
            }
            return totalDiastolica / cantMediciones;
        }

        public static int registrarMedicionDePresionArterial(MedicionDePresionArterial medicion)
        {
            return MedicionDePresionArterialDAO.registrarMedicionDePresionArterial(medicion);
        }
        public static void registrarMedicionPresionArterialEnHistoriaClinicia(MedicionDePresionArterial medicion)
        {
            MedicionDePresionArterialDAO.registrarMedicionDePresionArterialEnHistoriaClinica(medicion);
        }
        public static DataTable obtenerMedicionesPresionArterial(int idHc)
        {
            return MedicionDePresionArterialDAO.obtenerMedicionesPresionArterial(idHc);
        }
        public static DataTable obtenerDetalleMedicionesPresionArterial(int idHc, int idMedicion)
        {
            return DetalleMedicionPresionArterialDAO.obtenerDetalleMedicionesPresionArterial(idHc, idMedicion);
        }
        public static DataTable obtenerDetalleMedicionesConFiltro(int idHc)
        {
            return DetalleMedicionPresionArterialDAO.obtenerDetalleMedicionesConFiltro(idHc);
        }
    }
}
