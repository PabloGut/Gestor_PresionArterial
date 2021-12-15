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
    public class MedicamentoAlergiaLN
    {
        public static List<MedicamentoAlergia> mostrarMedicamentosQueProducenAlergia()
        {
            return MedicamentoAlergiaDAO.mostrarMedicamentosQueProducenAlergia();
        }
        public static void RegistrarMedicamentoAlergia(MedicamentoAlergia Medicamento)
        {
            try
            {
                MedicamentoAlergiaDAO.RegistrarMedicamentoAlergia(Medicamento);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static void ActualizarMedicamentoAlergia(MedicamentoAlergia Medicamento)
        {
            try
            {
                MedicamentoAlergiaDAO.ActualizarSustanciaContactoPielAlergia(Medicamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
