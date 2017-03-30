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
    public class ManejadorRegistrarAntecedentesMorbidos
    {
        public List<TipoAntecedenteMorbido> mostrarTiposAntecedentesMorbidos()
        {
            return TipoAntecedenteMorbidoLN.mostrarTiposAntecedentesMorbidos();
        }
        public List<Enfermedad> mostrarEnfermedades(int id_tipoAntecedenteMorbido)
        {
            return EnfermedadLN.mostrarEnfermedades(id_tipoAntecedenteMorbido);
        }
        public List<Operacion> mostrarOperaciones(int id_tipoAntecedenteMorbido)
        {
            return OperacionLN.mostrarOperaciones(id_tipoAntecedenteMorbido);
        }
        public List<Traumatismo> mostrarTraumatismos(int id_tipoAntecedenteMorbido)
        {
            return TraumatismoLN.mostrarTraumatismos(id_tipoAntecedenteMorbido);
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public void registrarAntecedentesMorbidos(List<AntecedenteMorbido> antecedentes, int idHc)
        {
            AntecedenteMorbidoLN.registrarAntecedentesMorbidos(antecedentes, idHc);
        }
    }
}
