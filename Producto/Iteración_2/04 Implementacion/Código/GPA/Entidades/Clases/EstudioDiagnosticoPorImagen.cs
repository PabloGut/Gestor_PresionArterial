using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EstudioDiagnosticoPorImagen
    {
        public int id_razonamientoDiagnostico { set; get; }
        public int id_estudioDiagnosticoPorImagen { set; get; }
        public int id_nombreEstudio { set; get; }
        public string indicaciones { set; get; }
    }
}
