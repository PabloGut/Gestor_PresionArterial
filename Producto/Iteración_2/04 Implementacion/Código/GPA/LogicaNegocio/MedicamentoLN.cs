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
    public class MedicamentoLN
    {
        public static List<Medicamento> mostrarNombreMedicamentos()
        {
            return MedicamentoDAO.mostrarNombreMedicamentos();
        }
        public static void registrarMedicamento(Medicamento medicamento, NombreComercial nombreComercial)
        {
            MedicamentoDAO.registrarMedicamento(medicamento, nombreComercial);
        }
    }
}
