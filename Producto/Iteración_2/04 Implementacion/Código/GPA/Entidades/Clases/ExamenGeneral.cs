using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ExamenGeneral
    {
        public int id_examenGeneral { set; get; }
        public string posicionYDecubito { set; get; }
        public string marchaYDeambulacion { set; get; }
        public string facieExpresionFisonomia { set; get; }
        public string concienciaEstadoPsiquico { set; get; }
        public string constitucionEstadoNutritivo { set; get; }
        public int peso { set; get; }
        public int talla { set; get; }
        public string descripcionComoRespira { set; get; }
        public string observacionesRespiracion { set; get; }
        public int id_piel { set; get; }
        public int id_razonamiento { set; get; }
        public int id_pulso { set; get; }
        public List<SistemaLinfatico> territoriosExaminados { set; get; }
        public PulsoArterial pulso { set; get; }
        public MedicionDePresionArterial medicion { set; get; }
        public RazonamientoDiagnostico razonamiento { set; get;}
        public Piel examenPiel { set; get; }

    }
}
