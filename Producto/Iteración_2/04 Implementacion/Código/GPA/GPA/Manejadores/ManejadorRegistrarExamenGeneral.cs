using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using System.Data;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarExamenGeneral
    {
        public List<Ubicacion> mostrarUbicaciones()
        {
            return UbicacionLN.mostrarUbicaciones();
        }
        public List<Tamaño> mostrarTamañoGanglio()
        {
            return TamañoLN.mostrarTamañosGanglios();
        }
    }
}
