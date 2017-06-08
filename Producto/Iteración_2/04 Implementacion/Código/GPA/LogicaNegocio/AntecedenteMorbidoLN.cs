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
    public class AntecedenteMorbidoLN
    {
        public static void registrarAntecedentesMorbidos(List<AntecedenteMorbido> antecedentes, int idHc)
        {
            AntecedenteMorbidoDAO.registrarAntecedenteMorbido(antecedentes, idHc);
        }
        public static DataTable mostrarAntecedentesMorbidosEnfermedades(int idHc)
        {
            return AntecedenteMorbidoDAO.mostrarAntecedentesMorbidosEnfermedadesDeHc(idHc);
        }
        public static DataTable mostrarAntecedentesMorbidosOperaciones(int idHc)
        {
            return AntecedenteMorbidoDAO.mostrarAntecedentesMorbidosOperacionesDeHc(idHc);
        }
        public static DataTable mostrarAntecedentesMorbidosTraumatismos(int idHc)
        {
            return AntecedenteMorbidoDAO.mostrarAntecedentesMorbidosTraumatismosDeHc(idHc);
        }
    }
}
