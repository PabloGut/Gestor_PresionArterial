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
    public class DetallePulsoArterialDAO
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
        public static void registrarDetallesPulsoArterial(DetallePulsoArterial detalle, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into DetallePulsoArterial(id_pulsoArterial,id_derecha_fk, id_izquierda_fk, id_pulso_fk)
                                  values(@id_pulsoArterial,@id_derecha_fk,@id_izquierda_fk,@id_pulso_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;


                cmd.Parameters.AddWithValue("@id_pulsoArterial", detalle.id_pulsoArterial);
                cmd.Parameters.AddWithValue("@id_derecha_fk", detalle.id_derecha);
                cmd.Parameters.AddWithValue("@id_izquierda_fk", detalle.id_izquierda);
                cmd.Parameters.AddWithValue("@id_pulso_fk", detalle.id_pulso);

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
            
        }
    }
}
