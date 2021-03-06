﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using LogicaNegocio;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarPaciente
    {
        private RegistrarPaciente pantalla;
        private List<Localidad> localidades;
        private List<Barrio> barrios;

        public void registrarPaciente(RegistrarPaciente rp)
        {
            pantalla = rp;
            mostrarTiposDocumento();
        }

        public void mostrarTiposDocumento()
        {
            pantalla.presentarTiposDocumento(TipoDocumentoLN.mostrarTipoDocumento());
        }

        public void documentoIngresado(int id_tipoDoc, int nro_documento)
        {
            verificarExistenciaPaciente(id_tipoDoc, nro_documento);
        }

        public void verificarExistenciaPaciente(int id_tipoDoc, int nro_documento)
        {
            List<Paciente> pacientes=PacienteLN.buscarPaciente(id_tipoDoc, nro_documento);
            if (pacientes.Count != 0)
            {
                Paciente paciente=pacientes.ElementAt(0);
                finCU("El paciente ya existe.\nNombre: " + paciente.nombre + "\nApellido: " + paciente.apellido);
            }
            else
            {
                pantalla.pedirDatos();
            }
        }

        public void datosPaciente()
        {
            mostrarLocalidades();
        }

        public void mostrarLocalidades()
        {
            localidades = LocalidadLN.buscarLocalidades();
            pantalla.presentarLocalidades(localidades);
        }

        public void localidadSeleccionada(Localidad localidad)
        {
            mostrarBarriosDeLocalidad(localidad);
        }

        public void mostrarBarriosDeLocalidad(Localidad localidad)
        {
            barrios = BarrioLN.buscarBarriosDeLocalidad(localidad.id_localidad);
            pantalla.presentarBarrios(barrios);
        }

        public void altaPacienteConfirmada(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, int id_sexo, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, DateTime fecha_nacimiento, int edad, double altura, int peso, ProfesionaMedico medico)
        {
            Usuario usuario=generarUsuarioYPassword(nombre, apellido);
            pantalla.presentarUsuario(usuario.nombre,usuario.pass);
            crearPaciente(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, id_sexo, calle, numero, piso, departamento, codigo_postal, id_barrio, fecha_nacimiento, edad, altura, peso, medico, usuario);
        }

        public void crearPaciente(int id_tipoDoc, int nro_documento, string nombre, string apellido, int telefono, int nroCelular, string email, int id_sexo, string calle, int numero, int piso, string departamento, int codigo_postal, int id_barrio, DateTime fecha_nacimiento, int edad, double altura, int peso, ProfesionaMedico medico, Usuario usuario)
        {
            int id_estado=buscarEstadoDeAlta();
            PacienteLN.insertarPaciente(id_tipoDoc, nro_documento, nombre, apellido, telefono, nroCelular, email, id_sexo, calle, numero, piso, departamento, codigo_postal, id_barrio, fecha_nacimiento, edad, altura, peso, medico, usuario.nombre, usuario.pass, usuario.fechaCreacion, id_estado);
            finCU("El paciente ha sido registrado exitosamente");
        }

        public int buscarEstadoDeAlta()
        {
            return EstadoLN.buscarEstadoPorNombre("Activo").id_estado;
        }

        public Usuario generarUsuarioYPassword(string nombre, string apellido)
        {
            Usuario usuario = new Usuario();
            usuario.nombre = nombre.ToLower().Substring(0,1) + apellido.ToLower();
            usuario.pass = Utilidades.stringAleatorio().Substring(0,8);
            usuario.fechaCreacion = DateTime.Today;
            int numeroUsuario = verificarExistenciaUsuario(usuario.nombre); //Buscar usuarios con el mismo nombre, luego recorrer la lista (si Count da >0) guardando el número más alto y al final concatenarlo al nombre de usuario.
            usuario.nombre += numeroUsuario;
            return usuario;
        }

        public int verificarExistenciaUsuario(string nombre){

            List<Usuario> usuarios = UsuarioLN.buscarUsuarioPorNombre(nombre + "[1-9]%");
            int numeroUsuario=0;
            foreach (Usuario usuario in usuarios)
            {
                numeroUsuario=usuario.existeMayorNumeroUsuario(numeroUsuario);
            }
            return numeroUsuario+1;
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }
}
