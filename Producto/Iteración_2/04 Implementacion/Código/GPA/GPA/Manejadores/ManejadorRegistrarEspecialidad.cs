using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using System.Data;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarEspecialidad
    {
        private RegistrarEspecialidad pantalla;
        private List<Especialidad> especialidades;

        public void registrarEspecialidad(RegistrarEspecialidad pantallaRe)
        {
            pantalla=pantallaRe;
            mostrarEspecialidades();
        }

        public void mostrarEspecialidades()
        {
            especialidades = EspecialidadDAO.buscarEspecialidades();
            pantalla.presentarEspecialidades(especialidades);
        }

        public void nombreYDescripcionIngresados(int id, string nombre, string descripcion)
        {
            if (id == 0)
            {
                crearEspecialidad(nombre, descripcion);
            }
            else
            {
                modificarEspecialidad(id, nombre, descripcion);
            }
        }

        public void crearEspecialidad(string nombre, string descripcion)
        {
            EspecialidadDAO.insertarEspecialidad(nombre, descripcion);
            finCU("Especialidad agregada correctamente");
        }

        public void modificarEspecialidad(int id, string nombre, string descripcion)
        {
            EspecialidadDAO.actualizarEspecialidad(id, nombre, descripcion);
            finCU("Especialidad modificada correctamente");
        }

        public void borrarEspecialidad(int id)
        {
            EspecialidadDAO.eliminarEspecialidad(id);
            finCU("Especialidad borrada correctamente");
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }
}
