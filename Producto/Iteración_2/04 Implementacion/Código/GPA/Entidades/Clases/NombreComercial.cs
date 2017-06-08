using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class NombreComercial
    {
        public int id_nombreComercial { set; get; }
        public string nombre { set; get; }
        public int id_medicamento_fk { set; get; }

    }
}
