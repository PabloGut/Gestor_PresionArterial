using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Extremidad
    {
        public int id_extremidad { set; get; }
        public string nombre { set; get; }
        public List<UbicacionExtremidad> ubicaciones { set; get; }

        public Extremidad()
        {
            id_extremidad = 0;
            nombre = "";
            List<UbicacionExtremidad> ubicaciones = new List<UbicacionExtremidad>();
        }

        public Extremidad(int id, string nom)
        {
            id_extremidad = id;
            nombre = nom;
            List<UbicacionExtremidad> ubicaciones = new List<UbicacionExtremidad>();
        }
    }
}
