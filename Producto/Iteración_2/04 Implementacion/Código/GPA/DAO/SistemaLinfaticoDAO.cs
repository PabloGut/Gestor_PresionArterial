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
    public class SistemaLinfaticoDAO
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
        public static void registrarSistemaLinfatico(List<SistemaLinfatico> territoriosExaminados, int idExamenGeneral)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {
                cn.Open();

                string consulta = @"insert into SistemaLinfatico(id_ubicacion_fk,id_tamaño_fk, aproximacionNumérica, id_consistencia_fk,id_examenGenera_fk,descripcion,sePalpaConLimitesPrecisos,tiendeAConfluir,sePuedeMovilizarConDedos,adheridaPlanosProfundos,procesoInflamatorioComprometePiel,lesion,observaciones)
                                  values(@id_ubicacion_fk,@id_tamaño_fk,@aproximacionNumérica,@id_consistencia_fk,@id_examenGeneral_fk,@descripcion,@sePalpaConLimitesPrecisos,@tiendeAConfluir,@sePuedeMovilizarConDedos,@adheridaPlanosProfundos,@procesoInflamatorioComprometePiel,@lesion,@observaciones)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (SistemaLinfatico territorio in territoriosExaminados)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@id_ubicacion_fk", territorio.id_ubicacion);
                    cmd.Parameters.AddWithValue("@id_tamaño_fk", territorio.id_tamaño);
                    cmd.Parameters.AddWithValue("@aproximacionNumérica", territorio.aproximacionNumerica);
                    cmd.Parameters.AddWithValue("@id_consistencia_fk", territorio.id_consistencia);
                    cmd.Parameters.AddWithValue("@id_examenGeneral_fk", territorio.id_examenGeneral);
                    cmd.Parameters.AddWithValue("@descripcion", territorio.descripcion);
                    cmd.Parameters.AddWithValue("@sePalpaConLimitesPrecisos", territorio.sePalpaConLimitesPrecisos);
                    cmd.Parameters.AddWithValue("@tiendeAConfluir", territorio.tiendeAConfluir);
                    cmd.Parameters.AddWithValue("@sePuedeMovilizarConDedos", territorio.sePuedeMovilizarConDedos);
                    cmd.Parameters.AddWithValue("@adheridaPlanosProfundos", territorio.adheridaPlanosProfundos);
                    cmd.Parameters.AddWithValue("@procesoInflamatorioComprometePiel", territorio.procesoInflamatorioComprometeLaPiel);
                    cmd.Parameters.AddWithValue("@lesion", territorio.lesion);
                    cmd.Parameters.AddWithValue("@observaciones", territorio.observaciones);

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
        public static void registrarSistemaLinfatico(SistemaLinfatico territorio, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                
                string consulta = @"insert into SistemaLinfatico(id_ubicacion_fk,id_tamaño_fk, aproximacionNumerica, id_consistencia_fk,id_examenGeneral_fk,descripcion,sePalpaConLimitesPrecisos,tiendeAConfluir,sePuedeMovilizarConDedos,adheridaPlanosProfundos,procesoInflamatorioComprometePiel,lesion,observaciones)
                                  values(@id_ubicacion_fk,@id_tamaño_fk,@aproximacionNumérica,@id_consistencia_fk,@id_examenGeneral_fk,@descripcion,@sePalpaConLimitesPrecisos,@tiendeAConfluir,@sePuedeMovilizarConDedos,@adheridaPlanosProfundos,@procesoInflamatorioComprometePiel,@lesion,@observaciones)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.Text;


                if (territorio.id_ubicacion > 0)
                {
                    cmd.Parameters.AddWithValue("@id_ubicacion_fk", territorio.id_ubicacion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_ubicacion_fk", DBNull.Value);
                }
                if (territorio.id_tamaño > 0)
                {
                    cmd.Parameters.AddWithValue("@id_tamaño_fk", territorio.id_tamaño);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_tamaño_fk", DBNull.Value);
                }
                if (territorio.aproximacionNumerica > 0)
                {
                    cmd.Parameters.AddWithValue("@aproximacionNumérica", territorio.aproximacionNumerica);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@aproximacionNumérica", DBNull.Value);
                }
                if (territorio.id_consistencia>0)
                {
                    cmd.Parameters.AddWithValue("@id_consistencia_fk", territorio.id_consistencia);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@aproximacionNumérica", DBNull.Value);
                }
                
                cmd.Parameters.AddWithValue("@id_examenGeneral_fk", territorio.id_examenGeneral);

                if (!string.IsNullOrEmpty(territorio.descripcion))
                {
                    cmd.Parameters.AddWithValue("@descripcion", territorio.descripcion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@descripcion", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.sePalpaConLimitesPrecisos))
                {
                    cmd.Parameters.AddWithValue("@sePalpaConLimitesPrecisos", territorio.sePalpaConLimitesPrecisos);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sePalpaConLimitesPrecisos", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.tiendeAConfluir))
                {
                    cmd.Parameters.AddWithValue("@tiendeAConfluir", territorio.tiendeAConfluir);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@tiendeAConfluir", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.sePuedeMovilizarConDedos))
                {
                    cmd.Parameters.AddWithValue("@sePuedeMovilizarConDedos", territorio.sePuedeMovilizarConDedos);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@sePuedeMovilizarConDedos", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.adheridaPlanosProfundos))
                {
                    cmd.Parameters.AddWithValue("@adheridaPlanosProfundos", territorio.adheridaPlanosProfundos);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@adheridaPlanosProfundos", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.procesoInflamatorioComprometeLaPiel))
                {
                    cmd.Parameters.AddWithValue("@procesoInflamatorioComprometePiel", territorio.procesoInflamatorioComprometeLaPiel);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@procesoInflamatorioComprometePiel", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.lesion))
                {
                    cmd.Parameters.AddWithValue("@lesion", territorio.lesion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@lesion", DBNull.Value);
                }
                if (!string.IsNullOrEmpty(territorio.observaciones))
                {
                    cmd.Parameters.AddWithValue("@observaciones", territorio.observaciones);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@observaciones", DBNull.Value);
                }
                cmd.ExecuteNonQuery();
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
