using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class TipoPracticaComplementariaDAO
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
       * Método para obtener los nombres de prácticas complementarias.
       * No recibe parámetros.
       * Retorna una lista de objetos TipoPracticaComplementaria.
       */
        public static List<TipoPracticaComplementaria> MostrarPracticasComplementarias()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<TipoPracticaComplementaria> practicasComplementarias = new List<TipoPracticaComplementaria>();
            try
            {
                cn.Open();

                string consulta = "select id_tipoPractica, nombre from TipoPracticaComplementaria";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    practicasComplementarias.Add(new TipoPracticaComplementaria()
                    {
                        id_tipoPracticaComplementaria = (int)dr["id_tipoPractica"],
                        nombre = dr["nombre"].ToString()
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
            return practicasComplementarias;
        }
        public static int mostrarPracticaComplementaria(string nombre)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            int idTipoPractica = 0;
            try
            {
                cn.Open();

                string consulta = "select id_tipoPractica from TipoPracticaComplementaria where nombre like @nombre";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", nombre);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    idTipoPractica = (int)dr["id_tipoPractica"];
                }

                cn.Close();
                return idTipoPractica;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    
    }
}
