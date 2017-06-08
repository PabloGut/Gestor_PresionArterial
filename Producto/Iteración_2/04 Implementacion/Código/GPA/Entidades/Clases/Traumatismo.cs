using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Traumatismo
    {
        public int id_traumatismo { set; get; }
        public string nombre { set; get; }
        public string descripcion { set; get; }
        public int id_tipoAntecedenteMorbido { set; get; }
    }
}
