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
    public class DejoDeFumarDAO
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
        public static void registrarDejoDeFumar(DejoDeFumar dejoFumar, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into DejoDeFumar(cantidadTiempo,id_elementoDelTiempo_fk,id_descripcionTiempo_fk, cantidadFumaba, id_elementoQueFuma_fk, id_componenteTiempo_fk, id_habitoTabaquismo_fk)
                                  values(@cantidadDeTiempo,@idElementoDelTiempo,@idDescripcionDelTiempo,@cantidadFumaba,@idElementoQueFuma,@idComponenteTiempo,@idHabitoTabaquismo)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                if (dejoFumar.cantidad == 0)
                {
                    cmd.Parameters.AddWithValue("@cantidadDeTiempo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@idElementoDelTiempo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cantidadDeTiempo", dejoFumar.cantidad);
                    cmd.Parameters.AddWithValue("@idElementoDelTiempo", dejoFumar.id_elementoTiempo);
                }
                if (dejoFumar.id_descripcionTiempo == 0)
                {
                    cmd.Parameters.AddWithValue("@idDescripcionDelTiempo",DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idDescripcionDelTiempo", dejoFumar.id_descripcionTiempo);
                }
                
                cmd.Parameters.AddWithValue("@cantidadFumaba", dejoFumar.cantidadFumaba);
                cmd.Parameters.AddWithValue("@idElementoQueFuma", dejoFumar.id_elementoQueFuma);
                cmd.Parameters.AddWithValue("@idComponenteTiempo", dejoFumar.id_componenteTiempo);
                cmd.Parameters.AddWithValue("@idHabitoTabaquismo", dejoFumar.id_habitoTabaquismo);

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
