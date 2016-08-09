using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace GPA.Manejadores
{
    public class ManejadorRegistrarLocalidad
    {
        private RegistrarLocalidad pantalla;
        private List<Localidad> localidades;

        public void registrarLocalidad(RegistrarLocalidad pantallaRl)
        {
            pantalla = pantallaRl;
            mostrarLocalidades();
        }

        public void mostrarLocalidades()
        {
            localidades = LocalidadDAO.buscarLocalidades();
            pantalla.presentarLocalidades(localidades);
        }

        public void nombreIngresado(int id, string nombre)
        {
            if (id == 0)
            {
                crearLocalidad(nombre);
            }
            else
            {
                modificarLocalidad(id, nombre);
            }
        }

        public void crearLocalidad(string nombre)
        {
            LocalidadDAO.insertarLocalidad(nombre);
            finCU("Localidad agregada correctamente");
        }

        public void modificarLocalidad(int id, string nombre)
        {
            LocalidadDAO.actualizarLocalidad(id, nombre);
            finCU("Localidad modificada correctamente");
        }

        public void borrarLocalidad(int id)
        {
            LocalidadDAO.eliminarLocalidad(id);
            finCU("Localidad borrada correctamente");
        }

        public void finCU(string mensaje)
        {
            pantalla.informarUsuarioFinCU(mensaje);
        }
    }
}
