using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EstadisticaCategoriaSitio
    {
        public int id { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Categoria { get; set; }
        public double CantidadPacientes { get; set; }
        public int TotalPacientes { get; set; }

        public string SitioMedicion { get; set; }
        public string Extremidad { get; set; }
        public double PromedioSistolica { get; set; }
        public double PromedioDiastolica { get; set; }
        public string ConExamen { get; set; }
    }
}
