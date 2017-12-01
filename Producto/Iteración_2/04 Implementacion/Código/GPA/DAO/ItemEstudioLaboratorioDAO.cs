﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using System.Data.SqlClient;
namespace DAO
{
    public class ItemEstudioLaboratorioDAO
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
        public static void registrarItemEstudioLaboratorio(ItemEstudioLaboratorio item)
        {
            setCadenaConexion();

            string consulta = @"insert into ItemEstudioLaboratorio(id_itemLaboratorio_fk)
                                values(@id_itemLaboratorio_fk)";

            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                int idItemLaboratorio=ItemLaboratorioDAO.registrarItemLaboratorio(item.item.nombre,cn,tran);
                cmd.Parameters.AddWithValue("@id_itemLaboratorio_fk", idItemLaboratorio);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('ItemEstudioLaboratorio')", cn, tran);
                item.id_itemEstudioLaboratorio = Convert.ToInt32(cmd1.ExecuteScalar());

                foreach (DetalleItemLaboratorio detalle in item.detalles)
                {
                    detalle.id_ItemEstudioLaboratorio = item.id_itemEstudioLaboratorio;
                    DetalleItemLaboratorioDAO.registrarDetalleItemLaboratorio(detalle, cn, tran);
                }
                tran.Commit();
                cn.Close();

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
    }
}
