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
    public class SintomaDAO
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
        public static void registrarSintomas(List<Sintoma> sintomas, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();
                string consulta = @"insert into Sintoma(fechaInicioSintoma,cantidadDeTiempo,id_elementoDelTiempo_fk,id_descripcionDelTiempo_fk,id_tipoSintoma_fk,descripcion,id_parteDelCuerpo_fk,haciaDondeIrradia,id_comoSeModifica_fk,id_elementoDeModificacion_fk,id_caracterDolor_fk,observaciones,id_hc_fk,fechaRegistro)
                                  values(@fechaInicioSintoma,@cantidadTiempo,@idElementoTiempo,@idDescripcionTiempo,@idTipoSintoma,@descripcion,@idParteCuerpo,@haciaDondeIrradia,@idComoModifica,@idElementoModificacion,@idCaracterDolor,@observaciones,@idHc,@fechaRegistro)";

                SqlCommand cmd = new SqlCommand();
                cmd.Transaction = tran;
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (Sintoma sintoma in sintomas)
                {
                    cmd.Parameters.Clear();

                    DateTime fecha = Convert.ToDateTime("01/01/0001 0:00:00");

                    if (DateTime.Compare(fecha, sintoma.fechaInicioSintoma) == 0)
                    {
                        cmd.Parameters.AddWithValue("@fechaInicioSintoma", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@fechaInicioSintoma", sintoma.fechaInicioSintoma.ToShortDateString());
                    }
                    if (sintoma.cantidadTiempo == 0)
                    {
                        cmd.Parameters.AddWithValue("@cantidadTiempo", DBNull.Value);
                        cmd.Parameters.AddWithValue("@idElementoTiempo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@cantidadTiempo", sintoma.cantidadTiempo);
                        cmd.Parameters.AddWithValue("@idElementoTiempo", sintoma.id_elementoTiempo);
                    }
                    if (sintoma.id_descripcionDelTiempo == 0)
                    {
                        cmd.Parameters.AddWithValue("@idDescripcionTiempo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idDescripcionTiempo", sintoma.id_descripcionDelTiempo);
                    }
                    
                    cmd.Parameters.AddWithValue("@idTipoSintoma", sintoma.id_tipoSintoma);
                    cmd.Parameters.AddWithValue("@descripcion", sintoma.descripcion);

                    if (sintoma.id_parteCuerpo == 0)
                    {
                        cmd.Parameters.AddWithValue("@idParteCuerpo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idParteCuerpo", sintoma.id_parteCuerpo);
                    }
                    if (sintoma.haciaDondeIrradia.Equals("No precisa")==true)
                    {
                        cmd.Parameters.AddWithValue("@haciaDondeIrradia", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@haciaDondeIrradia", sintoma.haciaDondeIrradia);
                    }
                    if (sintoma.id_modificacionSintoma == 0)
                    {
                        cmd.Parameters.AddWithValue("@idComoModifica", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idComoModifica", sintoma.id_modificacionSintoma);
                    }
                    if (sintoma.id_elementoModificacion == 0)
                    {
                        cmd.Parameters.AddWithValue("@idElementoModificacion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idElementoModificacion", sintoma.id_elementoModificacion);
                    }

                    if (sintoma.id_caracterDolor == 0)
                    {
                        cmd.Parameters.AddWithValue("@idCaracterDolor", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idCaracterDolor", sintoma.id_caracterDolor);
                    }

                    if (sintoma.observaciones.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@observaciones", sintoma.observaciones);
                    }
                    
                    cmd.Parameters.AddWithValue("@idHc", idHc);
                    cmd.Parameters.AddWithValue("@fechaRegistro", sintoma.fechaRegistro.ToShortDateString());

                    cmd.ExecuteNonQuery();
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
                throw new ApplicationException("Error:" + e.Message);
            } 
        }
    }
}
