using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class DetalleItemLaboratorio
    {
        public int id_detalleItemLaboratorio { set; get; }
        public string nombre { set; get; }
        public float valorDesde { set; get; }
        public float valorHasta { set; get; }
        public int id_unidadMedida { set; get; }
        public int id_detalleValorReferencia { set; get; }
        public List<DetalleValorReferenciaLaboratorio> detalle { set; get; }


    }
}
