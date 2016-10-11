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
        public static Boolean existeUnidadMedidaXMedicamento(int idMedicamento,int idUnidadMedida, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.existeUnidadMedidaXMedicamento(idMedicamento, idUnidadMedida, idNombreComercial);
        }
        public static Boolean existeFormaAdministracionXMedicamento(int idMedicamento, int idFormaAdministracion, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.existeUnidadMedidaXMedicamento(idMedicamento, idFormaAdministracion, idNombreComercial);
        }
        public static Boolean existePresentacionMedicamentoXMedicamento(int idMedicamento, int idPresentacionMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.existeUnidadMedidaXMedicamento(idMedicamento, idPresentacionMedicamento, idNombreComercial);
        }
        public static void actualizarEspecificacion(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoDAO.actualizarEspecificacion(especificacion);
        }
        public static void actualizarUnidadMedidaXMedicamento(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoDAO.actualizarUnidadMedidaPorMedicamento(especificacion);
        }
        public static void actualizarFormaAdministracionXMedicamento(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoDAO.actualizarFormaAdministracionXMedicamento(especificacion);
        }
        public static void actualizarPresentacionMedicamentoXMedicamento(EspecificacionMedicamento especificacion)
        {
            EspecificacionMedicamentoDAO.actualizarPresentacionMedicamentoXMedicamento(especificacion);
        }
        public static void eliminarEspecificacion(int idEspecificacion)
        {
            EspecificacionMedicamentoDAO.eliminarEspecificacion(idEspecificacion);
        }
        public static DataTable mostrarEspecificacionMedicamento(string nombreGenerico)
        {
            return EspecificacionMedicamentoDAO.mostrarEspecificacionMedicamento(nombreGenerico);
        }
        public static List<UnidadDeMedida> mostrarUnidadMedidaParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.mostrarUnidadMedidaParaUnNombreGenericoYComercial(idMedicamento, idNombreComercial);
        }
        public static List<FormaAdministracion> mostrarFormasAdministracionParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.mostrarFormaAdministracionParaUnNombreGenericoYComercial(idMedicamento, idNombreComercial);
        }
        public static List<PresentacionMedicamento> mostrarPresentacionMedicamentoParaUnNombreGenericoYNombreComercial(int idMedicamento, int idNombreComercial)
        {
            return EspecificacionMedicamentoDAO.mostrarPresentacionMedicamentoParaUnNombreGenericoYComercial(idMedicamento, idNombreComercial);
        }
    }
}
