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
    public class NombreComercialDAO
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
       * Método para registrar el nombre comercial de un medicamento.
       * Recibe como parámetro un objeto nombreComercial, un SqlConnection y un SqlTransaction.
       * Valor de retorno void.
       */
        public static void registrarNombreComercialDeMedicamento(NombreComercial nombreComercial,SqlConnection cn,SqlTransaction tran)
        {
          
            try
            {
                string consulta = @"insert into NombreComercial(nombre,id_medicamento_fk)
                                    values(@nombre,@id_medicamento_fk)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", nombreComercial.nombre);
                cmd.Parameters.AddWithValue("@id_medicamento_fk", nombreComercial.id_medicamento_fk);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

               
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
