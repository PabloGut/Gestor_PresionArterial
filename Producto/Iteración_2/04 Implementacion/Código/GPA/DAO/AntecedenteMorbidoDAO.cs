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
    public class AntecedenteMorbidoDAO
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
        public static void registrarAntecedenteMorbido(List<AntecedenteMorbido> antecedentesMorbidos,int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.Open();

                string consulta = @"insert into AntecedentesMorbidos(fechaRegistro,id_tipoAntecedenteMorbido,id_enfermedad_fk,id_operacion_fk,id_traumatismo_fk,cantidadTiempo,id_elementoTiempo_fk,evolucion,tratamiento,id_hc_fk)
                                  values(@fechaRegistro,@idTipoAntecedenteMorbido,@idEnfermedad,@idOperacion,@idTraumatismo,@cantidadTiempo,@idElementoTiempo,@evolucion,@tratamiento,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AntecedenteMorbido antecedente in antecedentesMorbidos)
                {
                    cmd.Parameters.AddWithValue("@fechaRegistro", antecedente.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idTipoAntecedenteMorbido", antecedente.id_tipoAntecedenteMorbido);

                    if (antecedente.id_enfermedad == 0)
                    {
                        cmd.Parameters.AddWithValue("@idEnfermedad", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idEnfermedad", antecedente.id_enfermedad);
                    }
                    if (antecedente.id_operacion == 0)
                    {
                        cmd.Parameters.AddWithValue("@idOperacion", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idOperacion", antecedente.id_operacion);
                    }
                    if (antecedente.id_traumatismo == 0)
                    {
                        cmd.Parameters.AddWithValue("@idTraumatismo", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idTraumatismo", antecedente.id_traumatismo);
                    }
                    
                    cmd.Parameters.AddWithValue("@cantidadTiempo", antecedente.cantidadTiempo);
                    cmd.Parameters.AddWithValue("@idElementoTiempo", antecedente.id_elementoTiempo);

                    if (antecedente.evolución.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@evolucion",DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@evolucion", antecedente.evolución);
                    }

                    if (antecedente.tratamiento.Equals("No precisa") == true)
                    {
                        cmd.Parameters.AddWithValue("@tratamiento", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@tratamiento", antecedente.tratamiento);
                    }

                    cmd.Parameters.AddWithValue("@idHc", idHc);

                    cmd.ExecuteNonQuery();
                }
                cn.Close();
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
