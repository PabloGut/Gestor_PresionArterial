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
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into AntecedentesMorbidos(fechaRegistro,id_tipoAntecedenteMorbido_fk,id_enfermedad_fk,id_operacion_fk,id_traumatismo_fk,cantidadTiempo,id_elementoTiempo_fk,evolucion,tratamiento,id_hc_fk)
                                  values(@fechaRegistro,@idTipoAntecedenteMorbido,@idEnfermedad,@idOperacion,@idTraumatismo,@cantidadTiempo,@idElementoTiempo,@evolucion,@tratamiento,@idHc)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (AntecedenteMorbido antecedente in antecedentesMorbidos)
                {
                    cmd.Parameters.Clear();

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
        public static DataTable mostrarAntecedentesMorbidosDeHc(int idHc)
        {
             setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            
            try
            {

                cn.Open();

                string consulta = @"select am.fechaRegistro as 'Fecha de registro', am.id_tipoAntecedenteMorbido_fk, tam.nombre as 'Tipo de Antecedente Morbido', enf.nombre as 'Nombre de la enfermedad'
                                  from Historia_Clinica hc, AntecedentesMorbidos am, TiposAntecedentesMorbidos tam, Enfermedades enf
                                  where hc.id_hc= am.id_hc_fk and hc.id_hc= @idHc and am.id_tipoAntecedenteMorbido_fk=tam.id_tipoAntecedenteMorbido
                                  and am.id_enfermedad_fk=enf.id_enfermedad";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);
                
                
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("AntecedentesMorbidos");
                da.Fill(dt);
               
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
            return dt;


        }
        
    }
}
