using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace LogicaNegocio
{
    public class ClasificacionPresionArterialLN
    {
        public static List<ClasificacionPresionArterial> mostrarClasificacionesDePresionArterial()
        {
            return ClasificacionPresionArterialDAO.mostrarClasificacionesDePresionArterial();
        }

        public static bool esClasificacionPresionArterial(int valorMinimo, int valorMaximo, ClasificacionPresionArterial clasificacion)
        {
            if (valorMinimo >= clasificacion.minimaDesde && valorMinimo <= clasificacion.minimaHasta && valorMaximo >= clasificacion.maximaDesde && valorMaximo <= clasificacion.maximaHasta)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
