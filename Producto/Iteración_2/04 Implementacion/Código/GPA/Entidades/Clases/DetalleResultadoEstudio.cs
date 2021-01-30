using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class DetalleResultadoEstudio
    {
        public int idDetalleResultadoEstudio { set; get; }
        public int idDetalleLaboratorio { set; get; }
        public int idItemLaboratorio { set; get; }
        public DetalleLaboratorio detalleLaboratorio { set; get; }
        public int idDetalleItemLaboratorio { set; get; }
        public DetalleItemLaboratorio detalleItemLaboratorio { set; get; }
        public double valorResultado { set; get; }
        public int idUnidadMedida { set; get; }

        public UnidadDeMedida unidadDeMedida { set; get; }

    }
}
