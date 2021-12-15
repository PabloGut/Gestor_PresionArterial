using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades.Clases;

namespace DAO
{
    public class TipoAntecedenteMorbidoDAO
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
        /*
         * Método para obtener todas las columnas de la tabla TipoAntecedenteMorbido y los nombres correspondiente al tipo de antecedente.
         * No recibe parámetros.
         * Llama al método mostrarNombresPorTipo()
         * El valor de retorno es un a lista de objetos TipoAntecedenteMorbido.
         */
        public static List<TipoAntecedenteMorbido> mostrarTiposAntecedentesMorbidos()
        {
            setCadenaConexion();
            List<TipoAntecedenteMorbido> tiposAntecedentesMorbidos = new List<TipoAntecedenteMorbido>();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();

                string consulta = "select * from TiposAntecedentesMorbidos";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposAntecedentesMorbidos.Add(new TipoAntecedenteMorbido()
                    {
                        id_tipoAntecedenteMorbido = (int)dr["id_tipoAntecedenteMorbido"],
                        nombre = dr["nombre"].ToString()
                    });
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
            return tiposAntecedentesMorbidos;
            
        }
        public static TipoAntecedenteMorbido MostrarNombrePorTipo(int tipoAntecedente)
        {
            setCadenaConexion();
            TipoAntecedenteMorbido tiposAntecedentesMorbidos = new TipoAntecedenteMorbido();

            SqlConnection cn = new SqlConnection(getCadenaConexion());
            string consulta = null;

            try
            {
                cn.Open();

                if(tipoAntecedente == 1)
                {
                     consulta = @"select id_efermedad,nombre, id_tipoAntecedenteMorbido_fk
                                   from Enfermedades
                                   where id_tipoAntecedenteMorbido_fk =@idTipoAntecedente";
                }
                if(tipoAntecedente == 2)
                {
                     consulta = @"select id_operacion,nombre, id_tipoAntecedenteMorbido_fk
                                   from Operaciones
                                   where id_tipoAntecedenteMorbido_fk =@idTipoAntecedente";
                }
                if (tipoAntecedente == 2)
                {
                     consulta = @"select id_traumatismo,nombre, id_tipoAntecedenteMorbido_fk
                                   from Traumatismos
                                   where id_tipoAntecedenteMorbido_fk =@idTipoAntecedente";
                }


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@idTipoAntecedente", tipoAntecedente);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    tiposAntecedentesMorbidos = new TipoAntecedenteMorbido();
                    
                    if (tipoAntecedente == 1)
                    {
                        tiposAntecedentesMorbidos.enfermedades = new List<Enfermedad>();
                        Enfermedad enfermedad = new Enfermedad();
                        tiposAntecedentesMorbidos.id_tipoAntecedenteMorbido = (int)dr["id_enfermedad"];
                    }
                    if (tipoAntecedente == 2)
                    {
                        tiposAntecedentesMorbidos.operaciones = new List<Operacion>();
                        Operacion operacion = new Operacion();
                        tiposAntecedentesMorbidos.id_tipoAntecedenteMorbido = (int)dr["id_operacion"];
                    }
                    if (tipoAntecedente == 3)
                    {
                        tiposAntecedentesMorbidos.traumatismos = new List<Traumatismo>();
                        Traumatismo traumatismo = new Traumatismo();
                        tiposAntecedentesMorbidos.id_tipoAntecedenteMorbido = (int)dr["id_traumatismo"];
                    }

                    tiposAntecedentesMorbidos.nombre = dr["nombre"].ToString();
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
            return tiposAntecedentesMorbidos;

        }
    }
}
