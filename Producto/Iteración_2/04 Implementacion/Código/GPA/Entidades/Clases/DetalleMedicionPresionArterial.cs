using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class DetalleMedicionPresionArterial
    {
        public int id_nroMedicion { set; get; }
        public DateTime hora { set; get; }
        public int pulso { set; get; }
        public int valorMaximo { set; get; }
        public int valorMinimo { set; get; }
    }
}
