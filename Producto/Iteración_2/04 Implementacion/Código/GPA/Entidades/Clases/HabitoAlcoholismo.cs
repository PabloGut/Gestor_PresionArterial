using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HabitoAlcoholismo
    {
        public int id_habitoAlcoholismo { set; get; }
        public int id_tipoBebida { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int cantidad { set; get; }
        public int id_medida { set; get; }
        public int id_componenteTiempo { set; get; }
        public int id_hc { set; get; }
     
    }
}
