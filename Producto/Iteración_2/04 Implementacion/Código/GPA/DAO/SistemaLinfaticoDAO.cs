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
