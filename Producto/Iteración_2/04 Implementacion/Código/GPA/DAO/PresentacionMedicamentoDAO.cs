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
    public class PresentacionMedicamentoDAO
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
        * Método para registrar formas de presentacion de medicamentos.
        * Recibe como parámetro un objeto PresentacionMedicamento.
        * Valor de retorno void.
        */
        public static void registrarPresentacionMedicamento(PresentacionMedicamento presentacion)
        {
            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                string consulta = @"insert into PresentacionMedicamento(nombre)
                                    values(@nombre)";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", presentacion.nombre);
                



                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
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
        /*
      * Método para obtener todas las columnas de la tabla PresentacionMedicamento.
      * No recibe datos como parámetro.
      * Retorna una lista de objetos PresentacionMedicamento.
      */
        public static List<PresentacionMedicamento> mostrarPresentacionMedicamento()
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            List<PresentacionMedicamento> presentaciones = new List<PresentacionMedicamento>();
            try
            {
                cn.Open();

                string consulta = "select * from PresentacionMedicamento";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    presentaciones.Add(new PresentacionMedicamento()
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
            return presentaciones;
        }
    }
}
