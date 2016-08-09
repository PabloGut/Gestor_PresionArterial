using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string pass { get; set; }
        public DateTime fechaCreacion { get; set; }

        public int existeMayorNumeroUsuario(int numeroUsuario)
        {
            if (Convert.ToInt32((nombre.Substring(nombre.Length))) > numeroUsuario)
            {
                return Convert.ToInt32((nombre.Substring(nombre.Length)));
            }
            else
            {
                return numeroUsuario;
            }
        }
    }
}
