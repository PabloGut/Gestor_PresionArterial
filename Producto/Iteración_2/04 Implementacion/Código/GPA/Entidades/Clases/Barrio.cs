using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Barrio
    {
        public int id_barrio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int id_localidad { get; set; }
        public Localidad localidad { get; set; }

    }
}
