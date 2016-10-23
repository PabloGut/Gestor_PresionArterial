using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using System.Data.SqlClient;

namespace DAO
{
    public class AlergiaInsectoDAO
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
        * Método para registrar las alergias a los insectos.
        * Recibe como parámetros una lista de objetos AlergiaInsecto y el id de la historia clínica.
        * El valor de retorno es void.
        */
        public static void registrarAlergiaInsecto(List<AlergiaInsecto> alergiaInsecto, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.Open();

                string consulta = @"insert into AlergiaInsecto(fechaRegistro,id_insecto_fk, efectos, id_hc_fk)
                                  values(@fechaRegistro,@idInsecto,@efectos,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AlergiaInsecto alergia in alergiaInsecto)
                {
                    cmd.Parameters.AddWithValue("@fechaRegistro", alergia.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idInsecto", alergia.id_insecto);
                    cmd.Parameters.AddWithValue("@efectos", alergia.efectos);
                    cmd.Parameters.AddWithValue("@idHc", alergia.id_hc);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
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
