using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarProfesionalMedico
    {
        private RegistrarProfesionalMedico pantalla;
        private List<Localidad> localidades;
        private List<Barrio> barrios;
        private List<Especialidad> especialidades;

        public void registrarProfesionalMedico(RegistrarProfesionalMedico rpm)
        {
            pantalla = rpm;
            mostrarTiposDocumento();
        }

        public void mostrarTiposDocumento()
        {
            pantalla.presentarTiposDocumento(TipoDocumentoDAO.buscarTiposDoc());
        }

        public void documentoIngresado(int id_tipoDoc, int nro_documento)
        {
            verificarExistenciaProfesionalMedico(id_tipoDoc, nro_documento);
        }

        public void verificarExistenciaProfesionalMedico(int id_tipoDoc, int nro_documento)
        {
            ProfesionaMedico profesional = ProfesionalMedicoDAO.buscarProfesionalMedicoPorTipoNroDocumento(id_tipoDoc, nro_documento);
            if (profesional != null)
            {
                finCU("El profesional médico ya existe.\nNombre: " + profesional.nombre + "\nApellido: " + profesional.apellido);
            }
            else
            {
                pantalla.pedirDatos();
            }
        }

        public void datosProfesionalMedico()
        {
            mostrarLocalidades();
        }

        public void mostrarLocalidades()
        {
            localidades = LocalidadDAO.buscarLocalidades();
            pantalla.presentarLocalidades(localidades);
        }

        public void localidadSeleccionada(Localidad localidad)
        {
            mostrarBarriosDeLocalidad(localidad);
        }

        public void mostrarBarriosDeLocalidad(Localidad localidad)
        {
            barrios = BarrioDAO.buscarBarriosDeLocalidad(localidad.id_localidad);
            pantalla.presentarBarrios(barrios);
        }

        public void barrioSeleccionado()
        {
            mostrarEspecialidades();
        }

        public void mostrarEspecialidades()
        {
            especialidades = EspecialidadDAO.buscarEspecialidades();
            pantalla.presentarEspecialidades(especialidades);
        }

        public void altaProfesionalMedicoConfirmada(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int id_especialidad, int matricula)
        {
            Usuario usuario = generarUsuarioYPassword(nombre, apellido);
            pantalla.presentarUsuario(usuario.nombre, usuario.pass);
            crearProfesionalMedico(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, calle, numero, piso, departamento, codigo_postal, id_barrio, id_especialidad, matricula, usuario);
        }

        public void crearProfesionalMedico(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, int id_especialidad, int matricula, Usuario usuario)
        {
            int id_estado = buscarEstadoDeAlta();
            ProfesionalMedicoDAO.insertarProfesionalMédico(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, calle, numero, piso, departamento, codigo_postal, id_barrio, id_especialidad, matricula, usuario.nombre, usuario.pass, usuario.fechaCreacion, id_estado);
            finCU("El profesional médico ha sido registrado exitosamente");
        }

        public int buscarEstadoDeAlta()
        {
            return EstadoDAO.buscarEstadoPorNombre("Activo").id_estado;
        }

        public Usuario generarUsuarioYPassword(string nombre, string apellido)
        {
            Usuario usuario = new Usuario();
            usuario.nombre = nombre.ToLower().Substring(0, 1) + apellido.ToLower();
            usuario.pass = Utilidades.stringAleatorio().Substring(0, 8);
            usuario.fechaCreacion = DateTime.Today;
            int numeroUsuario = verificarExistenciaUsuario(usuario.nombre); //Buscar usuarios con el mismo nombre, luego recorrer la lista (si Count da >0) guardando el número más alto y al final concatenarlo al nombre de usuario.
            usuario.nombre += numeroUsuario;
            return usuario;
        }

        public int verificarExistenciaUsuario(string nombre)
        {
            List<Usuario> usuarios = UsuarioDAO.buscarUsuarioPorNombre(nombre + "[1-9]%");
            int numeroUsuario = 0;
            foreach (Usuario usuario in usuarios)
            {
                numeroUsuario = usuario.existeMayorNumeroUsuario(numeroUsuario);
            }
            return numeroUsuario + 1;
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }
}
