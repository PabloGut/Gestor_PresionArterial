using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HabitoActividadFisica
    {
        public int id_habitoActividadFisica { set; get; }
        public int id_actividadFisica { set; get; }
        public int id_gradoActividadFisica { set; get; }
        public int id_intensidad { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_hc { set; get; }

    }
}
