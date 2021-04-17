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
    public class AntecedenteMorbidoDAO
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
        public static void registrarAntecedenteMorbido(List<AntecedenteMorbido> antecedentesMorbidos,int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AntecedentesMorbidos(fechaRegistro,id_tipoAntecedenteMorbido_fk,id_enfermedad_fk,id_operacion_fk,id_traumatismo_fk,cantidadTiempo,id_elementoTiempo_fk,evolucion,tratamiento,id_hc_fk)
                                  values(@fechaRegistro,@idTipoAntecedenteMorbido,@idEnfermedad,@idOperacion,@idTraumatismo,@cantidadTiempo,@idElementoTiempo,@evolucion,@tratamiento,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AntecedenteMorbido antecedente in antecedentesMorbidos)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@fechaRegistro", antecedente.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idTipoAntecedenteMorbido", antecedente.id_tipoAntecedenteMorbido);

                    if (antecedente.id_enfermedad == 0)
                    {
                        cmd.Parameters.AddWithValue("@idEnfermedad", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idEnfermedad", antecedente.id_enfermedad);
                    }
                    if (antecedente.id_operacion == 0)
                    {
                        cmd.Parameters.AddWithValue("@idOperacion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idOperacion", antecedente.id_operacion);
                    }
                    if (antecedente.id_traumatismo == 0)
                    {
                        cmd.Parameters.AddWithValue("@idTraumatismo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idTraumatismo", antecedente.id_traumatismo);
                    }
                    
                    cmd.Parameters.AddWithValue("@cantidadTiempo", antecedente.cantidadTiempo);
                    cmd.Parameters.AddWithValue("@idElementoTiempo", antecedente.id_elementoTiempo);

                    if (antecedente.evolución.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@evolucion",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@evolucion", antecedente.evolución);
                    }

                    if (antecedente.tratamiento.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@tratamiento", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tratamiento", antecedente.tratamiento);
                    }

                    cmd.Parameters.AddWithValue("@idHc", idHc);

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
        public static DataTable mostrarAntecedentesMorbidosEnfermedadesDeHc(int idHc)
        {
             setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            
            try
            {

                cn.Open();

                string consulta = @"select am.fechaRegistro as 'Fecha de registro', tam.nombre as 'Tipo de Antecedente Mórbido', enf.nombre as 'Nombre', am.evolucion as 'Evolución', am.tratamiento as 'Tratamiento',CONCAT(am.cantidadTiempo,' ',et.nombre) as 'Cantidad de tiempo en que ocurrió'
                                  from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf,ElementoDelTiempo et
                                  where hc.id_hc= am.id_hc_fk and hc.id_hc= @idHc and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                  and am.id_enfermedad_fk=enf.id_enfermedad
                                  and am.id_elementoTiempo_fk=et.id_elementoDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);
                
                
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesMorbidosEnfermedades");
                da.Fill(dt);

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
            return dt;
        }
        public static DataSet mostrarAntecedentesMorbidosEnfermedadesDeHc(int idHc,DataSet ds)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
   

            try
            {
                cn.Open();

                string consulta = @"select am.fechaRegistro as 'Fecha de registro', tam.nombre as 'Tipo de Antecedente Mórbido', enf.nombre as 'Nombre', am.evolucion as 'Evolución', am.tratamiento as 'Tratamiento',CONCAT(am.cantidadTiempo,' ',et.nombre) as 'Cantidad de tiempo en que ocurrió'
                                  from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf,ElementoDelTiempo et
                                  where hc.id_hc= am.id_hc_fk and hc.id_hc= @idHc and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                  and am.id_enfermedad_fk=enf.id_enfermedad
                                  and am.id_elementoTiempo_fk=et.id_elementoDelTiempo";

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da.SelectCommand = cmd;

                da.Fill(ds, "AntecedentesMorbidosEnfermedades");


                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return ds;
        }
        public static DataTable mostrarAntecedentesMorbidosTraumatismosDeHc(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {

                cn.Open();

                string consulta = @"select am.fechaRegistro as 'Fecha de registro', tam.nombre as 'Tipo de Antecedente Mórbido', trau.nombre as 'Nombre', am.evolucion as 'Evolución', am.tratamiento as 'Tratamiento',CONCAT(am.cantidadTiempo,' ',et.nombre) as 'Cantidad de tiempo en que ocurrió'
                                  from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Traumatismos trau,ElementoDelTiempo et
                                  where hc.id_hc= am.id_hc_fk and hc.id_hc= @idHc and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                  and am.id_traumatismo_fk=trau.id_traumatismo
                                  and am.id_elementoTiempo_fk=et.id_elementoDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesMorbidosTraumatismo");
                da.Fill(dt);

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
            return dt;
        }
        public static DataTable mostrarAntecedentesMorbidosOperacionesDeHc(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;

            try
            {
                cn.Open();

                string consulta = @"select am.fechaRegistro as 'Fecha de registro',tam.nombre as 'Tipo de Antecedente Mórbido', ope.nombre as 'Nombre', am.evolucion as 'Evolución', am.tratamiento as 'Tratamiento',CONCAT(am.cantidadTiempo,' ',et.nombre) as 'Cantidad de tiempo en que ocurrió'
                                  from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Operaciones ope,ElementoDelTiempo et
                                  where hc.id_hc= am.id_hc_fk and hc.id_hc= @idHc and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                  and am.id_operacion_fk=ope.id_operacion 
                                  and am.id_elementoTiempo_fk=et.id_elementoDelTiempo";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesMorbidosOperaciones");
                da.Fill(dt);

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
            return dt;


        }
        
    }
}
