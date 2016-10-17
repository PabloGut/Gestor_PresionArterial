using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Sintoma
    {
        public int id_consulta { set; get; }
        public int id_sintoma { set; get; }
        public DateTime fechaInicioSintoma { set; get; }
        public int cantidadTiempo { set; get; }
        public int id_elementoTiempo { set; get; }
        public int id_descripcionDelTiempo { set; get; }
        public int id_descripcionSintoma { set; get; }
        public int id_tipoSintoma { set; get; }
        public string descripcion { set; get; }
        public int id_parteCuerpo { set; get; }
        public string haciaDondeIrradia { set; get; }
        public int id_modificacionSintoma { set; get; }
        public int id_elementoModificacion { set; get; }
        public int id_caracterDolor { set; get;}
        public string observaciones { set; get; }
        public int id_hc { set; get; }
        public DateTime fechaRegistro { set; get; }



    }
}
