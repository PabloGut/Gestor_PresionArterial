using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class DetalleLaboratorio
    {
        public int idDetalleLaboratorio { set; get; }
       public DetalleResultadoEstudio detalleResultadoEstudio { set; get; }
        public double valorResultado { set; get; }
        public int idUnidadMedida { set; get; }
        public ItemEstudioLaboratorio itemEstudioLaboratorio { set; get; }
        public int idItemEstudioLaboratorio { set; get; }
        public int idItemLaboratorio { set; get; }
        public int idLaboratorio { set; get; }

        public List<DetalleResultadoEstudio> detalleResultadoEstudios { set; get; }
    }
}
