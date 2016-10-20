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
    public class AbortoDAO
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
        public static int registrarAntecedentesAborto(Aborto aborto, SqlTransaction tran, SqlConnection cn)
        {
            int idAborto;
            try
            {
                string consulta = @"insert into Aborto(fechaRegistro,cantidadTotal,cantidadProvocados, id_TipoAborto1_fk, cantidadEspontaneos, id_TipoAborto2_fk,nroHijosVivos,problemasAsociadosAlEmbarazo)
                                  values(@fechaRegistro,@cantidadTotal,@cantidadProvocados,@iTipoAborto1,@cantidadEspontaneos,@idTipoAborto2,@nroHijosVivos,@problemasAsociadosAlEmbarazo)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction=tran;
                cmd.CommandText = consulta;
                
                cmd.Parameters.AddWithValue("@fechaRegistro", aborto.fechaRegistro);
                cmd.Parameters.AddWithValue("@cantidadTotal", aborto.cantidadTotal);
                cmd.Parameters.AddWithValue("@cantidadProvocados", aborto.cantidadAbortoTipo1);
                cmd.Parameters.AddWithValue("@iTipoAborto1", aborto.id_tipoAborto1);
                cmd.Parameters.AddWithValue("@cantidadEspontaneos", aborto.cantidadAbortoTipo2);
                cmd.Parameters.AddWithValue("@idTipoAborto2", aborto.id_tipoAborto2);
                cmd.Parameters.AddWithValue("@nroHijosVivos", aborto.nroHijosVivos);
                cmd.Parameters.AddWithValue("@problemasAsociadosAlEmbarazo", aborto.problemasEmbarazo);

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("Select @@Identity", cn, tran);
                idAborto = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            return idAborto;
        }
        
    }
}
