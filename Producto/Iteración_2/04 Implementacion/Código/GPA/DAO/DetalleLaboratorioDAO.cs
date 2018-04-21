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
    public class DetalleLaboratorioDAO
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
        public static void insertDetalleLaboratorio(DetalleLaboratorio detalle, SqlConnection cn ,SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            string consulta = @"insert into DetalleLaboratorio(valorResultado,id_unidadMedida_fk,id_itemEstudioLaboratorio_fk,id_laboratorio_fk)
                                values(@resultado,@idUnidadMedida,@idItemEstudioLaboratorio,@idLaboratorio)";

            try
            {
                cmd.Parameters.AddWithValue("@resultado", detalle.valorResultado);
                cmd.Parameters.AddWithValue("@idUnidadMedida", detalle.idUnidadMedida);
                cmd.Parameters.AddWithValue("@idItemEstudioLaboratorio", detalle.itemEstudioLaboratorio.id_itemEstudioLaboratorio);//Falta buscar el id
                cmd.Parameters.AddWithValue("@idLaboratorio", detalle.idLaboratorio);

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    }
}
