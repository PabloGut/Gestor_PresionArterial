using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Medicamento
    {
        public int id_medicamento { set; get; }
        public string nombreGenerico { set; get; }
        public int concentracion { set; get; }
        public int id_unidadMedida { set; get; }
        public int id_formaAdministración { set; get; }
        public int id_presentacion { set; get; }
        public int id_nombreComercial { set; get; }
        public int cantidadComprimidos { set; get; }
    }
}
