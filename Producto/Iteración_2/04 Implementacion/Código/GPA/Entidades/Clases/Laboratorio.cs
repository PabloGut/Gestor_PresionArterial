using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Laboratorio:ExploracionComplementaria
    {
        public int id_laboratorio { set; get; }
        public AnalisisLaboratorio analisis { set; get; }

        public Laboratorio( DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo, Institucion institucion, string observaciones, string indicaciones, AnalisisLaboratorio analisis)
            : base(fechaSolicitud, fechaRealizado, doctorAcargo, institucion, observaciones, indicaciones)
        {
            this.analisis = analisis;
         }
    }
}
