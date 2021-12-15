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
    public class AnalisisLaboratorioDAO
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
      * Método para obtener los nombres de pruebas de laboratorio.
      * No recibe parámetros.
      * Retorna una lista de objetos AnalisisLaboratorio.
      */
        public static List<AnalisisLaboratorio> MostrarAnalisisLaboratorio()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<AnalisisLaboratorio> analisis = new List<AnalisisLaboratorio>();
            try
            {
                cn.Open();

                string consulta = "select * from ItemLaboratorio order by id_itemLaboratorio desc";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    analisis.Add(new AnalisisLaboratorio()
                    {
                        id_analisis = (int)dr["id_itemLaboratorio"],//se cambia la tabla para q busque los datos de ItemLaboratorio y no de AnalisisLaboratorio
                        nombre = dr["nombre"].ToString(),
                        //descripcion = dr["descripcion"].ToString()
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
            return analisis;
        }
        public static List<Laboratorio> obtenerLaboratorio(int idHc)
        {
            setCadenaConexion();

            List<Laboratorio> ListaAnalisis = new List<Laboratorio>();
            AnalisisLaboratorio nomAnalisis = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select l.fechaSolicitud,al.nombre as 'NombreAnalisis', l.indicaciones, p.nombre, p.apellido
                                from ExamenGeneral e, Consulta c, Historia_Clinica hc, Paciente p, RazonamientoDiagnostico r, Laboratorio l, AnalisisLaboratorio al, EstadoDiagnostico ediag
                                where e.id_examenGeneral=c.id_examenGeneral_fk
                                and hc.id_hc=c.id_hc_fk
                                and hc.id_hc=p.id_hc_fk
                                and r.id_ExamenGeneral_fk=e.id_examenGeneral
                                and l.id_razonamientoDiagnostico_fk=r.id_razonamiento
                                and l.id_analisisLaboratorio_fk=al.nombre
                                and r.id_estadoDiagnostico_fk=ediag.id_estadoDiagnostico
                                and l.fechaRealizacion is null
                                and (ediag.nombre like 'Tentativo' or ediag.nombre like 'Definitivo')
                                and hc.id_hc=@idHc";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idHc", idHc);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nomAnalisis = new AnalisisLaboratorio();
                    nomAnalisis.nombre = dr["NombreAnalisis"].ToString();

                    Laboratorio laboratorio = new Laboratorio();
                    laboratorio.fechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]);
                    laboratorio.analisis = nomAnalisis;
                    laboratorio.indicaciones = dr["indicaciones"].ToString();

                    ListaAnalisis.Add(laboratorio);
                }

                cn.Close();
                return ListaAnalisis;
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
        public static int obtenerLaboratorio(string nombreAnalisis)
        {
            setCadenaConexion();

            int idAnalisisLaboratorio = 0;

            SqlConnection cn = new SqlConnection(getCadenaConexion());



            string consulta = @"select id_analisisLaboratorio from AnalisisLaboratorio where nombre like @nombreAnalisis";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@nombreAnalisis", nombreAnalisis);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idAnalisisLaboratorio=(int)dr["id_analisisLaboratorio"];
                }

                cn.Close();
                return idAnalisisLaboratorio;
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
        public static void insertAnalisisLaboratorio(AnalisisLaboratorio analisis)
        {
                setCadenaConexion();

                string consulta = @"insert into AnalisisLaboratorio(nombre,descipcion)
                                values(@nombre,@descripcion)";

                SqlConnection cn = new SqlConnection(getCadenaConexion());

                SqlCommand cmd = new SqlCommand();

                try
                {
                    cn.Open();

                    cmd.Parameters.AddWithValue("@nombre", analisis.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", analisis.descripcion);

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
                    throw new Exception("Error al insertar: " + e.Message);
                }
        }
        public static void updateAnalisisLaboratorio(AnalisisLaboratorio analisis)
        {
            setCadenaConexion();

            string consulta = @"update AnalisisLaboratorio
                                set nombre=@nombre, descripcion=@descripcion
                                where id_analisisLaboratorio=@id_analisis";

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.Open();

                cmd.Parameters.AddWithValue("@nombre", analisis.nombre);
                cmd.Parameters.AddWithValue("@descripcion", analisis.descripcion);
                cmd.Parameters.AddWithValue("@id_analisis", analisis.id_analisis);

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
                throw new Exception("Error al insertar: " + e.Message);
            }
        }
        public static AnalisisLaboratorio obtenerLaboratorioPorId(int idAnalisis)
        {
            setCadenaConexion();

            AnalisisLaboratorio nomAnalisis = null;

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"select id_analisisLaboratorio,a.nombre,a.descripcion
                                from AnalisisLaboratorio a
                                where id_analisisLaboratorio=@idAnalisis";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@idAnalisis", idAnalisis);

            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nomAnalisis = new AnalisisLaboratorio();
                    nomAnalisis.id_analisis = (int)dr["id_AnalisisLaboratorio"];
                    nomAnalisis.nombre = dr["nombre"].ToString();
                    nomAnalisis.descripcion = dr["descripcion"].ToString(); 
                }

                cn.Close();
                return nomAnalisis;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
            
    }
}
