using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ExploracionComplementaria
    {   
        
        public int id_razonamientoDiagnostico { set; get; }
        public DateTime fechaSolicitud { set; get; }
        public DateTime fechaRealizacion { set; get; }
        public string DoctorACargo { set; get; }
        public string informeEstudio { set; get; }
        public Institucion institucion { set; get; }
        public string observaciones { set; get; }
        public string indicaciones { set; get; }

        public ExploracionComplementaria(int id_razonamiento, DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo, string informeEstudio, Institucion institucion, string observaciones, string indicaciones)
        {
            
            this.id_razonamientoDiagnostico = id_razonamiento;
            this.fechaSolicitud = fechaSolicitud;
            this.fechaRealizacion = fechaRealizacion;
            this.DoctorACargo = doctorAcargo;
            this.informeEstudio = informeEstudio;
            this.institucion = institucion;
            this.observaciones = observaciones;
            this.indicaciones = indicaciones;
        }
        public ExploracionComplementaria(DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo, string informeEstudio, Institucion institucion, string observaciones, string indicaciones)
        {
            this.fechaSolicitud = fechaSolicitud;
            this.fechaRealizacion = fechaRealizacion;
            this.DoctorACargo = doctorAcargo;
            this.informeEstudio = informeEstudio;
            this.institucion = institucion;
            this.observaciones = observaciones;
            this.indicaciones = indicaciones;
        }
        public ExploracionComplementaria(DateTime fechaSolicitud, DateTime fechaRealizado, string doctorAcargo, Institucion institucion, string observaciones, string indicaciones)
        {
            this.fechaSolicitud = fechaSolicitud;
            this.fechaRealizacion = fechaRealizacion;
            this.DoctorACargo = doctorAcargo;
            this.institucion = institucion;
            this.observaciones = observaciones;
            this.indicaciones = indicaciones;
        }
        public ExploracionComplementaria()
        { }
    }
}
