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
            
            //cmd.Parameters.AddWithValue("@idIns", domicilio.id_institucion);
            cmd.Parameters.AddWithValue("@idBarrio", domicilio.id_barrio);

            cmd.ExecuteNonQuery();


        }
        /*
         *Mètodo para buscar todos los datos de un domicilio.
         *Recibe como parámetro el id_domicilio.
         *Retorna un objeto del tipo Domicilio.
         */
        public Domicilio mostrarDomicilioDelPaciente(int id_domicilio)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection();
            Domicilio domicilio=null;
            try
            {
                cn.Open();
                string consulta = "select * from Domicilio where id_domicilio=@id_domicilio";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    domicilio = new Domicilio();
                    domicilio.calle = dr["calle"].ToString();
                    domicilio.numero = (int)dr["numero"];
                    if (string.IsNullOrEmpty(dr["piso"].ToString()))
                    {
                        domicilio.piso = (int)dr["piso"];
                    }
                    if (string.IsNullOrEmpty(dr["depto"].ToString()))
                    {
                        domicilio.departamento = dr["depto"].ToString();
                    }
                    domicilio.codigoPostal = (int)dr["codigoPostal"];
                    domicilio.id_barrio = (int)dr["id_barrio_fk"];
                }
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw new ApplicationException("Error:" + e.Message);
            }
            cn.Close();
            if (domicilio != null)
            {
                domicilio.barrio = BarrioDAO.mostrarBarrio(domicilio.id_barrio);
            }
            return domicilio;
        }
    }
}
