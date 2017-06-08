using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class UbicacionExtremidad
    {
        public int id_ubicacionExtremidad { set; get;}
        public string nombre { set; get; }
        public Extremidad extremidad { set; get; }
    }
}
