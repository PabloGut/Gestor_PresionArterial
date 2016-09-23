using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Operacion
    {
        public int id_operacion { set; get; }
        public string nombre { set; get; }
        public int id_tipoAntecedenteMorbido { set; get; }
    }
}
