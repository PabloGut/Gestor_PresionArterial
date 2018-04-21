using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EstudioDiagnosticoPorImagen:ExploracionComplementaria
    {
        public int id_estudioDiagnosticoPorImagen { set; get; }
        public int id_nombreEstudio { set; get; }
        public NombreEstudio nombreEstudio {set;get;}
        public int idInstitucion { set; get; }
        public EstudioDiagnosticoPorImagen(DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo, string informeEstudio, Institucion institucion, string observaciones, string indicaciones,NombreEstudio nombreEstudio)
        :base(fechaSolicitud,fechaRealizado,doctorAcargo,informeEstudio,institucion,observaciones,indicaciones)
        {
            this.nombreEstudio = nombreEstudio;
        }
        public EstudioDiagnosticoPorImagen()
        { }
    }
}
