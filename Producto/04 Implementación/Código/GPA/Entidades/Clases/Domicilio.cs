using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Domicilio
    {
        public string calle { get;set;}
        public string numero { get; set; }
        public int codigoPostal { get; set; }
        public int piso { get; set; }
        public string departamento { get; set; }
        public Barrio barrio { get; set; }
        public int id_institucion { get; set; }
        public int id_barrio { get; set; }

    }
}
