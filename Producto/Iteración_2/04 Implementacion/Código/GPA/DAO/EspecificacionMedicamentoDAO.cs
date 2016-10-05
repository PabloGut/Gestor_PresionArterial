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
    public class EspecificacionMedicamentoDAO
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
     * Método para registrar Medicamentos.
     * Recibe como parámetro un objeto EspecificacionMedicamento.
     * Valor de retorno void.
     */
        public static void registrarEspecificacionMedicamento(EspecificacionMedicamento especificacionMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();

                string consulta = @"insert into EspecificacionMedicamento(id_medicamento_fk,concentracion,id_unidadMedida_fk,id_formaAdministracion_fk,id_presentacionMedicamento_fk,cantidadComprimidos)
                                    values(@idMedicamento,@concentracion,@idUnidadMedida,@idFormaAdministracion,@idPresentacionMedicamento,@cantidadComprimidos)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@concentracion", especificacionMedicamento.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionMedicamento.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionMedicamento.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacionMedicamento.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacionMedicamento.cantidadComprimidos);

                tran = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);

                especificacionMedicamento.id_especificacion= Convert.ToInt32(cmd1.ExecuteScalar());

                tran.Commit();
                cn.Close();

                if (existeUnidadMedidaXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_unidadMedida_fk) == false)
                {
                    registrarUnidadMedidaXMedicamento(especificacionMedicamento);
                }
                if (existeFormaAdministracionXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_formaAdministracion) == false)
                {
                    registrarFormaAdministracionXMedicamento(especificacionMedicamento);
                }
                if (existePresentacionXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_presentacionMedicamento) == false)
                {
                    registrarPresentacionXMedicamento(especificacionMedicamento);
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }

        }
        /*
        * Método para registrar una unidad de medida por medicamento.
        * Recibe como parámetro un objeto EspecificacionMedicamento.
        * Valor de retorno void.
        */
        public static void registrarUnidadMedidaXMedicamento(EspecificacionMedicamento especificacionMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk)
                                    values(@idMedicamento,@idUnidadMedida)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionMedicamento.id_unidadMedida_fk);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }

        }
        /*
         * Método para registrar una forma de administracion de un medicamento.
         * Recibe como parámetro un objeto EspecificacionMedicamento.
         * Valor de retorno void.
         */
        public static void registrarFormaAdministracionXMedicamento(EspecificacionMedicamento especificacionMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk)
                                    values(@idMedicamento,@idFormaAdministracion)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionMedicamento.id_formaAdministracion);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }

        }
        /*
        * Método para registrar una forma de presentacion de un medicamento.
        * Recibe como parámetro un objeto EspecificacionMedicamento.
        * Valor de retorno void.
        */
        public static void registrarPresentacionXMedicamento(EspecificacionMedicamento especificacionMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk)
                                    values(@idMedicamento,@idPresentacionMedicamento)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacionMedicamento.id_presentacionMedicamento);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }

        }
        /*
      * Método para obtener la informacion de los medicamentos.
      * No recibe parámetros.
      * Retorna un DataTable.
      */
        public static DataTable mostrarMedicamentos()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                /*string consulta = @"select m.nombreGenerico as 'Nombre genérico',nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', em.id_medicamento_fk, em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
                                    from Medicamento m,EspecificacionMedicamento em,NombreComercial nc,UnidadMedida um,UnidadMedidaXMedicamento umm, FormaAdministracion fa, FormaAdministracionXMedicamento fam, PresentacionMedicamento pm, PresentacionMedicamentoXMedicamento prem 
                                    where m.id_medicamento=em.id_medicamento_fk 
                                    and m.id_medicamento=nc.id_medicamento_fk and m.id_medicamento=umm.id_medicamento_fk and um.id_unidadMedida=umm.id_unidadMedida_fk
                                    and m.id_medicamento=fam.id_medicamento_fk and fa.id_formaAdministracion=fam.id_formaAdministracion_fk
                                    and m.id_medicamento=prem.id_medicamento_fk and pm.id_presentacionMedicamento=prem.id_presentacionMedicamento_fk";*/

                string consulta = @"select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
                                  where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
                                  and em.id_unidadMedida_fk=um.id_unidadMedida
                                  and em.id_formaAdministracion_fk=fa.id_formaAdministracion
                                  and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

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
            return dt;
        }
        /*
        * Método para verificar si existe una especificación de un medicamento.
        * Recibe como parámetro objeto especificacion.
        * Retorna un Boolean.
        */
        public static Boolean existeEspecificacion(EspecificacionMedicamento especificacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existeEspecificacion = false;
            try
            {
                cn.Open();

                /*string consulta = @"select m.nombreGenerico as 'Nombre genérico',nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', em.id_medicamento_fk, em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
                                    from Medicamento m,EspecificacionMedicamento em,NombreComercial nc,UnidadMedida um,UnidadMedidaXMedicamento umm, FormaAdministracion fa, FormaAdministracionXMedicamento fam, PresentacionMedicamento pm, PresentacionMedicamentoXMedicamento prem 
                                    where m.id_medicamento=em.id_medicamento_fk 
                                    and m.id_medicamento=nc.id_medicamento_fk and m.id_medicamento=umm.id_medicamento_fk and um.id_unidadMedida=umm.id_unidadMedida_fk
                                    and m.id_medicamento=fam.id_medicamento_fk and fa.id_formaAdministracion=fam.id_formaAdministracion_fk
                                    and m.id_medicamento=prem.id_medicamento_fk and pm.id_presentacionMedicamento=prem.id_presentacionMedicamento_fk
                                    and em.id_medicamento_fk=@idMedicamento and em.concentracion=@concentracion and em.id_unidadMedida_fk=@idUnidadMedida and em.id_formaAdministracion_fk=@idFormaAdministracion and em.id_presentacionMedicamento_fk=@idPresentacionMedicamento and em.cantidadComprimidos=@cantidadComprimidos ";*/

                string consulta = @"select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentracción', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
                                  where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
                                  and em.id_unidadMedida_fk=um.id_unidadMedida
                                  and em.id_formaAdministracion_fk=fa.id_formaAdministracion
                                  and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacion.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@concentracion", especificacion.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacion.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacion.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacion.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacion.cantidadComprimidos);

                


                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        existeEspecificacion = true;
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
            return existeEspecificacion;
        }
        /*
      * Método para verificar si el medicamento tiene una determinada presentacion.
      * Recibe como parámetro id_medicamento e id_presentacion.
      * Retorna un Boolean.
      */
        public static Boolean existePresentacionXMedicamento(int id_medicamento, int id_presentacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from PresentacionXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_presentacionMedicamento_fk=@idPresentacion";
                                    

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idPresentacion", id_presentacion);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        existe = true;
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
            return existe;
        }
        /*
         * Método para verificar si el medicamento tiene una determinada unidad de medida.
         * Recibe como parámetro id_medicamento e id_unidadMedida.
         * Retorna un Boolean.
         */
        public static Boolean existeUnidadMedidaXMedicamento(int id_medicamento, int id_unidadMedida)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from UnidadMedidaXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_unidadMedida_fk=@idUnidadMedida";


                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idUnidadMedida", id_unidadMedida);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        existe = true;
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
            return existe;
        }
        /*
         * Método para verificar si el medicamento tiene una determinada forma de administración.
         * Recibe como parámetro id_medicamento e id_formaAdministracion.
         * Retorna un Boolean.
         */
        public static Boolean existeFormaAdministracionXMedicamento(int id_medicamento, int id_formaAdministracion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from FormaAdministracionXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_formaAdministracion_fk=@idFormaAdministracion";


                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", id_formaAdministracion);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        existe = true;
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
            return existe;
        }
    }
}
