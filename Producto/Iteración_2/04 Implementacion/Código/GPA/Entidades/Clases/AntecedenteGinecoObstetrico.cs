using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AntecedenteGinecoObstetrico
    {
        public int id_antecedenteGinecoObstetrico { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int cantidadEmbarazos { set; get; }
        public int cantidadEmbarazosPrematuros { set; get; }
        public int id_tipoPartoPrematuro { set; get; }
        public int cantidadEmbarazosATermino { set; get; }
        public int id_tipoPartoATermino { set; get; }
        public int cantidadEmbarazosPosTermino { set; get; }
        public int id_tipoPartoPosTermino { set; get; }
        public int id_aborto { set; get; }
        public int id_hc { set; get; }
        public Aborto aborto { set; get;}

    }
}
