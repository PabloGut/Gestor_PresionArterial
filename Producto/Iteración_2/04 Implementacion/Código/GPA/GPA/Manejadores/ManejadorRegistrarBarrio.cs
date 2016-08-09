using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;


namespace GPA.Manejadores
{
    public class ManejadorRegistrarBarrio
    {
        private RegistrarBarrio pantalla;
        private List<Barrio> barrios;
        private List<Localidad> localidades;

        public void registrarBarrio(RegistrarBarrio pantallaRb)
        {
            pantalla = pantallaRb;
            mostrarLocalidades();
        }

        public void mostrarLocalidades()
        {
            localidades = LocalidadDAO.buscarLocalidades();
            pantalla.presentarLocalidades(localidades);
        }

        public void localidadSeleccionada(Localidad localidad)
        {
            mostrarBarrios(localidad);
        }

        public void mostrarBarrios(Localidad localidad)
        {
            barrios=BarrioDAO.buscarBarriosDeLocalidad(localidad.id_localidad);
            pantalla.presentarBarrios(barrios);
        }

        public void nombreYDescripcionIngresados(int id, int id_localidad, string nombre, string descripcion)
        {
            if (id == 0)
            {
                crearBarrio(id_localidad, nombre, descripcion);
            }
            else
            {
                modificarLocalidad(id, nombre, descripcion);
            }
        }

        public void crearBarrio(int id_localidad, string nombre, string descripcion)
        {
            BarrioDAO.insertarBarrio(id_localidad, nombre, descripcion);
            finCU("Barrio agregado correctamente");
        }

        public void modificarLocalidad(int id, string nombre, string descripcion)
        {
            BarrioDAO.actualizarBarrio(id, nombre, descripcion);
            finCU("Barrio modificado correctamente");
        }

        public void borrarBarrio(int id)
        {
            BarrioDAO.eliminarBarrio(id);
            finCU("Barrio borrado correctamente");
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }
}
