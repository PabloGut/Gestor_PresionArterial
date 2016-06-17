using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Clases;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class DomicilioDAO
    {
        public static void insertarDomicilio(Domicilio domicilio,SqlConnection cn, SqlTransaction tran)
        {
            string consulta = "insert into Domicilio(calle,numero,codigo_postal,piso,departamento,id_institucion,id_barrio) values (@calle,@numero,@codigoPostal,@piso,@departamento,@idIns,@idBarrio)";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = tran;
            cmd.CommandText = consulta;

            cmd.Parameters.AddWithValue("@calle", domicilio.calle);
            cmd.Parameters.AddWithValue("@numero", domicilio.numero);
            cmd.Parameters.AddWithValue("@codigoPostal", domicilio.codigoPostal);
            if (domicilio.piso == -1)
            {
                cmd.Parameters.AddWithValue("@piso", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@piso", domicilio.piso);
            }

            if (String.IsNullOrEmpty(domicilio.departamento))
            {
                cmd.Parameters.AddWithValue("@departamento", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@departamento", domicilio.departamento);
            }
            
            cmd.Parameters.AddWithValue("@idIns", domicilio.id_institucion);
            cmd.Parameters.AddWithValue("@idBarrio", domicilio.id_barrio);

            cmd.ExecuteNonQuery();


        }
    }
}
