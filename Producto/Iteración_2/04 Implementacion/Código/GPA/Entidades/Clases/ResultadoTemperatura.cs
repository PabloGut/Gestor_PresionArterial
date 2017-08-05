using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ResultadoTemperatura
    {
        public int id_resultado { get; set; }
        public string nombre { set; get; }
        public float valorMaximo { set; get; }
        public float valorMinimo { set; get; }
    }
}
