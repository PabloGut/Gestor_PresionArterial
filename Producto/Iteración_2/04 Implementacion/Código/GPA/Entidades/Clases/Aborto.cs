using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Aborto
    {
        public int id_aborto { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int cantidadTotal { set; get; }
        public int cantidadAbortoTipo1 { set; get; }
        public int id_tipoAborto1 { set; get; }
        public int cantidadAbortoTipo2 { set; get; }
        public int id_tipoAborto2 {set;get;}
        public int nroHijosVivos { set; get; }
        public string problemasEmbarazo { set; get; }
    }
}
