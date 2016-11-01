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
        public static int registrarHistoriaClinica(HistoriaClinica hc)
        {
            setCadenaConexion();
            SqlConnection cn= new SqlConnection(getCadenaConexion());
            int idHc;
            SqlTransaction tran = null;
            try
            {
                cn.Open();

                string consulta = @"insert into Historia_Clinica(nro_hc,fecha_creación,principalProblema, fecha_inicio_atencion_con_profesional, id_tipodoc_profesionaMedico_fk, id_nrodoc_profesionalMedico_fk,id_tipodoc_paciente_fk, id_nrodoc_paciente_fk,hora_creacion)
                                  values(@nroHc,@fechaCreacion,@principalProblema,@fechaInicioAtencionConProfesional,@idTipoDocProfesional,@idNroDocProfesional,@idTipoDocPaciente,@nroDocPaciente,@horaCreacion)";
                
                tran = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                
                cmd.Parameters.AddWithValue("@nroHc", hc.nro_hc);
                cmd.Parameters.AddWithValue("@fechaCreacion", hc.fecha);
                cmd.Parameters.AddWithValue("@principalProblema", hc.motivoConsulta);
                cmd.Parameters.AddWithValue("@fechaInicioAtencionConProfesional", hc.fechaInicioAtencion);
                cmd.Parameters.AddWithValue("@idTipoDocProfesional", hc.idtipodoc);
                cmd.Parameters.AddWithValue("@idNroDocProfesional", hc.nrodoc);
                cmd.Parameters.AddWithValue("@idTipoDocPaciente", hc.idtipodoc_paciente);
                cmd.Parameters.AddWithValue("@nroDocPaciente", hc.nrodoc_paciente);
                cmd.Parameters.AddWithValue("@horaCreacion", hc.hora);

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn,tran);

                idHc =Convert.ToInt32(cmd1.ExecuteScalar());

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
                throw new ApplicationException("Error: " + e.Message);
            }
            return idHc;
        }
        
        public static int buscarNroHC()
        {
            setCadenaConexion();
            int nro = 0;
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                String consulta = "SELECT TOP 1 nro_hc FROM Historia_Clinica ORDER BY id_hc DESC";

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        nro = (int)dr["nro_hc"];

                    }
                    cn.Close();
                    return nro;
                }
                else
                {
                    return nro;
                }
            }
            catch(Exception e)
            {
                if(cn.State== ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
        }

        public static DataSet mostrarHistoriaClinica(Paciente paciente)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            DataSet ds = null;

            try
            {

                cn.Open();

                string consulta = "select * from Historia_Clinica where id_tipodoc_paciente_fk=@idtipodoc and id_nrodoc_paciente_fk=@nrodocumento";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idtipodoc", paciente.id_tipoDoc);
                cmd.Parameters.AddWithValue("@nrodocumento", paciente.nroDoc);
                
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HistoriaClinica");
                da.Fill(dt);
                ds = new DataSet();
                ds.Tables.Add(dt);
               
                cn.Close();

                int idHc= (int) dt.Rows[0]["id_hc"];

                ds.Tables.Add(mostrarAntecedentesMorbidos(idHc));
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            return ds;
        }
        private static DataTable mostrarAntecedentesMorbidos(int idHc)
        {
            return AntecedenteMorbidoDAO.mostrarAntecedentesMorbidosDeHc(idHc);
        }
     /*
        public static int insertarHC(HistoriaClinica hc)
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "insert into Historia_Clinica(nro_hc,fecha_creación,diagnostico,antecedentes,fecha_inicio_atencion_con_profesional,id_tipodoc_fk,nro_documento,id_tipodoc_paciente_fk,nro_doc_paciente_fk) values (@nrohc,@fecha,@diagnostico,@antecedentes,@fechainicioAtencion,@idtipo,@nrodoc,@idtipodocpaciente,@nrodocpaciente)";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nroHC", hc.nro_hc);
            cmd.Parameters.AddWithValue("@fecha", hc.fecha);
            cmd.Parameters.AddWithValue("@diagnostico", hc.diagnostico);
            cmd.Parameters.AddWithValue("@antecedentes", hc.antecedentes);
            cmd.Parameters.AddWithValue("@fechainicioAtencion", hc.fechaInicioAtencion);
            cmd.Parameters.AddWithValue("@idtipo", hc.idtipodoc);
            cmd.Parameters.AddWithValue("@nrodoc", hc.nrodoc);
            cmd.Parameters.AddWithValue("@idtipodocpaciente", hc.idtipodoc_paciente);
            cmd.Parameters.AddWithValue("@nrodocpaciente", hc.nrodoc_paciente);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand("select @@Identity", cn);
            int idhc = Convert.ToInt32(cmd1.ExecuteScalar());


            cn.Close();
            return idhc;
        }
        */

    }
}
