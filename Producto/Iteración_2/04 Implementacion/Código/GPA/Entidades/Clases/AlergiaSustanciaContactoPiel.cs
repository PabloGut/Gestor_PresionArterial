using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AlergiaSustanciaContactoPiel
    {
        public int id_alergiaSustanciaContactoPiel { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_sustanciaContactoPiel { set; get; }
        public string efectos { set; get; }
        public int id_hc { set; get; }
    }
}
