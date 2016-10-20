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
    }
}
