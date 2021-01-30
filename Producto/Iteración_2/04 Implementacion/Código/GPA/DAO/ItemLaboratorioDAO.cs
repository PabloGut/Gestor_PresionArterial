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
    public class ItemLaboratorioDAO
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

        public static int registrarItemLaboratorio(string nombre, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into itemLaboratorio(nombre)
                                values(@nombre)";
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@nombre", nombre);

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('itemLaboratorio')", cn, tran);
                int id = Convert.ToInt32(cmd1.ExecuteScalar());
                return id;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new Exception("Error al insertar: " + e.Message);
            }

        }
        public static List<ItemLaboratorio> obtenerItemLaboratorio()
        {
            setCadenaConexion();
            List<ItemLaboratorio> items = new List<ItemLaboratorio>();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"select  il.nombre, il.id_itemLaboratorio
                                from ItemEstudioLaboratorio i , itemLaboratorio il
                                where i.id_itemLaboratorio_fk=il.id_itemLaboratorio";

            SqlCommand cmd = new SqlCommand();
            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    items.Add(new ItemLaboratorio()
                        {
                            idItemLaboratorio=(int)dr["id_itemLaboratorio"],
                            nombre=dr["nombre"].ToString()
                        });

                }
                cn.Close();
                return items;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new Exception("Error: " + e.Message);
            }


        }
        public static List<ItemLaboratorio> buscarItemLaboratorio(string nombre)
        {
            setCadenaConexion();
            List<ItemLaboratorio> items = new List<ItemLaboratorio>();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"select il.nombre,il.id_itemLaboratorio
                                from ItemEstudioLaboratorio i , itemLaboratorio il
                                where i.id_itemLaboratorio_fk=il.id_itemLaboratorio
                                and 1=1";

            SqlCommand cmd = new SqlCommand();

            if (!string.IsNullOrEmpty(nombre))
            {
                consulta += " and il.nombre like @nombre";
                cmd.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
            }
           
            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    items.Add(new ItemLaboratorio()
                    {
                        nombre = dr["nombre"].ToString(),
                        idItemLaboratorio = (int)dr["id_itemLaboratorio"]
                    });
                }
                cn.Close();
                return items;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new Exception("Error: " + e.Message);
            }


        }
        public static int obtenerItemLaboratorio(string nombreItemLaboratorio)
        {
            setCadenaConexion();

            int idItemLaboratorio = 0;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select id_itemLaboratorio from ItemLaboratorio where nombre like @nombreItemLaboratorio";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombreItemLaboratorio", nombreItemLaboratorio);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idItemLaboratorio = (int)dr["id_itemLaboratorio"];
                }

                cn.Close();
                return idItemLaboratorio;
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
