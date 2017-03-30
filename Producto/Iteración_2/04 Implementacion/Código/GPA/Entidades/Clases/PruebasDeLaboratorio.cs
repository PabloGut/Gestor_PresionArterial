using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class PruebasDeLaboratorio
    {
        public int id_razonamientoDiagnostico { set; get; }
        public int id_pruebaLaboratorio { set; get; }
        public int id_analisis { set; get; }
        public string indicaciones { set; get; }
    }
}
