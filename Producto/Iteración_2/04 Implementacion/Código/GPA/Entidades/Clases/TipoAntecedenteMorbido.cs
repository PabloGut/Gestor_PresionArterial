using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Entidades.Clases
{
    public class TipoAntecedenteMorbido
    {
        public int id_tipoAntecedenteMorbido { set; get; }
        public string nombre { set; get; }
        public List<Operacion> operaciones { set; get; }
        public List<Traumatismo> traumatismos { set; get; }
        public List<Enfermedad> enfermedades { set; get; }
    }
}
