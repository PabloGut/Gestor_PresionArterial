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
    public class HabitoMedicamentoDAO
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
        public static void registrarHabitosMedicamento(List<HabitoMedicamento> habitosMedicamento, int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                string consulta = @"insert into HabitosMedicamento(id_hc_fk,id_programacionMedicamento_fk,fechaRegistro)
                                  values(@idHc,@idProgramacionMedicamento,@fechaRegistro)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                foreach (HabitoMedicamento habito in habitosMedicamento)
                {
                    
                    ProgramacionMedicamentoDAO.registrarProgramacionMedicamento(habito.programacion, tran, cn);

                    cmd.Parameters.AddWithValue("@idHc", idHc);
                    cmd.Parameters.AddWithValue("@idProgramacionMedicamento", habito.programacion.id_programacionMedicamento);
                    cmd.Parameters.AddWithValue("@fechaRegistro", habito.fechaRegistro);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                }
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
        public static DataTable MostrarHabitosAlcoholismo(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select ha.fechaRegistro,tb.nombre as 'Nombre Bebida',m.nombre,m.descripcion, ct.nombre
                                    from HabitosAlcoholismo ha, TipoBebida tb, Medida m, ComponenteDelTiempo ct
                                    where ha.id_tipoBebida_fk=tb.id_tipoBebida
                                    and m.id_medida=ha.id_medida_fk
                                    and ha.id_componenteTiempo_fk=ct.id_componenteTiempo
                                    and ha.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HabitosAlcoholismo");
                da.Fill(dt);
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dt;
        }
        public static DataTable MostrarHabitosMedicamentos(int idHc)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            DataTable dt = null;
            SqlDataAdapter da = null;
            try
            {
                cn.Open();

                string consulta = @"select  hm.id_hc_fk,hm.fechaRegistro as 'Fecha de registro',med.nombreGenerico as 'Nombre generico',em.concentracion as 'Concentracion',em.cantidadComprimidos as 'Cantidad de comprimidos',fe.nombre as 'Frecuencia', md1.nombre as 'Momento del dia 1', CONCAT(pm.cantidadNumerador1, '/', pm.cantidadDenominador1) as 'Dosis 1',prem1.nombre as 'Presentacion medicamento 1',pm.hora1 as 'Hora 1', md2.nombre as 'Momento del dia 2', CONCAT(pm.cantidadNumerador2, '/', pm.cantidadDenominador2) as 'Dosis 2',prem2.nombre as 'Presentacion Medicamento 2',pm.hora2 as 'Hora 2', CONCAT(pm.cantidadNumerador3, '/', pm.cantidadDenominador3) as 'Dosis 3',prem3.nombre as 'Presentacion Medicamento 3',pm.hora3 as 'Hora 3', md3.nombre as 'Momento del Dia 3',unidadM.nombre as 'Unidad de Medida'
                                    from HabitosMedicamento hm full outer join ProgramacionMedicamento pm on hm.id_programacionMedicamento_fk=pm.id_programacionMedicamento
                                    full outer join EspecificacionMedicamento em on pm.id_especificacionMedicamento_fk=em.id_especificacion
                                    full outer join Medicamento med on pm.id_medicamento_fk=med.id_medicamento
                                    full outer join Frecuencia fe on  pm.id_frecuencia_fk=fe.id_frecuencia
                                    full outer join MomentoDelDia md1 on  pm.id_momentoDia1_fk=md1.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem1 on pm.id_presentacionMedicamento1_fk=prem1.id_presentacionMedicamento
                                    full outer join MomentoDelDia md2 on  pm.id_momentoDia2_fk=md2.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem2 on pm.id_presentacionMedicamento2_fk=prem2.id_presentacionMedicamento
                                    full outer join MomentoDelDia md3 on  pm.id_momentoDia3_fk=md3.id_momentoDelDia
                                    full outer join PresentacionMedicamento prem3 on pm.id_presentacionMedicamento3_fk=prem3.id_presentacionMedicamento
                                    full outer join UnidadMedida unidadM on  em.id_unidadMedida_fk=unidadM.id_unidadMedida
                                    where hm.id_hc_fk=@idHc";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@idHc", idHc);

                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                da = new SqlDataAdapter(cmd);
                dt = new DataTable("HabitosMedicamento");
                da.Fill(dt);
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
            cn.Close();

            return dt;
        }

    }
}
