using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using DAO;

namespace GPA
{
    public class ManejadorInicioSesion
    {
        public List<Usuario> buscarUsuario(string nombre, string pass)
        {
            return UsuarioDAO.buscarUsuario(nombre, pass);
        }
        public ProfesionaMedico buscarMedicoDelUsuario(int id_usuario)
        {
            return ProfesionalMedicoDAO.buscarMedicoDeUsuario(id_usuario);

        }
       

    }
}
