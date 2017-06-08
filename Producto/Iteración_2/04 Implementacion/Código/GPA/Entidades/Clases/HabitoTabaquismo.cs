using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HabitoTabaquismo
    {
        public int id_habitoFumar { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int cantidad { set; get; }
        public int id_elementoQueFuma { set; get; }
        public int id_componenteTiempo { set; get; }
        public int añosFumando { set; get; }
        public int id_hc { set; get; }
        public DejoDeFumar dejoDeFumar { set; get; }



    }
}
