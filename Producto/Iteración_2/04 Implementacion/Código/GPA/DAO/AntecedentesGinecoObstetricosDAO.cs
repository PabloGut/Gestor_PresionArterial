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
    public class AntecedentesGinecoObstetricosDAO
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
        public static void registrarAntecedentesGinecoObstetricos(AntecedenteGinecoObstetrico antecedentesGinecoObstetricos)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                if (antecedentesGinecoObstetricos.aborto != null)
                {
                    antecedentesGinecoObstetricos.id_aborto = AbortoDAO.registrarAntecedentesAborto(antecedentesGinecoObstetricos.aborto, tran, cn);
                }
                

                string consulta = @"insert into AntecedentesGinecoObstetricos(fechaRegistro,cantidadEmbarazos, cantidadEmbarazosPrematuros, id_TipoParto1_fk, cantidadEmbarazosATermino, id_TipoParto2_fk,cantidadEmbarazosPosTermino,id_TipoParto3_fk,id_Aborto_fk,id_hc_fk)
                                  values(@fechaRegistro,@cantidadEmbarazos,@cantidadEmbarazosPrematuros,@idTipoParto1,@cantidadEmbarazosATermino,@idTipoParto2,@cantidadEmbarazosPosTermino,@idTipoParto3,@idAborto,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@fechaRegistro", antecedentesGinecoObstetricos.fechaRegistro);
                cmd.Parameters.AddWithValue("@cantidadEmbarazos", antecedentesGinecoObstetricos.cantidadEmbarazos);

                if (antecedentesGinecoObstetricos.cantidadEmbarazosPrematuros == 0)
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosPrematuros", DBNull.Value);
                    cmd.Parameters.AddWithValue("@idTipoParto1", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosPrematuros", antecedentesGinecoObstetricos.cantidadEmbarazosPrematuros);
                    cmd.Parameters.AddWithValue("@idTipoParto1", antecedentesGinecoObstetricos.id_tipoPartoPrematuro);
                }

                if (antecedentesGinecoObstetricos.cantidadEmbarazosATermino == 0)
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosATermino", DBNull.Value);
                    cmd.Parameters.AddWithValue("@idTipoParto2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosATermino", antecedentesGinecoObstetricos.cantidadEmbarazosATermino);
                    cmd.Parameters.AddWithValue("@idTipoParto2", antecedentesGinecoObstetricos.id_tipoPartoATermino);
                }

                if (antecedentesGinecoObstetricos.cantidadEmbarazosPosTermino == 0)
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosPosTermino", DBNull.Value);
                    cmd.Parameters.AddWithValue("@idTipoParto3", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cantidadEmbarazosPosTermino", antecedentesGinecoObstetricos.cantidadEmbarazosPosTermino);
                    cmd.Parameters.AddWithValue("@idTipoParto3", antecedentesGinecoObstetricos.id_tipoPartoPosTermino);
                }
               
                
                if (antecedentesGinecoObstetricos.id_aborto == 0)
                {
                    cmd.Parameters.AddWithValue("@idAborto", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idAborto", antecedentesGinecoObstetricos.id_aborto);
                }
                cmd.Parameters.AddWithValue("@idHc", antecedentesGinecoObstetricos.id_hc);


                cmd.ExecuteNonQuery();
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
                throw new ApplicationException("Error:" + e.Message);
            }
        }
    }
}
