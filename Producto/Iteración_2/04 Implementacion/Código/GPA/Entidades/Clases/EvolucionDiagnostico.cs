using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EvolucionDiagnostico
    {
        public int idEvolucionDiagnostico { set; get; }
        public int idHc { set; get; }
        public int idDiagnostico { set; get; }
        public RazonamientoDiagnostico diagnostico { set; get; }
        public DateTime fecha { set; get; }
        public int idExamenGeneral {set;get;}

        public int idEstadoDiagnostico{ set; get; }

       
    }
}
