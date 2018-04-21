using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class PracticaComplementaria:ExploracionComplementaria
    {   
        public int id_tipoPractica {set;get;}
        public int id_PracticaComplementaria { set; get; }
        public TipoPracticaComplementaria tipo { set; get; }
        public int idInstitucion { set; get; }
        public PracticaComplementaria(DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo,string informe, Institucion institucion, string observaciones, string indicaciones,int id_tipoPractica)
            : base(fechaSolicitud, fechaRealizado, doctorAcargo, informe, institucion, observaciones, indicaciones)
        {
            this.id_tipoPractica = id_tipoPractica;
        }
        public PracticaComplementaria()
        { }
    }
}
