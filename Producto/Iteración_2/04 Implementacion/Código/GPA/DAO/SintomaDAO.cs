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
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.Open();

                string consulta = @"insert into Sintoma(fechaInicioSintoma,cantidadDeTiempo,id_elementoDelTiempo_fk,id_descripcionDelTiempo_fk,id_tipoSintoma_fk,descripcion,id_parteDelCuerpo_fk,haciaDondeIrradia,id_comoSeModifica_fk,id_elementoDeModificacion_fk,id_caracterDolor_fk,observaciones,id_hc_fk,fechaRegistro)
                                  values(@fechaInicioSintoma,@cantidadTiempo,@idElementoTiempo,@idDescripcionTiempo,@idTipoSintoma,@descripcion,@idParteCuerpo,@haciaDondeIrradia,@idComoModifica,@idElementoModificacion,@idCaracterDolor,@observaciones,@idHc,@fechaRegistro)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (Sintoma sintoma in sintomas)
                {
                    cmd.Parameters.AddWithValue("@fechaInicioSintoma", sintoma.fechaInicioSintoma);
                    cmd.Parameters.AddWithValue("@cantidadTiempo", sintoma.cantidadTiempo);
                    cmd.Parameters.AddWithValue("@idElementoTiempo", sintoma.id_elementoTiempo);
                    cmd.Parameters.AddWithValue("@idDescripcionTiempo", sintoma.id_descripcionDelTiempo);
                    cmd.Parameters.AddWithValue("@idTipoSintoma", sintoma.id_tipoSintoma);
                    cmd.Parameters.AddWithValue("@descripcion", sintoma.descripcion);
                    cmd.Parameters.AddWithValue("@idParteCuerpo", sintoma.id_parteCuerpo);
                    cmd.Parameters.AddWithValue("@haciaDondeIrradia", sintoma.haciaDondeIrradia);
                    cmd.Parameters.AddWithValue("@idComoModifica", sintoma.id_modificacionSintoma);
                    cmd.Parameters.AddWithValue("@idElementoModificacion", sintoma.id_elementoModificacion);
                    cmd.Parameters.AddWithValue("@idCaracterDolor", sintoma.id_caracterDolor);
                    cmd.Parameters.AddWithValue("@observaciones", sintoma.observaciones);
                    cmd.Parameters.AddWithValue("@idHc", idHc);
                    cmd.Parameters.AddWithValue("@fechaRegistro", sintoma.fechaRegistro);

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
