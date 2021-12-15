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
    public class EnfermedadesDAO
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
         * Método para obtener todas las columnas de la tabla Enfermedades.
         * Recibe como parámetro el id_tipoAntecedenteMorbido.
         * Retorna una lista de objetos Enfermedad.
         */
        public static List<Enfermedad> mostrarEnfermedades(int id_tipoAntecedenteMorbido)
        {
            setCadenaConexion();
            List<Enfermedad> enfermedades = new List<Enfermedad>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from Enfermedades where id_tipoAntecedenteMorbido_fk=@id_tipoAntecedenteMorbido";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@id_tipoAntecedenteMorbido", id_tipoAntecedenteMorbido);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    enfermedades.Add(new Enfermedad()
                    {
                        id_enfermedad = (int)dr["id_enfermedad"],
                        nombre = dr["nombre"].ToString(),
                        id_tipoAntecedenteMorbido = (int)dr["id_TipoAntecedenteMorbido_fk"]
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

            return enfermedades;

        }
        public static void RegistrarEnfermedad(Enfermedad enfermedad)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"insert into Enfermedades(nombre,id_tipoAntecedenteMorbido_fk)
                                  values(@nombre,@idTipoAntecedente)";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", enfermedad.nombre);
                cmd.Parameters.AddWithValue("@idTipoAntecedente", enfermedad.id_tipoAntecedenteMorbido);

                cmd.ExecuteNonQuery();

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    //tran.Rollback();
                }
                throw e;
            }
        }
        public static void ActualizarEnfermedad(Enfermedad enfermedad)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"update Enfermedades
                                    set nombre=@nombre
                                    where id_enfermedad=@idEnfermedad and id_tipoAntecedenteMorbido_fk=@idTipoAntecedente";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@nombre", enfermedad.nombre);
                cmd.Parameters.AddWithValue("@idEnfermedad", enfermedad.id_enfermedad);
                cmd.Parameters.AddWithValue("@idTipoAntecedente", enfermedad.id_tipoAntecedenteMorbido);

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
