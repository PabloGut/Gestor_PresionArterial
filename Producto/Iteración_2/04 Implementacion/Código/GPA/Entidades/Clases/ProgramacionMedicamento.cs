using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ProgramacionMedicamento
    {
        public int id_programacionMedicamento { set; get; }
        public int id_especificacionMedicamento { set; get; }
        public int id_medicamento { set; get; }
        public int id_frecuencia { set; get; }
        public DateTime fechaDesde { set; get; }
        public DateTime fechaHasta { set; get; }

        public int id_momentoDia1 { set; get; }
        public int cantidad1Numerador { set; get; }
        public int cantidad1Denominador { set; get; }
        public int id_presentacionMedicamento1 { set; get; }
        public DateTime hora1 { set; get; }

        public int id_momentoDia2 { set; get; }
        public int cantidad2Numerador { set; get; }
        public int cantidad2Denominador { set; get; }
        public int id_presentacionMedicamento2 { set; get; }
        public DateTime hora2 { set; get; }

        public int id_momentoDia3 { set; get; }
        public int cantidad3Numerador { set; get; }
        public int cantidad3Denominador { set; get; }
        public int id_presentacionMedicamento3 { set; get; }
        public DateTime hora3 { set; get; }

        public string motivoConsumo { set; get; }
        public int cantidadTiempoConsumo { set; get; }
        public int id_elementoTiempo1 { set; get; }

        public string motivoCancelacion { set; get; }
        public int cantidadCancelacion { set; get; }
        public int id_elementoTiempo2 { set; get; }

        public string automedicamento { set; get; }
        public int id_estado { set; get; }

        public int id_examenGeneral { set; get; }


    }
}
