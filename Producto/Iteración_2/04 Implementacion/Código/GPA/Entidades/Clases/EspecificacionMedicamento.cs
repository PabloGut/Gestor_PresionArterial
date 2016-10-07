using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EspecificacionMedicamento
    {
        public int id_especificacion { set; get; }
        public int id_medicamento_fk { set; get; }
        public int concentracion { set; get; }
        public int id_unidadMedida_fk { set; get; }
        public int id_formaAdministracion { set; get; }
        public int id_presentacionMedicamento { set; get; }
        public int id_nombreComercial { set; get; }
        public int cantidadComprimidos { set; get; }

    }
}
