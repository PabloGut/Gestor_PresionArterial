using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class TratamientoDAO
    {
        public static void registrarTratamientos(Tratamiento tratamiento, SqlConnection cn, SqlTransaction tran)
        {
            string consulta = @"insert into Tratamiento(indicaciones,fechaInicio,motivoInicio,id_terapia_fk, id_razonamientoDiagnostico_fk)
                                values(@indicaciones,@fechaInicio,@motivoInicio,@id_terapia_fk,@id_razonamientoDiagnostico_fk)";

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@indicaciones", tratamiento.indicaciones);
                cmd.Parameters.AddWithValue("@fechaInicio", tratamiento.fechaInicio);
                cmd.Parameters.AddWithValue("@motivoInicio", tratamiento.motivoInicio);
                cmd.Parameters.AddWithValue("@id_terapia_fk", tratamiento.terapia.id_terapia);
                cmd.Parameters.AddWithValue("@id_razonamientoDiagnostico_fk", tratamiento.id_razonamiento_fk);

                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                if (tratamiento.medicamentos != null && tratamiento.medicamentos.Count > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("select IDENT_CURRENT('Tratamiento')", cn, tran);
                    tratamiento.id_tratamiento = Convert.ToInt32(cmd1.ExecuteScalar());

                    foreach (ProgramacionMedicamento pro in tratamiento.medicamentos)
                    {
                        pro.id_tratamiento = tratamiento.id_tratamiento;
                        ProgramacionMedicamentoDAO.registrarTratamientoProgramacionMedicamento(pro, tran, cn);
                    }
                }
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
