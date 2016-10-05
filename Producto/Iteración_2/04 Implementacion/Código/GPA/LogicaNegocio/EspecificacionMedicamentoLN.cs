using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;
using DAO;

namespace LogicaNegocio
{
    public class EspecificacionMedicamentoLN
    {
        public static void registrarEspecificacionMedicamento(EspecificacionMedicamento especificacionMedicamento)
        {
            EspecificacionMedicamentoDAO.registrarEspecificacionMedicamento(especificacionMedicamento);
        }
        public static DataTable mostrarMedicamentos()
        {
            return EspecificacionMedicamentoDAO.mostrarMedicamentos();
        }
        public static Boolean existeEspecificacion(EspecificacionMedicamento especificacion)
        {
            return EspecificacionMedicamentoDAO.existeEspecificacion(especificacion);
        }
    }
}
