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
    public class DetalleItemLaboratorioDAO
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
        public static void registrarDetalleItemLaboratorio(DetalleItemLaboratorio detalleItem, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into DetalleItemLaboratorio(nombre, valorDesde, valorHasta, id_unidadMedida_fk, id_item_fk)
                                values(@nombre,@valorDesde,@valorHasta,@id_unidadMedida_fk,@id_item_fk)";

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@nombre", detalleItem.nombre);
                cmd.Parameters.AddWithValue("@valorDesde", detalleItem.valorDesde);
                cmd.Parameters.AddWithValue("@valorHasta", detalleItem.valorHasta);

                if (detalleItem.id_unidadMedida == -1)
                {
                    cmd.Parameters.AddWithValue("@id_unidadMedida_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_unidadMedida_fk", detalleItem.id_unidadMedida);
                }

                cmd.Parameters.AddWithValue("@id_item_fk", detalleItem.id_ItemEstudioLaboratorio);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('DetalleItemLaboratorio')", cn, tran);
                detalleItem.id_detalleItemLaboratorio = Convert.ToInt32(cmd1.ExecuteScalar());
                
                if (detalleItem.detalle != null)
                {
                    foreach (DetalleValorReferenciaLaboratorio detalle in detalleItem.detalle)
                    {
                        detalle.idDetalleItemLaboratorio = detalleItem.id_detalleItemLaboratorio;
                        DetalleValorReferenciaDAO.registrartDetalleValorReferencia(detalle, cn, tran);
                    }
                }

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                    tran.Rollback();
                }
                throw new Exception("Error al insertar: " + e.Message);
            }
        }
        public static List<DetalleItemLaboratorio> obtenerIdDetalleItemLaboratorio(int idDetalleItemLaboratorio)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            SqlDataReader dr = null;

            List<DetalleItemLaboratorio> detalles = new List<DetalleItemLaboratorio>();

            string consulta = @"select d.id_detalleItemLaboratorio,nombre
                                from ItemEstudioLaboratorio i, DetalleItemLaboratorio d
                                where i.id_itemEstudioLaboratorio=d.id_item_fk
                                and d.id_item_fk=@idItemEstudioLaboratorio";

            cmd.Parameters.AddWithValue("@idItemEstudioLaboratorio", idDetalleItemLaboratorio);

            try
            {
                cn.Open();

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    detalles.Add(new DetalleItemLaboratorio()
                    {
                        id_detalleItemLaboratorio=(int)dr["id_detalleItemLaboratorio"],
                        nombre= dr["nombre"].ToString()
                    });
                }

                cn.Close();
                return detalles;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new Exception("Error: " + e.Message);
            }
        }
        public static void insertarDetalleResultadoEstudio(DetalleResultadoEstudio detalleItem, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into DetalleResultadoEstudio(id_detalleLaboratorio,id_detalleItemLaboratorio, valorResultado, id_unidadMedida)
                                values(@idDetalleLaboratorio,@idDetalleItemLaboratorio,@valorResultado,@idUnidadMedida)";

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idDetalleLaboratorio", detalleItem.idDetalleLaboratorio);
                cmd.Parameters.AddWithValue("@idDetalleItemLaboratorio", detalleItem.idDetalleItemLaboratorio);
                cmd.Parameters.AddWithValue("@valorResultado", detalleItem.valorResultado);

                if (detalleItem.idUnidadMedida == -1)
                {
                    cmd.Parameters.AddWithValue("@idUnidadMedida", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idUnidadMedida", detalleItem.idUnidadMedida);
                }

                //cmd.Parameters.AddWithValue("@id_item_fk", detalleItem.idDetalleItemLaboratorio);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
