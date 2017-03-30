using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Piel
    {
        public int id_piel { set; get; }
        public string color { set; get; }
        public string elasticidad { set; get; }
        public string humedad { set; get; }
        public string untuosidad { set; get; }
        public string turgor { set; get; }
        public string lesiones { set; get; }
        public TemperaturaPiel temperatura { set; get; }
    }
}
