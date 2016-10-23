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
    public class ProgramacionMedicamentoDAO
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
        public static void registrarProgramacionMedicamento(ProgramacionMedicamento programacion, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into ProgramacionMedicamento(id_especifiacionMedicamento_fk,id_medicamento_fk,id_frecuencia_fk,fechaDesde,fechaHasta,
                                  id_momentoDia1_fk,cantidadNumerador1,cantidadDenominador1,id_presentacionMedicamento1_fk,hora1,
                                  id_momentoDia2_fk,cantidadNumerador2,cantidadDenominador2,id_presentacionMedicamento2_fk,hora2,
                                  id_momentoDia3_fk,cantidadNumerador3,cantidadDenominador3,id_presentacionMedicamento3_fk,hora3,
                                  motivoConsumo,cantidadTiempoConsumo,id_elementoTiempo1_fk,motivoCancelacionConsumo,tiempoDeCancelacion,id_elemenoTiempo2_fk,
                                  automedicado,id_estado_fk,examenGeneral)
                                  values(@id_especifiacionMedicamento_fk,@id_medicamento_fk,@id_frecuencia_fk,@fechaDesde,@fechaHasta,
                                  @id_momentoDia1_fk,@cantidadNumerador1,cantidadDenominador1,id_presentacionMedicamento1_fk,hora1,
                                  @id_momentoDia2_fk,@cantidadNumerador2,cantidadDenominador2,id_presentacionMedicamento2_fk,hora2,  
                                  @id_momentoDia3_fk,@cantidadNumerador3,cantidadDenominador3,id_presentacionMedicamento3_fk,hora3,
                                  @motivoConsumo,@cantidadTiempoConsumo,@id_elementoTiempo1_fk,@motivoCancelacionConsumo,@tiempoDeCancelacion,@id_elementoTiempo2_fk,
                                  @automedicado,@id_estado_fk,@idExamenGeneral)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@id_especifiacionMedicamento_fk", programacion.id_especificacionMedicamento);
                cmd.Parameters.AddWithValue("@id_medicamento_fk", programacion.id_medicamento);
                cmd.Parameters.AddWithValue("@id_frecuencia_fk", programacion.id_frecuencia);
                cmd.Parameters.AddWithValue("@fechaDesde", programacion.fechaDesde);
                cmd.Parameters.AddWithValue("@fechaHasta", programacion.fechaHasta);
                cmd.Parameters.AddWithValue("@id_momentoDia1_fk", programacion.id_momentoDia1);
                cmd.Parameters.AddWithValue("@cantidadNumerador1", programacion.cantidad1Numerador);
                cmd.Parameters.AddWithValue("@cantidadDenominador1", programacion.cantidad1Denominador);
                cmd.Parameters.AddWithValue("@id_presentacionMedicamento1_fk", programacion.id_presentacionMedicamento1);
                cmd.Parameters.AddWithValue("@hora1", programacion.hora1);

                cmd.Parameters.AddWithValue("@id_momentoDia2_fk", programacion.id_momentoDia2);
                cmd.Parameters.AddWithValue("@cantidadNumerador2", programacion.cantidad2Numerador);
                cmd.Parameters.AddWithValue("@cantidadDenominador2", programacion.cantidad2Denominador);
                cmd.Parameters.AddWithValue("@id_presentacionMedicamento2_fk", programacion.id_presentacionMedicamento2);
                cmd.Parameters.AddWithValue("@hora2", programacion.hora2);

                cmd.Parameters.AddWithValue("@id_momentoDia3_fk", programacion.id_momentoDia3);
                cmd.Parameters.AddWithValue("@cantidadNumerador3", programacion.cantidad3Numerador);
                cmd.Parameters.AddWithValue("@cantidadDenominador3", programacion.cantidad3Denominador);
                cmd.Parameters.AddWithValue("@id_presentacionMedicamento3_fk", programacion.id_presentacionMedicamento3);
                cmd.Parameters.AddWithValue("@hora3", programacion.hora3);

                cmd.Parameters.AddWithValue("@motivoConsumo", programacion.motivoConsumo);
                cmd.Parameters.AddWithValue("@cantidadTiempoConsumo", programacion.cantidadTiempoConsumo);
                cmd.Parameters.AddWithValue("@id_elementoTiempo1_fk", programacion.id_elementoTiempo1);
                cmd.Parameters.AddWithValue("@motivoCancelacionConsumo", programacion.motivoCancelacion);
                cmd.Parameters.AddWithValue("@id_elementoTiempo2_fk", programacion.id_elementoTiempo2);
                cmd.Parameters.AddWithValue("@automedicado", programacion.automedicamento);
                cmd.Parameters.AddWithValue("@id_estado_fk", programacion.id_estado);
                cmd.Parameters.AddWithValue("@idExamenGeneral", programacion.id_examenGeneral);

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);
                programacion.id_programacionMedicamento = Convert.ToInt32(cmd.ExecuteScalar());
                
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
