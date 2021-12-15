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
    public class AntecedenteFamiliarDAO
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
        public static void registrarAntecedentesFamiliares(List<AntecedenteFamiliar> antecedentesFamiliares, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AntecedentesFamiliares(fechaRegistro,id_familiar_fk, familiarVive, enfermedades, descripcionOtrasEnfermedades, causaMuerte,observaciones,id_hc_fk)
                                  values(@fechaRegistro,@idFamilizar,@familiarVive,@enfermedades,@descripcionOtrasEnfermedades,@causaMuerte,@observaciones,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AntecedenteFamiliar antecedente in antecedentesFamiliares)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@fechaRegistro", antecedente.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idFamilizar", antecedente.id_familiar);
                    cmd.Parameters.AddWithValue("@familiarVive", antecedente.familiarVive);

                    if (antecedente.enfermedades.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@enfermedades", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@enfermedades", antecedente.enfermedades);
                    }

                    if (antecedente.descripcionOtrasEnfermedades.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@descripcionOtrasEnfermedades", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@descripcionOtrasEnfermedades", antecedente.descripcionOtrasEnfermedades);
                    }

                    if (antecedente.causaMuerte.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@causaMuerte", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@causaMuerte", antecedente.causaMuerte);
                    }
                    if (antecedente.observaciones.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@observaciones", antecedente.observaciones);
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
        public static DataTable MostrarAntecedentesFamiliares(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select af.fechaRegistro as 'Fecha de registro',f.nombre as 'Familiar',af.familiarVive 'Vive',af.enfermedades as 'Enfermedades',af.descripcionOtrasEnfermedades as 'Otras enfermedades',af.causaMuerte as 'Causa de muerte',af.observaciones as 'Observaciones'
                                    from AntecedentesFamiliares af,Familiar f
                                    where af.id_familiar_fk=f.id_familiar
                                    and id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesFamiliares");
                da.Fill(dt);
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dt;
        }

    }
}
