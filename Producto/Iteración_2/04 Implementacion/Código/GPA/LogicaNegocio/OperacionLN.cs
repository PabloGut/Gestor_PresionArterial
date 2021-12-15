using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades.Clases;

namespace LogicaNegocio
{
    public class OperacionLN
    {
        public static List<Operacion> mostrarOperaciones(int id_tipoAntecedenteMorbido)
        {
            return OperacionesDAO.mostrarOperaciones(id_tipoAntecedenteMorbido);
        }
        public static void RegistraOperacion(Operacion operacion)
        {
            OperacionesDAO.RegistrarOperacion(operacion);
        }
        public static void ActualizarOperacion(Operacion operacion)
        {
            OperacionesDAO.ActualizarOperacion(operacion);
        }
    }
}
