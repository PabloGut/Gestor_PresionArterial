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

                SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);

                nombreComercial.id_nombreComercial = Convert.ToInt32(cmd1.ExecuteScalar());

               
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
        /*
     * Método para registrar el nombre comercial de un medicamento.
     * Recibe como parámetro un objeto nombreComercial.
     * Valor de retorno void.
     */
        public static void registrarNombreComercialDeMedicamento(NombreComercial nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                string consulta = @"insert into NombreComercial(nombre,id_medicamento_fk)
                                    values(@nombre,@id_medicamento_fk)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", nombreComercial.nombre);
                cmd.Parameters.AddWithValue("@id_medicamento_fk", nombreComercial.id_medicamento_fk);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn);
                nombreComercial.id_nombreComercial = Convert.ToInt32(cmd1.ExecuteScalar());

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
        /*
      * Método para verificar si existe el nombre comercial que se pasa por parámetro.
      * Recibe como parámetro una cadena de caracteres que corresponde al nombre comercial.
      * Valor de retorno Boolean.
      */
        public static Boolean existeNombreComercial(string nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existeNombre = false;
            try
            {
                cn.Open();

                string consulta = "select * from NombreComercial where nombre like @nombreComercial";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreComercial", nombreComercial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        existeNombre = true;
                    }
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
            return existeNombre;
        }
        /*
    * Método para obtener el id de un Nombrecomercial que se pasa por parámetro.
    * Recibe como parámetro una cadena de caracteres que corresponde al nombre comercial.
    * Valor de retorno int.
    */
        public static int idNombreComercial(string nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            int idNombreComercial = 0;
            try
            {
                cn.Open();

                string consulta = "select id_nombreComercial from NombreComercial where nombre like @nombreComercial";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreComercial", nombreComercial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        idNombreComercial= (int) dr["id_nombreComercial"];
                    }
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
            return idNombreComercial;
        }
        /*
        * Método para obtener los nombres comerciales de un medicamento.
        * Recibe como parámetro el id del medicamento.
        * Valor de retorno lista de objetos NombreComercial.
        */
        public static List<NombreComercial> mostrarNombresComercialesDeMedicamento(int idMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<NombreComercial> nombresComerciales = new List<NombreComercial>();
            try
            {
                cn.Open();

                string consulta = @"select nc.nombre,nc.id_nombreComercial, m.nombreGenerico
                                  from Medicamento m, NombreComercial nc
                                  where m.id_medicamento= nc.id_medicamento_fk
                                  and m.id_medicamento=@idMedicamento";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nombresComerciales.Add(new NombreComercial()
                                             {
                                                 id_nombreComercial=(int)dr["id_nombreComercial"],
                                                 nombre=dr["nombre"].ToString(),

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
            return nombresComerciales;
        }
    }
}
