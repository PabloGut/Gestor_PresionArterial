using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class DetalleValorReferenciaLaboratorio
    {
        public int id_DetalleValorReferenciaLaboratorio { set; get; }
        public string descripcion { set; get; }
        public float valorDesde { set; get; }
        public float valorHasta { set; get; }
        public int idUnidadMedida { set; get; }
        public UnidadDeMedida unidad { set; get; }

    }
}
