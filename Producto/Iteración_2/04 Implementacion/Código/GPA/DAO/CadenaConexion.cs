using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CadenaConexion
    {
        private string cadena;
        private static CadenaConexion refCadena=null;

        private CadenaConexion()
        {
            cadena = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
            //"Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
            //@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Repositorio\trunk\Producto\04 Implementación\GPA_BD_DePrueba\GPA_BD_2.mdf;Integrated Security=True;Connect Timeout=30";
        }
        public static CadenaConexion getInstancia()
        {
            if (refCadena == null)
            {
                refCadena = new CadenaConexion();
            }
            return refCadena;
        }
        public string getCadena()
        {
            return cadena;
        }
    }
}
