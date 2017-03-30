using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarEnfermedadActual
    {
        public List<ParteDelCuerpo> mostrarPartesDelCuerpoHumano()
        {
            return ParteDelCuerpoDAO.mostrarPartesDelCuerpoHumano();
        }
        public List<TipoSintoma> mostrarTiposSintomas()
        {
            return TipoSintomaLN.mostrarTiposSintomas();
        }
        public List<CaracterDelDolor> mostrarCaracterDelDolor()
        {
            return CaracterDelDolorLN.mostrarCaracterDelDolor();
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public List<DescripcionDelTiempo> mostrarDescripcionesDelTiempo()
        {
            return DescripcionDelTiempoLN.mostrarDescripcionesDelTiempo();
        }
        public List<ModificacionSintoma> mostrarModificacionesDelSintoma()
        {
            return ModificacionSintomaLN.mostrarModificacionesDelSintoma();
        }
        public List<ElementoDeModificacion> mostrarElementosDeModificacion()
        {
            return ElementoDeModificacionLN.mostrarElementosDeModificacion();
        }
        public void registrarSintomas(List<Sintoma> sintomas, int idHc)
        {
            SintomaLN.registrarSintomas(sintomas, idHc);
        }
    }
}
