using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class HistoriaClinicaDAO
    {
        //private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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
        public static int buscarNroHC()
        {
            int nro = -1;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            String consulta = "SELECT TOP 1 nro_hc FROM Historia_Clinica ORDER BY id_hc DESC";

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            if(dr.HasRows)
            {
                while (dr.Read())
                {
                   nro = (int)dr["nro_hc"];
                    
                }
                cn.Close();
                return nro;
            }
            else{
                return nro;
            }                     
        }
        public static int insertarHC(HistoriaClinica hc)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into Historia_Clinica(nro_hc,fecha_creación,diagnostico,antecedentes,fecha_inicio_atencion_con_profesional,id_tipodoc_fk,nro_documento) values (@nrohc,@fecha,@diagnostico,@antecedentes,@fechainicioAtencion,@idtipo,@nrodoc)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nroHC", hc.nro_hc);
            cmd.Parameters.AddWithValue("@fecha", hc.fecha);
            cmd.Parameters.AddWithValue("@diagnostico", hc.diagnostico);
            cmd.Parameters.AddWithValue("@antecedentes", hc.antecedentes);
            cmd.Parameters.AddWithValue("@fechainicioAtencion", hc.fechaInicioAtencion);
            cmd.Parameters.AddWithValue("@idtipo", hc.idtipodoc);
            cmd.Parameters.AddWithValue("@nrodoc", hc.nrodoc);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);
            int idhc = Convert.ToInt32(cmd1.ExecuteScalar());


            cn.Close();
            return idhc;
        }
    }
}
