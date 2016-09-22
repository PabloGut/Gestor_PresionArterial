using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades.Clases;
namespace DAO
{
    public class ElementoDeModificacionDAO
    {
         private static string cadenaConexion;

        public static void setCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string getCadenaConexion()
        {
            return cadenaConexion;
        }
        /*
       * Método para mostrar todos los atributos de los elementos que modifican los sintomas.
       * No recibe valores como parámetros.
       * Retorna una lista de objetos ElementosDeModificacion.
       */
        public static List<ElementoDeModificacion> mostrarElementosDeModificacionesDelSintoma()
        {
            setCadenaConexion();
            List<ElementoDeModificacion> elementosDeModificacion = new List<ElementoDeModificacion>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from ElementoDeModificacion";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    elementosDeModificacion.Add(new ElementoDeModificacion()
                    {
                        id_elementoDeModificacion = (int)dr["id_elementoDeModificacion"],
                        nombre = dr["nombre"].ToString(),
                    });
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            return elementosDeModificacion;

        }
    }
    
}
