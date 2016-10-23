using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class AlergiaMedicamentoLN
    {
        public static void registrarAlergiaMedicamentos(List<AlergiaMedicamento> alergiasMedicamentos, int idHc)
        {
            AlergiaMedicamentoDAO.registrarAlergiaMedicamento(alergiasMedicamentos, idHc);
        }
    }
}
