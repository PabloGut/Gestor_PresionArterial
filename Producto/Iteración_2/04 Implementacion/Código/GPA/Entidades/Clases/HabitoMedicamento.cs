using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HabitoMedicamento
    {
        public int id_habitoMedicamento { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_hc { set; get; }
        public int id_programacionMedicamento { set; get; }
        public ProgramacionMedicamento programacion { set; get; }
    }
}
