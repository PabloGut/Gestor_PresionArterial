using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Estudio
    {
        private string nombre { get; set; }
        private DateTime fecha { get; set; }
        private String doctorACargo { get; set; }
        private String informeEstudio { get; set; }
        private Institucion institucion { get; set; }


    }
}
