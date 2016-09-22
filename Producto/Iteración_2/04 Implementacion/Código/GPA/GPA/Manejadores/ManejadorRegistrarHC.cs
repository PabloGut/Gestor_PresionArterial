using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarHC
    {
        public void buscarProfesionaMedico(ProfesionaMedico pm)
        {
             ProfesionalMedicoDAO.buscarMedicoLogueado(pm);
        }
        public void asignarHCAPaciente(int tipoDoc, long nroDoc,int idhc)
        {
            PacienteDAO.AsignarHCPaciente(tipoDoc, nroDoc,idhc);
        }
        /*
         * Método para mostrar la fecha actual.
         * Llama al metodo mostrarFechaActual() de la capa lógica de negocio.
         * No recibe parámetros.
         * Retorna un string.
         */
        public string mostrarFechaActual()
        {
            return HistoriaClinicaLN.mostrarFechaActual();
        }
        /*
         * Método para mostrar la hora actual.
         * Llama al metodo mostrarHoraActual() de la capa lógica de negocio.
         * No recibe parámetros.
         * Retorna un string.
         */
        public string mostrarHoraActual()
        {
            return HistoriaClinicaLN.mostrarHoraActual();
        }
        public Boolean existeHC(int tipoDoc, long nroDoc)
        {
            return PacienteLN.existeHC(tipoDoc, nroDoc);
        }
        public List<ElementoDelTiempo> mostrarElementosDelTiempo()
        {
            return ElementoDelTiempoLN.mostrarElementosDelTiempo();
        }
        public List<DescripcionDelTiempo> mostrarDescripcionesDelTiempo()
        {
            return DescripcionDelTiempoLN.mostrarDescripcionesDelTiempo();
        }
        public List<ModificacionSintoma> mostrarModificacionesDelSintoma()
        {
            return ModificacionSintomaLN.mostrarModificacionesDelSintoma();
        }
        public List<ElementoDeModificacion> mostrarElementosDeModificacion()
        {
            return ElementoDeModificacionLN.mostrarElementosDeModificacion();
        }

    }
}
