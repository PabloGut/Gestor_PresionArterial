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
    public class PulsoArterialDAO
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
        public static int registrarPulsoArterial(PulsoArterial pulsoArterial)
        {

            SqlTransaction tran = null;

            string consulta = "insert into PulsoArterial(auscultacion,observaciones) values (@auscultacion,@observaciones)";

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();

                if (string.IsNullOrEmpty(pulsoArterial.auscultacion) == true)
                {
                    cmd.Parameters.AddWithValue("@auscultacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@auscultacion", pulsoArterial.auscultacion);
                }

                if (string.IsNullOrEmpty(pulsoArterial.observaciones) == true)
                {
                    cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@observaciones", pulsoArterial.observaciones);
                }

                
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);
                pulsoArterial.id_pulsoArterial =(int)cmd1.ExecuteScalar();

                foreach (DetallePulsoArterial detalle in pulsoArterial.detalles)
                {
                    detalle.id_pulsoArterial = pulsoArterial.id_pulsoArterial;
                    DetallePulsoArterialDAO.registrarDetallesPulsoArterial(detalle,tran,cn);
                }

                tran.Commit();
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return pulsoArterial.id_pulsoArterial;

        }
    }
}
