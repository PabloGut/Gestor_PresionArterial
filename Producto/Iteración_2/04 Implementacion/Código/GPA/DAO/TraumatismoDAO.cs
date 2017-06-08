using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;

namespace DAO
{
    public class TraumatismoDAO
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
         * Método para obtener todas las columnas de la tabla Traumatismos.
         * Recibe como parámetro el id_tipoAntecedenteMorbido.
         * Retorna una lista de objetos Traumatismo.
         */
        public static List<Traumatismo> mostrarTraumatismos(int id_tipoAntecedenteMorbido)
        {
            setCadenaConexion();
            List<Traumatismo> traumatismos = new List<Traumatismo>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from Traumatismos where id_tipoAntecedenteMorbido_fk=@id_tipoAntecedenteMorbido";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id_tipoAntecedenteMorbido", id_tipoAntecedenteMorbido);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    traumatismos.Add(new Traumatismo()
                    {
                        id_traumatismo = (int)dr["id_traumatismo"],
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

            return traumatismos;

        }
    }
}
