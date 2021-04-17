using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace DAO
{
    public class AntecedentePatologicoPersonalDAO
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
        public static void registrarAntecedentesPatologicosPersonales(AntecedentePatologicoPersonal antecedente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"insert into AntecedentesPatologicosPersonales(fechaRegistro, enfermedades, descripcion_otrasEnfermedades, id_hc_fk)
                               values(@fechaRegistro,@enfermedades,@descripcion,@idhc)";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@fechaRegistro", antecedente.fechaRegistro);

                if (string.IsNullOrEmpty(antecedente.enfermedades))
                {
                    cmd.Parameters.AddWithValue("@enfermedades", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@enfermedades", antecedente.enfermedades);
                }

                if (string.IsNullOrEmpty(antecedente.otrasEnfermedades))
                {
                    cmd.Parameters.AddWithValue("@descripcion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@descripcion", antecedente.otrasEnfermedades);
                }

                cmd.Parameters.AddWithValue("@idhc", antecedente.idhc);


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
                throw new ApplicationException("Error:" + e.Message);
            }

       
        }
        public static DataTable MostrarAntecedentesPatologicosPersonales(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select fechaRegistro as 'Fecha de registro',enfermedades as 'Enfermedades', descripcion_otrasEnfermedades as 'Otras Enfermedades'
                                    from AntecedentesPatologicosPersonales
                                    where id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesPatologicosPersonales");
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
