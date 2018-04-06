using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ItemEstudioLaboratorio
    {
        public int id_itemEstudioLaboratorio { set; get; }
        public int id_itemLaboratorio { set; get; }
        public int idDetalleLaboratorio { set; get; }
        public int id_valorReferencia { set; get; }
        public int id_DetalleItemLaboratorio { set; get; }
        public ItemLaboratorio item { set; get; }
        public List<DetalleItemLaboratorio> detalles { set; get; }
    }
}
