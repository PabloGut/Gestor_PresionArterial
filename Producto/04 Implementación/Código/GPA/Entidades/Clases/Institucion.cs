using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Institucion
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Domicilio domicilio { get; set; }

    }
}
