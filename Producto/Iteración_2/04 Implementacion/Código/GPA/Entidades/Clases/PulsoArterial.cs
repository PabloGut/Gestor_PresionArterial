using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class PulsoArterial
    {
        public int id_pulsoArterial { set; get; }
        public string auscultacion { set; get; }
        public string observaciones { set; get; }
        public List<DetallePulsoArterial> detalles { set; get; }
    }
}
