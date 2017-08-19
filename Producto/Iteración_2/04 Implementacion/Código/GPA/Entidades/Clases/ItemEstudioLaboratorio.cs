using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ItemEstudioLaboratorio
    {
        public int id_itemEstudioLaboratoria { set; get; }
        public string nombre { set; get; }
        public float valorResultado { set; get; }
        public int id_unidadMedida { set; get; }
        public int id_detalleEstudio { set; get; }
    }
}
