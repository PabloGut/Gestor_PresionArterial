using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;
using LogicaNegocio;
using System.Data;

namespace GPA
{
    public class ManejadorInicioSesion
    {
        private UsuarioLN usuarioln;
        public ManejadorInicioSesion()
        {
            usuarioln = new UsuarioLN();
        }
        /*
         * Método para que buscar un usuario.
         * Toma como parámetros el nombre y la contraseña del usuario.
         * Llama al método buscarUsuario de la capa lógica de negocio.
         * Retorna el usuario correspondiente.
         * */
        public List<Usuario> buscarUsuario(string nombre, string pass)
        {
            return UsuarioLN.buscarUsuario(nombre, pass);
            
        }
        public ProfesionaMedico buscarMedicoDelUsuario(int id_usuario)
        {
            if (string.IsNullOrEmpty(ProfesionalMedicoDAO.getCadenaConexion()))
            {
                ProfesionalMedicoDAO.setCadenaConexion();
            }
            return ProfesionalMedicoDAO.buscarMedicoDeUsuario(id_usuario);

        }
       

    }
}
