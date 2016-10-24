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
            //SqlTransaction tran = null;
            try
            {
                cn.Open();

                string consulta = @"insert into EspecificacionMedicamento(id_medicamento_fk,concentracion,id_unidadMedida_fk,id_formaAdministracion_fk,id_presentacionMedicamento_fk,cantidadComprimidos,id_nombreComercial_fk)
                                    values(@idMedicamento,@concentracion,@idUnidadMedida,@idFormaAdministracion,@idPresentacionMedicamento,@cantidadComprimidos,@idNombreComercial)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@concentracion", especificacionMedicamento.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionMedicamento.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionMedicamento.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacionMedicamento.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacionMedicamento.cantidadComprimidos);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionMedicamento.id_nombreComercial);

                //tran = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                //cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("select @@Identity", cn);
                
                especificacionMedicamento.id_especificacion= Convert.ToInt32(cmd2.ExecuteScalar());

                //tran.Commit();
                cn.Close();

                if (existeUnidadMedidaXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_unidadMedida_fk, especificacionMedicamento.id_nombreComercial) == false)
                {
                    registrarUnidadMedidaXMedicamento(especificacionMedicamento);
                }
                if (existeFormaAdministracionXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_formaAdministracion, especificacionMedicamento.id_nombreComercial) == false)
                {
                    registrarFormaAdministracionXMedicamento(especificacionMedicamento);
                }
                if (existePresentacionXMedicamento(especificacionMedicamento.id_medicamento_fk, especificacionMedicamento.id_presentacionMedicamento, especificacionMedicamento.id_nombreComercial) == false)
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

                string consulta = @"insert into UnidadMedidaXMedicamento(id_medicamento_fk,id_unidadMedida_fk,id_nombreComercial_fk)
                                    values(@idMedicamento,@idUnidadMedida,@idNombreComercial)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionMedicamento.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionMedicamento.id_nombreComercial);

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

                string consulta = @"insert into FormaAdministracionXMedicamento(id_medicamento_fk,id_formaAdministracion_fk,id_nombreComercial_fk)
                                    values(@idMedicamento,@idFormaAdministracion,@idNombreComercial)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionMedicamento.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionMedicamento.id_nombreComercial);

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

                string consulta = @"insert into PresentacionMedicamentoXMedicamento(id_medicamento_fk,id_presentacionMedicamento_fk,id_nombreComercial_fk)
                                    values(@idMedicamento,@idPresentacionMedicamento,@idNombreComercial)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionMedicamento.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacionMedicamento.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionMedicamento.id_nombreComercial);

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

                string consulta = @"select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk,em.id_nombreComercial_fk
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
                                  where em.id_nombreComercial_fk=nc.id_nombreComercial
                                  and m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
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

                string consulta = @" select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
                                  where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
                                  and em.id_nombreComercial_fk=nc.id_nombreComercial
                                  and em.id_unidadMedida_fk=um.id_unidadMedida
                                  and em.id_formaAdministracion_fk=fa.id_formaAdministracion
                                  and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento
                                  and em.concentracion=@concentracion and em.id_unidadMedida_fk=@idUnidadMedida and em.id_formaAdministracion_fk=@idFormaAdministracion and em.id_presentacionMedicamento_fk=@idPresentacionMedicamento and em.cantidadComprimidos=@cantidadComprimidos and em.id_nombreComercial_fk=@idNombreComercial";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacion.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@concentracion", especificacion.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacion.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacion.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacion.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacion.cantidadComprimidos);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacion.id_nombreComercial);

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
        public static Boolean existePresentacionXMedicamento(int id_medicamento, int id_presentacion,int id_nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from PresentacionMedicamentoXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_presentacionMedicamento_fk=@idPresentacion and id_nombreComercial_fk=@idNombreComercial";
                                    

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idPresentacion", id_presentacion);
                cmd.Parameters.AddWithValue("@idNombreComercial", id_nombreComercial);

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
        public static Boolean existeUnidadMedidaXMedicamento(int id_medicamento, int id_unidadMedida, int id_nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from UnidadMedidaXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_unidadMedida_fk=@idUnidadMedida and id_nombreComercial_fk=@idNombreComercial";


                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idUnidadMedida", id_unidadMedida);
                cmd.Parameters.AddWithValue("@idNombreComercial", id_nombreComercial);

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
        public static Boolean existeFormaAdministracionXMedicamento(int id_medicamento, int id_formaAdministracion, int id_nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            Boolean existe = false;
            try
            {
                cn.Open();

                string consulta = @"select * from FormaAdministracionXMedicamento
                                  where id_medicamento_fk=@idMedicamento and id_formaAdministracion_fk=@idFormaAdministracion and id_nombreComercial_fk=@idNombreComercial";


                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", id_medicamento);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idNombreComercial", id_nombreComercial);

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
       * Método para actualizar los datos de una especificacion.
       * Recibe como parámetro un objeto EspecificacionMedicamento.
       * Valor de retorno void.
       */
        public static void actualizarEspecificacion(EspecificacionMedicamento especificacionMedicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"update EspecificacionMedicamento
                                    set(@concentracion,@idUnidadMedida,@idFormaAdministracion,@idPresentacionMedicamento,@cantidadComprimidos,@idNombreComercial)
                                    where id_especificacion=@idEspecificacion and id_medicamento_fk=@idMedicamento";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idEspecificacion", especificacionMedicamento.concentracion);
                cmd.Parameters.AddWithValue("@concentracion", especificacionMedicamento.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionMedicamento.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionMedicamento.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacionMedicamento.cantidadComprimidos);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionMedicamento.id_nombreComercial);

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
         * Método para actualizar tabla UnidadMedidaPorMedicamento.
         * Recibe como parámetro un objeto EspecificacionMedicamento.
         * Valor de retorno void.
         */
        public static void actualizarUnidadMedidaPorMedicamento(EspecificacionMedicamento especificacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"update UnidadMedidaXMedicamento
                                    set(@idmedicamento,@idUnidadMedida)
                                    where id_medicamento_fk=@idmedicamento and id_unidadMedida_fk=@idUnidadMedida";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idmedicamento", especificacion.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacion.id_unidadMedida_fk);

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
      * Método para actualizar tabla PresentacionMedicamentXMedicamento.
      * Recibe como parámetro un objeto EspecificacionMedicamento.
      * Valor de retorno void.
      */
        public static void actualizarPresentacionMedicamentoXMedicamento(EspecificacionMedicamento especificacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"update PresentacionMedicamentoXMedicamento
                                    set(@idMedicamento,@idPresentacionMedicamento)
                                    where id_medicamento_fk=@idMedicamento and id_presentacionMedicamento_fk=@idPresentacionMedicamento";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idmedicamento", especificacion.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", especificacion.id_presentacionMedicamento);

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
      * Método para actualizar una forma de administración de un medicamento.
      * Recibe como parámetro un objeto EspecificacionMedicamento.
      * Valor de retorno void.
      */
        public static void actualizarFormaAdministracionXMedicamento(EspecificacionMedicamento especificacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"update FormaAdministracionXMedicamento
                                    set(@idMedicamento,@idFormaAdministracion)
                                    where id_medicamento_fk=@idMedicamento and id_formaAdministracion_fk=@idFormaAdministracion";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacion.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacion.id_formaAdministracion);

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
      * Método para eliminar una especificacion de la tabla EspecificacionMedicamento.
      * Recibe como parámetro un entero que corresponde al id de la especificacion.
      * Valor de retorno void.
      */
        public static void eliminarEspecificacion(int idEspecificacion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"delete from EspecificacionMedicamento
                                    where id_especificacion=@idEspecificacion";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idEspecificacion", idEspecificacion);
                

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
       * Método mostrar los datos de una especificación de un medicamento.
       * Recibe como parámetro objeto especificacion.
       * Retorna un DataTable.
       */
        public static DataTable mostrarEspecificacionMedicamento(string nombreGenerico)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @" select m.nombreGenerico as 'Nombre genérico', nc.nombre as 'Nombre comercial', em.concentracion as 'Concentración', um.nombre as 'Unidad de medida', fa.nombre as 'Forma de administración', pm.nombre as 'Presentación del medicamento', em.cantidadComprimidos as 'Cantidad de comprimidos', m.id_medicamento,em.id_especificacion, em.id_medicamento_fk,em.id_formaAdministracion_fk,em.id_unidadMedida_fk,em.id_presentacionMedicamento_fk,em.id_nombreComercial_fk
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc,UnidadMedida um, FormaAdministracion fa, PresentacionMedicamento pm
                                  where m.id_medicamento= em.id_medicamento_fk and m.id_medicamento=nc.id_medicamento_fk
                                  and em.id_nombreComercial_fk=nc.id_nombreComercial
                                  and em.id_unidadMedida_fk=um.id_unidadMedida
                                  and em.id_formaAdministracion_fk=fa.id_formaAdministracion
                                  and em.id_presentacionMedicamento_fk= pm.id_presentacionMedicamento
                                  and m.nombreGenerico like  @nombreGenerico+'%' ";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreGenerico", nombreGenerico);

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
       * Método mostrar las unidades de medida para un nombre genérico y comercial.
       * No recibe parámetros.
       * Retorna una lista de objetos UnidadMedida.
       */
        public static List<UnidadDeMedida> mostrarUnidadMedidaParaUnNombreGenericoYComercial(int idMedicamento, int idNombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<UnidadDeMedida> unidadesMedida = new List<UnidadDeMedida>();
            try
            {
                cn.Open();

                string consulta = @"select distinct um.id_unidadMedida,cast(um.nombre as varchar(max)) as 'nombre'
                                  from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, UnidadMedidaXMedicamento umm, UnidadMedida um
                                  where m.id_medicamento=em.id_medicamento_fk 
                                  and em.id_nombreComercial_fk=nc.id_nombreComercial
                                  and em.id_unidadMedida_fk=umm.id_unidadMedida_fk 
                                  and em.id_medicamento_fk=umm.id_medicamento_fk
                                  and em.id_nombreComercial_fk=umm.id_nombreComercial_fk
                                  and umm.id_unidadMedida_fk=um.id_unidadMedida
                                  and umm.id_medicamento_fk=m.id_medicamento
                                  and umm.id_nombreComercial_fk=nc.id_nombreComercial
                                  and em.id_medicamento_fk=@idMedicamento and em.id_nombreComercial_fk=@idNombreComercial";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", idNombreComercial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    unidadesMedida.Add(new UnidadDeMedida()
                    {
                        id_unidadMedida=(int)dr["id_unidadMedida"],
                        nombre=dr["nombre"].ToString()
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
            return unidadesMedida;
        }
        /*
      * Método mostrar formas de administracion para un nombre genérico y comercial.
      * No recibe parámetros.
      * Retorna una lista de objetos FormaAdministracion.
      */
        public static List<FormaAdministracion> mostrarFormaAdministracionParaUnNombreGenericoYComercial(int idMedicamento, int idNombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<FormaAdministracion> formasAdministracion = new List<FormaAdministracion>();
            try
            {
                cn.Open();

                string consulta = @"select distinct fa.id_formaAdministracion,cast(fa.nombre as varchar(max)) as 'nombre'
                                 from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, FormaAdministracionXMedicamento fam, FormaAdministracion fa
                                 where m.id_medicamento=em.id_medicamento_fk 
                                 and em.id_nombreComercial_fk=nc.id_nombreComercial
                                 and em.id_formaAdministracion_fk=fam.id_formaAdministracion_fk 
                                 and em.id_medicamento_fk=fam.id_medicamento_fk
                                 and em.id_nombreComercial_fk=fam.id_nombreComercial_fk
                                 and fam.id_formaAdministracion_fk=fa.id_formaAdministracion
                                 and fam.id_medicamento_fk=m.id_medicamento
                                 and fam.id_nombreComercial_fk=nc.id_nombreComercial
                                 and em.id_medicamento_fk=@idMedicamento and em.id_nombreComercial_fk=@idNombreComercial";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", idNombreComercial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    formasAdministracion.Add(new FormaAdministracion()
                    {
                        id_formaAdministracion = (int)dr["id_formaAdministracion"],
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
            return formasAdministracion;
        }
        /*
       * Método mostrar presentaciones del medicamento para un nombre genérico y comercial.
       * No recibe parámetros.
       * Retorna una lista de objetos PresentacionMedicamento.
       */
        public static List<PresentacionMedicamento> mostrarPresentacionMedicamentoParaUnNombreGenericoYComercial(int idMedicamento, int idNombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<PresentacionMedicamento> presentacionesMedicamento = new List<PresentacionMedicamento>();
            try
            {
                cn.Open();

                string consulta = @"select distinct pm.id_presentacionMedicamento,cast(pm.nombre as varchar(max)) as 'nombre'
                                 from Medicamento m,EspecificacionMedicamento em, NombreComercial nc, PresentacionMedicamentoXMedicamento pmm, PresentacionMedicamento pm
                                 where m.id_medicamento=em.id_medicamento_fk 
                                 and em.id_nombreComercial_fk=nc.id_nombreComercial
                                 and em.id_presentacionMedicamento_fk=pmm.id_presentacionMedicamento_fk 
                                 and em.id_medicamento_fk=pmm.id_medicamento_fk
                                 and em.id_nombreComercial_fk=pmm.id_nombreComercial_fk
                                 and pmm.id_presentacionMedicamento_fk=pm.id_presentacionMedicamento
                                 and pmm.id_medicamento_fk=m.id_medicamento
                                 and pmm.id_nombreComercial_fk=nc.id_nombreComercial
                                 and em.id_medicamento_fk=@idMedicamento and em.id_nombreComercial_fk=@idNombreComercial";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", idNombreComercial);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    presentacionesMedicamento.Add(new PresentacionMedicamento()
                    {
                        id_presentacionMedicamento = (int)dr["id_presentacionMedicamento"],
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
            return presentacionesMedicamento;
        }

        public static List<int> mostrarConcentracionEspecificacionMedicamento(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            
            List<int> concetracionMedicamento = new List<int>();
            try
            {
                cn.Open();

                string consulta = @"select concentracion from EspecificacionMedicamento
                                  where id_medicamento_fk=@idMedicamento
                                  and id_nombreComercial_fk=@idNombreComercial
                                  and id_unidadMedida_fk=@idUnidadMedida
                                  and id_formaAdministracion_fk=@idFormaAdministracion
                                  and id_presentacionMedicamento_fk=@idPresentacion";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", idNombreComercial);
                cmd.Parameters.AddWithValue("@idUnidadMedida", idUnidadMedida);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", idFormaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacion", idPresentacion);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {   
                    concetracionMedicamento.Add((int)dr["concentracion"]);
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
            return concetracionMedicamento;
        }
        public static List<int> mostrarCantidadComprimidosEspecificacionMedicamento(int idMedicamento, int idNombreComercial, int idUnidadMedida, int idPresentacion, int idFormaAdministracion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            List<int> cantidadComprimidos = new List<int>();
            try
            {
                cn.Open();

                string consulta = @"select cantidadComprimidos from EspecificacionMedicamento
                                  where id_medicamento_fk=@idMedicamento
                                  and id_nombreComercial_fk=@idNombreComercial
                                  and id_unidadMedida_fk=@idUnidadMedida
                                  and id_formaAdministracion_fk=@idFormaAdministracion
                                  and id_presentacionMedicamento_fk=@idPresentacion";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                cmd.Parameters.AddWithValue("@idNombreComercial", idNombreComercial);
                cmd.Parameters.AddWithValue("@idUnidadMedida", idUnidadMedida);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", idFormaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacion", idPresentacion);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cantidadComprimidos.Add((int)dr["cantidadComprimidos"]);
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
            return cantidadComprimidos;
        }
        public static void buscarIdEspecificacion(EspecificacionMedicamento especificacionBuscada)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            
            try
            {
                cn.Open();

                string consulta = @"select idEspecificacion from EspecificacionMedicamento
                                  where id_medicamento_fk=@idMedicamento
                                  and id_nombreComercial_fk=@idNombreComercial
                                  and id_unidadMedida_fk=@idUnidadMedida
                                  and id_formaAdministracion_fk=@idFormaAdministracion
                                  and id_presentacionMedicamento_fk=@idPresentacion
                                  and concentracion=@concentracion and cantidadComprimidos=@cantidadComprimidos";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idMedicamento", especificacionBuscada.id_medicamento_fk);
                cmd.Parameters.AddWithValue("@idNombreComercial", especificacionBuscada.id_nombreComercial);
                cmd.Parameters.AddWithValue("@idUnidadMedida", especificacionBuscada.id_unidadMedida_fk);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", especificacionBuscada.id_formaAdministracion);
                cmd.Parameters.AddWithValue("@idPresentacion", especificacionBuscada.id_presentacionMedicamento);
                cmd.Parameters.AddWithValue("@concentracion", especificacionBuscada.concentracion);
                cmd.Parameters.AddWithValue("@cantidadComprimidos", especificacionBuscada.cantidadComprimidos);


                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {   
                    especificacionBuscada.id_especificacion=(int)dr["id_especificacion"];
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
        }
    }
}
