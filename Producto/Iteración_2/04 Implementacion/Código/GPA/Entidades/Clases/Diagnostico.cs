using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Diagnostico
    {
        public int id_razonamientoDiagnostico { set; get; }
        public int id_diagnostico { set; get; }
        public string descripcion { set; get; }
        public string evolucion { set; get; }

    }
}
