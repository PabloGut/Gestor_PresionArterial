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
            //cadena = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_4;Integrated Security=True";
            cadena = @"Data Source=DESKTOP-6DMIHKT\SQLEXPRESS;Initial Catalog=SHIART_DB_PRUEBA;Integrated Security=True;Pooling=False";
    
            
            //cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Pablo\Desktop\Pablo\CopiaTrabajo_Proyecto\trunk\Producto\Iteración_2\04 Implementacion\GPA_BD_DePrueba\GPA_BD_4.mdf;Integrated Security=True;Connect Timeout=30";
            //cadena = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\GPA_BD_4.mdf;Integrated Security=True;Connect Timeout=30";
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
