using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class PresentacionMedicamentoLN
    {
        public static List<PresentacionMedicamento> mostrarPresentacionesMedicamento()
        {
            return PresentacionMedicamentoDAO.mostrarPresentacionMedicamento();
        }
        public static void registrarPresentacionMedicamento(PresentacionMedicamento presentacion)
        {
            PresentacionMedicamentoDAO.registrarPresentacionMedicamento(presentacion);
        }
    }
}
