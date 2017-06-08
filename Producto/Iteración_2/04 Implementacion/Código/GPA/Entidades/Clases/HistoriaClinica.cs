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
        public DateTime hora { get; set; }
        public DateTime fechaInicioAtencion { get; set; }
        public int id_antecedentes { get; set; }
        public int idtipodoc { get; set; }
        public long nrodoc { get; set; }
        public int idtipodoc_paciente { get; set; }
        public long nrodoc_paciente { get; set; }
        public string motivoConsulta { get; set; }
       
        public List<Estudio> estudios;

        public HistoriaClinica()
        {
            estudios = new List<Estudio>();
        }
        public void agregarEstudio(List<Estudio> e)
        {
            estudios = e;
        }

    }
}
