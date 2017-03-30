using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class RazonamientoDiagnostico
    {
        public int id_razonamiento { set; get; }
        public string conceptoInicial { set; get; }
        public List<HipotesisInicial> hipotesis { set; get; }
        public List<Diagnostico> diagnosticos { set; get; }
        public List<EstudioDiagnosticoPorImagen> estudios { set; get; }
        public List<PruebasDeLaboratorio> pruebas { set; get; }

    }
}
