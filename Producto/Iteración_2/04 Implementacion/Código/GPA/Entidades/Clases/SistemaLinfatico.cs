using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class SistemaLinfatico
    {
        public int id_sistemaLinfatico { set; get; }
        public int id_ubicacion { set; get; }
        public int id_tamaño { set; get; }
        public int aproximacionNumerica { set; get; }
        public int id_consistencia { set; get; }
        public int id_examenGeneral { set; get; }
        public string descripcion { set; get; }
        public string sensiblePalpacion { set; get; }
        public string sePalpaConLimitesPrecisos { set; get; }
        public string tiendeAConfluir { set; get; }
        public string sePuedeMovilizarConDedos { set; get; }
        public string adheridaPlanosProfundos { set; get; }
        public string procesoInflamatorioComprometeLaPiel { set; get; }
        public string lesion { set; get; }
        public string observaciones { set; get; }

    }
}
