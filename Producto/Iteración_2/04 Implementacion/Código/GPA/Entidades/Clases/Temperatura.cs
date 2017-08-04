using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Temperatura
    {
        public int id_temperatura { set; get; }
        public int temperatura { set; get; }
        public ResultadoTemperatura resultado { set; get; }
        public SitioMedicionTemperatura sitioMedicion { set; get; }
    }
}
