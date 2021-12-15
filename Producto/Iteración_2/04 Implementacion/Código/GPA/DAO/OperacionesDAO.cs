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
    public class OperacionesDAO
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
        * Método para obtener todas las columnas de la tabla Operaciones.
        * Recibe como parámetro el id_tipoAntecedenteMorbido.
        * Retorna una lista de objetos Operaciones.
        */
        public static List<Operacion> mostrarOperaciones(int id_tipoAntecedenteMorbido)
        {
            setCadenaConexion();
            List<Operacion> operaciones = new List<Operacion>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from Operaciones where id_tipoAntecedenteMorbido_fk=@id_tipoAntecedenteMorbido";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id_tipoAntecedenteMorbido", id_tipoAntecedenteMorbido);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    operaciones.Add(new Operacion()
                    {
                        id_operacion = (int)dr["id_operacion"],
                        nombre = dr["nombre"].ToString(),
                        id_tipoAntecedenteMorbido= (int)dr["id_TipoAntecedenteMorbido_fk"]
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

            return operaciones;

        }
        public static void RegistrarOperacion(Operacion operacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"insert into Operaciones(nombre,id_tipoAntecedenteMorbido_fk)
                                  values(@nombre,@idTipoAntecedente)";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", operacion.nombre);
                cmd.Parameters.AddWithValue("@idTipoAntecedente", operacion.id_tipoAntecedenteMorbido);

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw e;
            }
        }
        public static void ActualizarOperacion(Operacion operacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"update Operaciones
                                    set nombre=@nombre
                                    where id_operacion=@idOperacion and id_tipoAntecedenteMorbido_fk=@idTipoAntecedente";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", operacion.nombre);
                cmd.Parameters.AddWithValue("@idOperacion", operacion.id_operacion);
                cmd.Parameters.AddWithValue("@idTipoAntecedente", operacion.id_tipoAntecedenteMorbido);

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw e;
            }
        }
    }
}
