using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Localidad
    {
        public int id_localidad { get; set; }
        public string nombre { get; set; }

        public Localidad()
        {
            id_localidad = 0;
            nombre = "";
        }

        public Localidad(int id, string nom)
        {
            id_localidad = id;
            nombre = nom;
        }
    }
}
