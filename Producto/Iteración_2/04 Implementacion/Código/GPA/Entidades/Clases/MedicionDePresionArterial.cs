using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class MedicionDePresionArterial
    {
        public int id_medicion {set; get;}
        public DateTime fecha { set; get; }
        public Posicion posicion { set; get; }
        public ClasificacionPresionArterial clasificacion { set; get; }
        public int promedio { set; get; }
        public MomentoDia momento { set; get; }
        public SitioMedicion sitio { set; get; }
        public DateTime horaInicio { set; get; }
        public UbicacionExtremidad ubicacion { set; get; }
        public List<DetalleMedicionPresionArterial> mediciones { set; get; }

        public MedicionDePresionArterial()
        {
            mediciones=new List<DetalleMedicionPresionArterial>();
        }
    }
}
