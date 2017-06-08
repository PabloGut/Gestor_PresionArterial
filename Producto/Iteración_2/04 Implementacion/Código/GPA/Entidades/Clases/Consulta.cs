using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Consulta
    {
        public int id_consulta { set; get; }
        public int nroConsulta { set; get; }
        public DateTime fecha { set; get; }
        public DateTime hora { set; get; }
        public string motivoConsulta { set; get; }
        public int id_examenGeneral { set; get; }
        public List<Sintoma> sintoma { set; get; }
        public int id_hc { set; get; }
        public ExamenGeneral examen { set; get; }

    }
}
