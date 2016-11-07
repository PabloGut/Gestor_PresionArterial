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
    public class UbicacionExtremidadDAO
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

        public static List<UbicacionExtremidad> buscarUbicacionesExtremidadDeExtremidad(int id)
        {
            setCadenaConexion();
            List<UbicacionExtremidad> ubicaciones = new List<UbicacionExtremidad>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT U.id_ubicacionExtremidad, U.nombre, E.id_extremidad, E.nombre AS nombre_extremidad FROM UbicacionExtremidad U " +
                              "INNER JOIN Extremidad E ON U.id_extremidad_fk=E.id_extremidad WHERE U.id_extremidad_fk=@paramId_extremidad";

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@paramId_extremidad", id);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ubicaciones.Add(new UbicacionExtremidad()
                {
                    id_ubicacionExtremidad = (int)dr["id_ubicacionExtremidad"],
                    nombre = dr["nombre"].ToString(),
                    extremidad = new Extremidad((int)dr["id_extremidad"], dr["nombre_extremidad"].ToString())
                });
            }
            cn.Close();
            return ubicaciones;
        }
    }
}
