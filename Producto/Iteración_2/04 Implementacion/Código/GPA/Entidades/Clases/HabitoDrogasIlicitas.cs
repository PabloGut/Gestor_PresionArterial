using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HabitoDrogasIlicitas
    {
        public int id_habitoDrogasIlicitas { set; get; }
        public int id_sustancia { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int tiempoConsumiendo { set; get; }
        public int id_elementoTiempo { set; get; }
        public int id_Hc { set; get; }

    }
}
