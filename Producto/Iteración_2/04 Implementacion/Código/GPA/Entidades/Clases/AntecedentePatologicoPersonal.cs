using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AntecedentePatologicoPersonal
    {
        public DateTime fechaRegistro { set; get; }
        public string enfermedades { set; get; }
        public string otrasEnfermedades {set;get;}
        public int idhc { set; get; }
    }
}
