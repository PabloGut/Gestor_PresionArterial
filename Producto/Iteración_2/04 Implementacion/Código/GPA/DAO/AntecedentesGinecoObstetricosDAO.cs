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

        public static AntecedenteGinecoObstetrico obtenerAntecedenteGinecoObstetrico(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            AntecedenteGinecoObstetrico antecedente = null;
            try
            {
                cn.Open();

                string consulta = "Select * from AntecedentesGinecoObstetricos where id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    antecedente = new AntecedenteGinecoObstetrico();
                    antecedente.id_antecedenteGinecoObstetrico = Convert.ToInt32(dr["id_antecedenteGinecoObstetrico"]);
                    antecedente.fechaRegistro = Convert.ToDateTime(dr["fechaRegistro"].ToString());

                    if (dr["cantidadEmbarazos"] == DBNull.Value)
                    {
                        antecedente.cantidadEmbarazos = 0;
                    }
                    else
                    {
                        antecedente.cantidadEmbarazos = Convert.ToInt32(dr["cantidadEmbarazos"]);
                    }

                    if (dr["cantidadEmbarazosPrematuros"] == DBNull.Value)
                    {
                        antecedente.cantidadEmbarazosPrematuros = 0;
                        antecedente.id_tipoPartoPrematuro=0;
                    }
                    else
                    {
                        antecedente.cantidadEmbarazosPrematuros = Convert.ToInt32(dr["cantidadEmbarazosPrematuros"]);
                        antecedente.id_tipoPartoPrematuro = Convert.ToInt32(dr["id_TipoParto1_fk"]);
                    }

                    if (dr["cantidadEmbarazosATermino"] == DBNull.Value)
                    {
                        antecedente.cantidadEmbarazosATermino = 0;
                        antecedente.id_tipoPartoATermino=0;
                    }
                    else
                    {
                        antecedente.cantidadEmbarazosATermino = Convert.ToInt32(dr["cantidadEmbarazosATermino"]);
                        antecedente.id_tipoPartoATermino = Convert.ToInt32(dr["id_TipoParto2_fk"]);
                    }

                    if (dr["cantidadEmbarazosPosTermino"] == DBNull.Value)
                    {
                        antecedente.cantidadEmbarazosPosTermino =0;
                        antecedente.id_tipoPartoPosTermino = 0;
                    }
                    else
                    {
                        antecedente.cantidadEmbarazosPosTermino = Convert.ToInt32(dr["cantidadEmbarazosPosTermino"]);
                        antecedente.id_tipoPartoPosTermino = Convert.ToInt32(dr["id_TipoParto3_fk"]);
                    }

                    if (dr["id_Aborto_fk"] == DBNull.Value)
                    {
                        antecedente.id_aborto = 0;
                    }
                    else
                    {
                        antecedente.id_aborto = Convert.ToInt32(dr["id_Aborto_fk"]);
                    }
                    
                    antecedente.id_hc = Convert.ToInt32(dr["id_hc_fk"]);
                }
                cn.Close();
                
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return antecedente;
        }
        public static DataTable mostrarAntecedenteGinecoObstetrico(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlDataAdapter da = null;
            DataTable dt = null;
            try
            {
                cn.Open();

                string consulta = @"select ag.fechaRegistro as 'Fecha de registro', ag.cantidadEmbarazos as 'Cantidad de embarazos',CONCAT(ag.cantidadEmbarazosPrematuros,' con parto de tipo ',tp1.nombre) as 'Cantidad de embarazos prematuros', CONCAT(ag.cantidadEmbarazosATermino,' con parto de tipo ',tp2.nombre) as 'Cantidad de embarazos a término',CONCAT(ag.cantidadEmbarazosPosTermino,' con parto de tipo ',tp3.nombre) as 'Cantidad de embarazos postérmino', ab.cantidadTotal as 'Cantidad de abortos',CONCAT(ab.cantidadProvocados,' Aborto/s ',ta2.nombre) as 'Abortos provocados', CONCAT(ab.cantidadEspontaneo,' Aborto/s ',ta1.nombre) as 'Abortos espontaneos', ab.nroHijosVivos as 'Número de hijos vivos',ab.problemasAsociadosAlEmbarazo as 'Problemas asociados al embarazo' 
                                  from Historia_Clinica hc, AntecedentesGinecoObstetricos ag, TipoParto tp1, TipoParto tp2, TipoParto tp3, Aborto ab, TipoAborto ta1,TipoAborto ta2
                                  where hc.id_hc=ag.id_hc_fk and hc.id_hc=@idHc
                                  and ag.id_TipoParto1_fk=tp1.id_TipoParto
                                  and ag.id_TipoParto2_fk=tp2.id_TipoParto
                                  and ag.id_TipoParto3_fk=tp3.id_TipoParto
                                  and ag.id_Aborto_fk=ab.id_aborto
                                  and ab.id_TipoAborto1_fk=ta1.id_TipoAborto
                                  and ab.id_TipoAborto2_fk=ta2.id_TipoAborto";

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@idHc", idHc);


                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                cn.Close();

            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error: " + e.Message);
            }
            return dt;
        }

    }
}
