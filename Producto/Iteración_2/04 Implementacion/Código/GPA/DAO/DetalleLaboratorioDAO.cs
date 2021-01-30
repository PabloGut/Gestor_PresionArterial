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

                if(detalle.idUnidadMedida ==0)
                    cmd.Parameters.AddWithValue("@idUnidadMedida", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idUnidadMedida", detalle.idUnidadMedida);

                cmd.Parameters.AddWithValue("@idItemEstudioLaboratorio", detalle.idItemLaboratorio);//Falta buscar el id
                cmd.Parameters.AddWithValue("@idLaboratorio", detalle.idLaboratorio);

                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('DetalleLaboratorio')", cn, tran);

                detalle.idDetalleLaboratorio = Convert.ToInt32(cmd1.ExecuteScalar());
                //insertar los detallesResultados
                foreach (DetalleResultadoEstudio detalleResultado in detalle.detalleResultadoEstudios)
                {
                    detalleResultado.idDetalleLaboratorio = detalle.idDetalleLaboratorio;
                    DetalleItemLaboratorioDAO.insertarDetalleResultadoEstudio(detalleResultado, cn, tran);
                }

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
        public static void insertarDetalleLaboratorio(DetalleLaboratorio resultado, SqlConnection cn, SqlTransaction tran)
        {
            SqlCommand cmd = new SqlCommand();

            string consulta = @"insert into DetalleLaboratorio(id_unidadMedida_fk,id_itemEstudioLaboratorio_fk,id_laboratorio_fk)
                                values(@idUnidadMedida,@idItemLaboratorio,@idLaboratorio)";
                                
            try
            {
               
                if(resultado.idUnidadMedida == 0)
                    cmd.Parameters.AddWithValue("@idUnidadMedida", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@idUnidadMedida", resultado.idUnidadMedida);

                cmd.Parameters.AddWithValue("@idItemLaboratorio", resultado.idItemLaboratorio);
                cmd.Parameters.AddWithValue("@idLaboratorio", resultado.idLaboratorio);



                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('DetalleLaboratorio')", cn, tran);

                resultado.idDetalleLaboratorio = Convert.ToInt32(cmd1.ExecuteScalar());
                //insertar los detallesResultados
                foreach (DetalleResultadoEstudio detalle in resultado.detalleResultadoEstudios)
                {
                    detalle.idDetalleLaboratorio= resultado.idDetalleLaboratorio;
                    DetalleItemLaboratorioDAO.insertarDetalleResultadoEstudio(detalle, cn, tran);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
