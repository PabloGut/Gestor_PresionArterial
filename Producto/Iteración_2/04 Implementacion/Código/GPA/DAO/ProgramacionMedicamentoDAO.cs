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
                string consulta = @"insert into ProgramacionMedicamento(id_especificacionMedicamento_fk,id_medicamento_fk,id_frecuencia_fk,fechaDesde,fechaHasta,
                                  id_momentoDia1_fk,cantidadNumerador1,cantidadDenominador1,id_presentacionMedicamento1_fk,hora1,
                                  id_momentoDia2_fk,cantidadNumerador2,cantidadDenominador2,id_presentacionMedicamento2_fk,hora2, 
                                  id_momentoDia3_fk,cantidadNumerador3,cantidadDenominador3,id_presentacionMedicamento3_fk,hora3, 
                                  motivoConsumo,cantidadTiempoConsumo,id_elementoDelTiempo1_fk,motivoCancelacionConsumo,tiempoDeCancelacion,id_elementoDelTiempo2_fk, automedicado,id_estado_fk,id_examenGeneral_fk) 
                                  values(@id_especificacionMedicamento_fk,@id_medicamento_fk,@id_frecuencia_fk,@fechaDesde,@fechaHasta,
                                  @id_momentoDia1_fk,@cantidadNumerador1,@cantidadDenominador1,@id_presentacionMedicamento1_fk,@hora1,
                                  @id_momentoDia2_fk,@cantidadNumerador2,@cantidadDenominador2,@id_presentacionMedicamento2_fk,@hora2,
                                  @id_momentoDia3_fk,@cantidadNumerador3,@cantidadDenominador3,@id_presentacionMedicamento3_fk,@hora3,
                                  @motivoConsumo,@cantidadTiempoConsumo,@id_elementoDelTiempo1_fk,@motivoCancelacionConsumo,@tiempoDeCancelacion,@id_elementoDelTiempo2_fk, @automedicado,@id_estado_fk,@idExamenGeneral)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@id_especificacionMedicamento_fk", programacion.id_especificacionMedicamento);
                cmd.Parameters.AddWithValue("@id_medicamento_fk", programacion.id_medicamento);
                cmd.Parameters.AddWithValue("@id_frecuencia_fk", programacion.id_frecuencia);

                DateTime fecha = Convert.ToDateTime("01/01/0001 0:00:00");

                if (DateTime.Compare(fecha,programacion.fechaDesde)==0)
                {
                    cmd.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fechaDesde", programacion.fechaDesde);
                }
                if (DateTime.Compare(fecha,programacion.fechaHasta)==0)
                {
                    cmd.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fechaHasta", programacion.fechaHasta);
                }

                if (programacion.id_momentoDia1 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia1_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento1_fk",DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora1", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia1_fk", programacion.id_momentoDia1);
                    cmd.Parameters.AddWithValue("@cantidadNumerador1", programacion.cantidad1Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador1", programacion.cantidad1Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento1_fk", programacion.id_presentacionMedicamento1);
                    cmd.Parameters.AddWithValue("@hora1", programacion.hora1);
                }


                if (programacion.id_momentoDia2 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia2_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento2_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia2_fk", programacion.id_momentoDia2);
                    cmd.Parameters.AddWithValue("@cantidadNumerador2", programacion.cantidad2Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador2", programacion.cantidad2Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento2_fk", programacion.id_presentacionMedicamento2);
                    cmd.Parameters.AddWithValue("@hora2", programacion.hora2);
                }

                if (programacion.id_momentoDia3 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia3_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador3", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador3", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento3_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora3", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia3_fk", programacion.id_momentoDia3);
                    cmd.Parameters.AddWithValue("@cantidadNumerador3", programacion.cantidad3Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador3", programacion.cantidad3Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento3_fk", programacion.id_presentacionMedicamento3);
                    cmd.Parameters.AddWithValue("@hora3", programacion.hora3);
                }

                if (string.IsNullOrEmpty(programacion.motivoConsumo)== true)
                {
                    cmd.Parameters.AddWithValue("@motivoConsumo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoConsumo", programacion.motivoConsumo);
                }

                if (programacion.cantidadTiempoConsumo == 0)
                {
                    cmd.Parameters.AddWithValue("@cantidadTiempoConsumo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_elementoDelTiempo1_fk", DBNull.Value);
                    
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cantidadTiempoConsumo", programacion.cantidadTiempoConsumo);
                    cmd.Parameters.AddWithValue("@id_elementoDelTiempo1_fk", programacion.id_elementoTiempo1);
                }

                if (string.IsNullOrEmpty(programacion.motivoCancelacion) == true)
                {
                    cmd.Parameters.AddWithValue("@motivoCancelacionConsumo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoCancelacionConsumo", programacion.motivoCancelacion);
                }

                if (programacion.id_elementoTiempo2 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_elementoDelTiempo2_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tiempoDeCancelacion", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_elementoDelTiempo2_fk", programacion.id_elementoTiempo2);
                    cmd.Parameters.AddWithValue("@tiempoDeCancelacion", programacion.cantidadCancelacion);
                }
                
                cmd.Parameters.AddWithValue("@automedicado", programacion.automedicamento);
                cmd.Parameters.AddWithValue("@id_estado_fk", programacion.id_estado);

                if (programacion.id_examenGeneral == 0)//Se debería quitar id_examengeneral__fk de la tabla porque no se usa.
                {
                    cmd.Parameters.AddWithValue("@idExamenGeneral", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@idExamenGeneral", programacion.id_examenGeneral);
                }
                

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);
                programacion.id_programacionMedicamento = Convert.ToInt32(cmd1.ExecuteScalar());
                
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
        public static void registrarTratamientoProgramacionMedicamento(ProgramacionMedicamento programacion, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"insert into ProgramacionMedicamento(id_especificacionMedicamento_fk,id_medicamento_fk,id_frecuencia_fk,fechaDesde,
                                  id_momentoDia1_fk,cantidadNumerador1,cantidadDenominador1,id_presentacionMedicamento1_fk,hora1,
                                  id_momentoDia2_fk,cantidadNumerador2,cantidadDenominador2,id_presentacionMedicamento2_fk,hora2, 
                                  id_momentoDia3_fk,cantidadNumerador3,cantidadDenominador3,id_presentacionMedicamento3_fk,hora3, 
                                  motivoConsumo,id_estado_fk,id_tratamiento_fk) 
                                  values(@id_especificacionMedicamento_fk,@id_medicamento_fk,@id_frecuencia_fk,@fechaDesde,
                                  @id_momentoDia1_fk,@cantidadNumerador1,@cantidadDenominador1,@id_presentacionMedicamento1_fk,@hora1,
                                  @id_momentoDia2_fk,@cantidadNumerador2,@cantidadDenominador2,@id_presentacionMedicamento2_fk,@hora2,
                                  @id_momentoDia3_fk,@cantidadNumerador3,@cantidadDenominador3,@id_presentacionMedicamento3_fk,@hora3,
                                  @motivoConsumo,@id_estado_fk,@id_tratamiento_fk)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@id_especificacionMedicamento_fk", programacion.id_especificacionMedicamento);
                cmd.Parameters.AddWithValue("@id_medicamento_fk", programacion.id_medicamento);
                cmd.Parameters.AddWithValue("@id_frecuencia_fk", programacion.id_frecuencia);

                DateTime fecha = Convert.ToDateTime("01/01/0001 0:00:00");

                if (DateTime.Compare(fecha, programacion.fechaDesde) == 0)
                {
                    cmd.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@fechaDesde", programacion.fechaDesde);
                }

                if (programacion.id_momentoDia1 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia1_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador1", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento1_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora1", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia1_fk", programacion.id_momentoDia1);
                    cmd.Parameters.AddWithValue("@cantidadNumerador1", programacion.cantidad1Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador1", programacion.cantidad1Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento1_fk", programacion.id_presentacionMedicamento1);
                    cmd.Parameters.AddWithValue("@hora1", programacion.hora1);
                }


                if (programacion.id_momentoDia2 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia2_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador2", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento2_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora2", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia2_fk", programacion.id_momentoDia2);
                    cmd.Parameters.AddWithValue("@cantidadNumerador2", programacion.cantidad2Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador2", programacion.cantidad2Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento2_fk", programacion.id_presentacionMedicamento2);
                    cmd.Parameters.AddWithValue("@hora2", programacion.hora2);
                }

                if (programacion.id_momentoDia3 == 0)
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia3_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadNumerador3", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cantidadDenominador3", DBNull.Value);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento3_fk", DBNull.Value);
                    cmd.Parameters.AddWithValue("@hora3", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@id_momentoDia3_fk", programacion.id_momentoDia3);
                    cmd.Parameters.AddWithValue("@cantidadNumerador3", programacion.cantidad3Numerador);
                    cmd.Parameters.AddWithValue("@cantidadDenominador3", programacion.cantidad3Denominador);
                    cmd.Parameters.AddWithValue("@id_presentacionMedicamento3_fk", programacion.id_presentacionMedicamento3);
                    cmd.Parameters.AddWithValue("@hora3", programacion.hora3);
                }

                if (string.IsNullOrEmpty(programacion.motivoConsumo) == true)
                {
                    cmd.Parameters.AddWithValue("@motivoConsumo", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@motivoConsumo", programacion.motivoConsumo);
                }

                cmd.Parameters.AddWithValue("@id_estado_fk", programacion.id_estado);

                cmd.Parameters.AddWithValue("@id_tratamiento_fk", programacion.id_tratamiento);

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                //throw new ApplicationException("Error:" + e.Message);
                throw e;
            }

        }
        public static DataTable MostrarTratamientoMedicamento(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            string consulta = @"select  t.id_tratamiento,t.indicaciones,t.fechaInicio,t.motivoInicioTratamiento, te.id_terapia, te.nombre  as 'Terapia', t.fechaFin,t.motivoFinTratamiento,rd.diagnostico, me.nombreGenerico 'Nombre Medicamento',me.nombreGenerico,me.concentracion, fre.nombre as 'Frecuencia', md1.nombre as 'Momento dia 1', md2.nombre as 'Momento dia 2', md3.nombre as 'Momento dia 3', CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) as 'Dosis 1',CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) as 'Dosis 2',CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) as 'Dosis 3', pre1.nombre 'Presentación Medicamento 1', pre2.nombre 'Presentación Medicamento 2', pre3.nombre 'Presentación Medicamento 3',pm.hora1, pm.hora2,pm.hora3, um.nombre, estp.nombre, um2.nombre as 'UnidadMedida Concentracion',esp.concentracion as 'Cantidad'
                                from Tratamiento t , Terapia te, RazonamientoDiagnostico rd, ExamenGeneral eg, Consulta c, ProgramacionMedicamento pm, Medicamento me, Frecuencia fre, MomentoDelDia md1,MomentoDelDia md2,MomentoDelDia md3, PresentacionMedicamento pre1, PresentacionMedicamento pre2, PresentacionMedicamento pre3, EstadoProgramacion estp, EspecificacionMedicamento esp, UnidadMedida um,UnidadMedida um2
                                where c.id_examenGeneral_fk=eg.id_examenGeneral
								and t.id_terapia_fk=te.id_terapia
								and rd.id_examenGeneral_fk=eg.id_examenGeneral
                                and t.id_razonamientoDiagnostico_fk=rd.id_razonamiento
								and c.id_hc_fk=@id_hc
								and te.nombre like 'Medicamentos'
								and t.id_tratamiento=pm.id_tratamiento_fk
								and pm.id_medicamento_fk=me.id_medicamento
								and pm.id_frecuencia_fk=fre.id_frecuencia
								and pm.id_momentoDia1_fk=md1.id_momentoDelDia
								and pm.id_momentoDia2_fk=md2.id_momentoDelDia
								and pm.id_momentoDia3_fk=md3.id_momentoDelDia
								and pm.id_presentacionMedicamento1_fk=pre1.id_presentacionMedicamento
								and pm.id_presentacionMedicamento2_fk=pre2.id_presentacionMedicamento
								and pm.id_presentacionMedicamento3_fk=pre3.id_presentacionMedicamento
								and pm.id_estado_fk=estp.id_estadoProgramacion
								and pm.id_especificacionMedicamento_fk=esp.id_especificacion
								and esp.id_unidadMedida_fk=um.id_unidadMedida
                                and esp.id_unidadMedida_fk=um2.id_unidadMedida";
            try
            {
                cn.Close();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@id_hc", idHc);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            return dt;
        }
    }
}
