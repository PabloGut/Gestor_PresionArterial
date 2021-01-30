using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;
using DAO;
namespace GPA.Manejadores
{
    public class ManejadorRegistrarAtencionMedicaEnConsultorio
    {
        private MenuPrincipal pantalla;

        public void registrarAtencionMedicaEnConsultorio(MenuPrincipal mp)
        {
            pantalla = mp;
        }

        public void registrarSintomas(List<Sintoma> sintomas, int idConsulta)
        {
            SintomaLN.registrarSintomasDeConsulta(sintomas, idConsulta);
        }
        public string mostrarFechaActual()
        {
            return ConsultaLN.mostrarFechaActual();
        }
        public string mostrarHoraActual()
        {
            return ConsultaLN.mostrarHoraActual();
        }
        public int calcularNroConsulta(int idHc)
        {
            return ConsultaLN.calcularSiguinteNroConsulta(idHc);
        }
        public int existeHc(int tipoDoc, long nroDoc)
        {
            return PacienteDAO.buscarIdHC(tipoDoc, nroDoc);
        }
        public void registrarConsultaYExamenGeneral(Consulta consulta)
        {
            try
            {
                ConsultaLN.registrarConsultaYExamenGeneral(consulta);
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }
        public void registrarConsultaYExamenGeneral(Consulta consulta,List<EvolucionDiagnostico> lista)
        {
            try
            {
                ConsultaLN.registrarConsultaYExamenGeneral(consulta, lista);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        /*
         * Crear un objeto consulta.
         * Retorna un objeto consulta.
         */
        public Consulta crearObjetoConsulta(int nroConsulta, DateTime fecha, DateTime hora, string motivoConsulta, int hc)
        {
            Consulta consulta = new Consulta();
            consulta.nroConsulta = nroConsulta;
            consulta.fecha = fecha;
            consulta.hora = hora;
            consulta.motivoConsulta = motivoConsulta;
            consulta.id_hc = hc;

            return consulta;
        }
        public Consulta crearObjetoConsulta(int nroConsulta, DateTime fecha, DateTime hora, string motivoConsulta, int hc, List<Sintoma> sintomas)
        {
            Consulta consulta = new Consulta();
            consulta.nroConsulta = nroConsulta;
            consulta.fecha = fecha;
            consulta.hora = hora;
            consulta.motivoConsulta = motivoConsulta;
            consulta.id_hc = hc;
            consulta.sintoma = sintomas;
            return consulta;
        }
    }
}
