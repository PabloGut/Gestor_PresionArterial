using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades.Clases;
namespace LogicaNegocio
{
    public class UsuarioLN
    {
        public static List<Usuario> buscarContraseñaUsuario(string nombre)
        {
            return UsuarioDAO.buscarContraseñaUsuario(nombre);
        }
        /*
        * Método para que buscar un usuario.
        * Toma como parámetros el nombre y la contraseña del usuario.
        * Llama al método buscarUsuario de la capa de datos.
        * Retorna el usuario correspondiente.
        * */
        public static List<Usuario> buscarUsuario(string nombre, string pass)
        {
            return UsuarioDAO.buscarUsuario(nombre, pass);
        }
        public static List<Usuario> buscarUsuarioPorNombre(string nombre)
        {
            return UsuarioDAO.buscarUsuarioPorNombre(nombre);
        }
        public static int buscarUnUsuario(string nombre, string pass)
        {
            return UsuarioDAO.buscarUnUsuario(nombre, pass);
        }
    }
}
