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
    public class MedicamentoDAO
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
         * Método para obtener el nombre genérico de todos los medicamentos.
         * No recibe parámetros.
         * Retorna una lista de objetos Medicamento.
         */
        public static List<Medicamento> mostrarNombreMedicamentos()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<Medicamento> medicamentos = new List<Medicamento>();
            try
            {
                cn.Open();

                string consulta = "select id_medicamento, nombreGenerico from Medicamento";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    medicamentos.Add(new Medicamento()
                    {
                        id_medicamento= (int)dr["id_medicamento"],
                        nombreGenerico = dr["nombreGenerico"].ToString()
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
            return medicamentos;
        }
        /*
       * Método para registrar Medicamentos.
       * Recibe como parámetro un objeto Medicamento.
       * Valor de retorno void.
       */
        public static void registrarMedicamento(Medicamento medicamento)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = @"insert into Medicamento(nombreGenerico,concentracion,id_unidadMedida_fk,id_formaAdministracion_fk,id_presentacionMedicamento_fk
                                    values(@nombreGenerico,@concentracion,@idUnidadMedida,@idFormaAdministracion,@idPresentacionMedicamento)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreGenerico", medicamento.nombreGenerico);
                cmd.Parameters.AddWithValue("@concentracion", medicamento.concentracion);
                cmd.Parameters.AddWithValue("@idUnidadMedida", medicamento.id_unidadMedida);
                cmd.Parameters.AddWithValue("@idFormaAdministracion", medicamento.id_formaAdministración);
                cmd.Parameters.AddWithValue("@idPresentacionMedicamento", medicamento.id_presentacion);

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
            cn.Close();
        }
    }
}
