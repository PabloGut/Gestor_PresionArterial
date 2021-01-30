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
    public class DetalleValorReferenciaDAO
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
        public static void registrartDetalleValorReferencia(DetalleValorReferenciaLaboratorio detalle, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into DetalleValorReferencia(descripcion,valorDesde,valorHasta,id_unidadMedida_fk,id_detalleItemLaboratorio_fk)
                                values(@descripcion,@valorDesde,@valorHasta,@id_unidadMedida_fk,@id_detalleItemLaboratorio_fk)";

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@descripcion", detalle.descripcion);
                cmd.Parameters.AddWithValue("@valorDesde",detalle.valorDesde);
                cmd.Parameters.AddWithValue("@valorHasta", detalle.valorHasta);
                if (detalle.idUnidadMedida == -1)
                {
                    cmd.Parameters.AddWithValue("@id_unidadMedida_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_unidadMedida_fk", detalle.idUnidadMedida);
                }
                cmd.Parameters.AddWithValue("@id_detalleItemLaboratorio_fk", detalle.idDetalleItemLaboratorio);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error: " + e.Message);
            }
                              
        }
    }
}
