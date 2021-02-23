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
    public class ConsultaLN
    {
        public static int calcularSiguinteNroConsulta(int idHc)
        {
            int ultimoNro = buscarNroConsulta(idHc);

            int siguienteNroConsulta = ultimoNro + 1;

            return siguienteNroConsulta;
        }
        public static int buscarNroConsulta(int idHc)
        {
            return ConsultaDAO.buscarNroConsulta(idHc);
        }
        public static void registrarConsulta(Consulta consulta)
        {
            ConsultaDAO.registrarConsulta(consulta);
        }
        public static string mostrarFechaActual()
        {
            return DateTime.Now.ToShortDateString();
        }
        public static string mostrarHoraActual()
        {
            return DateTime.Now.ToShortTimeString();
        }
        public static void registrarConsultaYExamenGeneral(Consulta consulta)
        {
            try
            {
                ConsultaDAO.registrarConsultaYExameGeneral(consulta);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void registrarConsultaYExamenGeneral(Consulta consulta,List<EvolucionDiagnostico> lista)
        {
            try
            {
                ConsultaDAO.registrarConsultaYExameGeneralDiagnosticoExistente(consulta, lista);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static DataTable mostrarConsultasAnteriores(int idHc)
        {
            return ConsultaDAO.mostrarConsultasAnteriores(idHc);
        }
        public static Consulta obtenerConsultaIdConsulta(int idConsulta)
        {
            try
            {
                return ConsultaDAO.obtenerConsulta(idConsulta);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
