using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;
using System.Runtime.CompilerServices;

namespace LogicaNegocio
{
    public class AntecedenteFamiliarLN
    {
        public static void registrarAntecedentesFamiliares(List<AntecedenteFamiliar> antecedentes, int idHc)
        {
            AntecedenteFamiliarDAO.registrarAntecedentesFamiliares(antecedentes, idHc);
        }
        public static DataTable MostrarAntecedentesFamiliares(int idHc)
        {
            return AntecedenteFamiliarDAO.MostrarAntecedentesFamiliares(idHc);
        }
    }
}
