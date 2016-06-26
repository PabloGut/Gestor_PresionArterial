using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Estudio
    {
        public int id_estudio { get; set; }
        public string nombre { get; set; }
        public DateTime fecha { get; set; }
        public String doctorACargo { get; set; }
        public String informeEstudio { get; set; }
        private Institucion institucion { get; set; }
        public int id_institucion { get; set; }
        public int id_hc { get; set; }


    }
}
