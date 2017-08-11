using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Tratamiento
    {
        public int id_tratamiento { set; get; }
        public string indicaciones { set; get; }
        public DateTime fechaInicio { set; get; }
        public string motivoInicio { set; get; }
        public List<ProgramacionMedicamento> medicamentos { set; get; }
        public DateTime fechaFin { set; get; }
        public string motivoFin { set; get; }
        public List<Nota> notasEvolucionTratamiento { set; get; }
    }
}
