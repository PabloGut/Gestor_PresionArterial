using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HipotesisInicial
    {
        public int id_hipotesis { set; get; }
        public int id_razonamientoDiagnostico { set; get; }
        public string descripcion { set; get; }
        public int id_estadoH { set; get; }
        public string motivoDescartar { set; get; }


    }
}
