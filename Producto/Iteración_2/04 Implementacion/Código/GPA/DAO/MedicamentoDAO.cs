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
          * Método para registrar el nombre genérico de un medicamento.
          * Recibe como parámetro un objeto Medicamento y un objeto nombreComercial.
          * Valor de retorno void.
         */
        public static void registrarMedicamento(Medicamento medicamento, NombreComercial nombreComercial)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();

                string consulta = @"insert into Medicamento(nombreGenerico)
                                    values(@nombreGenerico)";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombreGenerico", medicamento.nombreGenerico);

                tran = cn.BeginTransaction();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);

                medicamento.id_medicamento = Convert.ToInt32(cmd1.ExecuteScalar());
                nombreComercial.id_medicamento_fk = medicamento.id_medicamento;

                NombreComercialDAO.registrarNombreComercialDeMedicamento(nombreComercial, cn, tran);

                tran.Commit();
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
        
      

    }
}
