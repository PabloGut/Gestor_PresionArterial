using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AntecedenteFamiliar
    {
        public int id_antecedenteFamiliar { set; get; }
        public int id_familiar { set; get; }
        public DateTime fechaRegistro { set; get; }
        public string familiarVive { set; get; }
        public List<String> listaEnfermedades { set; get; }
        public string enfermedades { set; get;}
        public string descripcionOtrasEnfermedades { set; get; }
        public string causaMuerte { set; get; }
        public string observaciones { set; get; }
        public int idHc { set; get; }

    }
}
