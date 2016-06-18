using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class HistoriaClinica
    {
        public int id_hc { get; set; }
        public int nro_hc { get; set; }
        public DateTime fecha { get; set; }
        public string diagnostico { get; set; }
        public string antecedentes { get; set; }
        public DateTime fechaInicioAtencion { get; set; }
        public int idtipodoc { get; set; }
        public long nrodoc { get; set; }
    }
}
