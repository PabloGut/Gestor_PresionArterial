using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ClasificacionPresionArterial
    {
        public int id_clasificacion { set; get; }
        public string categoria { set; get; }
        public int maximaDesde { set; get; }
        public int maximaHasta { set; get; }
        public int minimaDesde { set; get; }
        public int minimaHasta { set; get; }
    }
}
