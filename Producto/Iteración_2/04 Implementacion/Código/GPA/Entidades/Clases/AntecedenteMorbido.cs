using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class AntecedenteMorbido
    {
        public int id_antecedenteMorbido { set; get; }
        public DateTime fechaRegistro { set; get; }
        public int id_tipoAntecedenteMorbido { set; get; }
        public int cantidadTiempo { set; get; }
        public int id_elementoTiempo { set; get; }
        public string evolución { set; get; }
        public string tratamiento { set; get; }
        public int id_enfermedad { set; get; }
        public int id_traumatismo { set; get; }
        public int id_operacion { set; get; }
        public int id_hc { set; get; }
    }
}
