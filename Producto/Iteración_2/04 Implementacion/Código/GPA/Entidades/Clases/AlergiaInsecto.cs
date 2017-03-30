using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AlergiaInsecto
    {
        public int id_alergiaInsecto { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_insecto { set; get; }
        public string efectos { set; get; }
        public int id_hc { set; get; }
    }
}
