using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AlergiaSustanciaAmbiente
    {
        public int id_alergiaSustanciaAmbiente { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_sustanciaAmbiente { set; get; }
        public string efectos { set; get; }
        public int id_hc { set; get; }
    }
}
