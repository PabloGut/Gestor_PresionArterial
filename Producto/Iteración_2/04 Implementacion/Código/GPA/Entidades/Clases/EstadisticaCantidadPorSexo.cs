using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class EstadisticaCantidadPorSexo
    {
        
        public int Id { get; set; }
        public DateTime fechaRegistro { get; set; }
        public int idSexo { get; set; }
        public String sexo { get; set; }
        public int CantidadPacientes { get; set; }

        public int totalPacientes { get; set; }

        public double porcentajePorSexo { get; set; }
    }
}
