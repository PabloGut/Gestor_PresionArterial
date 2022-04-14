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
    public class DetalleMedicionPresionArterialDAO
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

        public static void registrarDetallesMedicionPresionArterial(int id_medicion, DetalleMedicionPresionArterial detalle, SqlTransaction tran, SqlConnection cn)
        {
            try
            {
                string consulta = @"INSERT INTO DetalleMedicionPresionArterial(id_nroMedicion, id_medicion_fk, hora, pulso, valorMaximo, valorMinimo)
                                    VALUES (@paramId_nroMedicion, @paramId_medicion_fk, @paramHora, @paramPulso, @paramValorMaximo, @paramValorMinimo)";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = tran;
                cmd.CommandText = consulta;

                cmd.Parameters.AddWithValue("@paramId_nroMedicion", detalle.id_nroMedicion);
                cmd.Parameters.AddWithValue("@paramId_medicion_fk", id_medicion);
                cmd.Parameters.AddWithValue("@paramHora", detalle.hora.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramPulso", detalle.pulso);
                cmd.Parameters.AddWithValue("@paramValorMaximo", detalle.valorMaximo);
                cmd.Parameters.AddWithValue("@paramValorMinimo", detalle.valorMinimo);

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                //throw new Exception("Error al insertar detalles de medición de presión arterial:" + e.Message);
                throw e;
            }

        }
        public static DataTable obtenerDetalleMedicionesPresionArterial(int idHistoriaClinica, int idMedicion, DateTime? fechaDesde, DateTime? fechaHasta, String extremidad, String momentoDia, String posicion, String ubicacionExtremidad, String sitioMedicion)
        {
            DataTable detalleMediciones = new DataTable();
            DataRow fila;

            detalleMediciones.Columns.Add("NroMedición");
            detalleMediciones.Columns.Add("Hora");
            detalleMediciones.Columns.Add("Valor Máximo");
            detalleMediciones.Columns.Add("Valor Mínimo");
            detalleMediciones.Columns.Add("Pulso");

            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select d.id_nroMedicion,d.hora,d.valorMaximo,d.valorMinimo,d.pulso
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@idHc
                                and m.id_medicion=@IdMedicion
                                and 1=1";

            cmd.Parameters.AddWithValue("@idHc", idHistoriaClinica);
            cmd.Parameters.AddWithValue("@IdMedicion", idMedicion);


            if (fechaDesde.HasValue)
            {
                consulta += " and m.fecha >= @fechaDesde";
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde.Value);
            }
            if (fechaHasta.HasValue)
            {
                consulta += " and m.fecha <= @fechaHasta";
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta.Value);
            }
            if (!String.IsNullOrEmpty(extremidad))
            {
                consulta += " and ex.nombre like @extremidad";
                cmd.Parameters.AddWithValue("@extremidad", extremidad);
            }
            if (!String.IsNullOrEmpty(ubicacionExtremidad))
            {
                consulta += " and uex.nombre like @ubicacionExtremidad";
                cmd.Parameters.AddWithValue("@ubicacionExtremidad", ubicacionExtremidad);
            }
            if (!String.IsNullOrEmpty(momentoDia))
            {
                consulta += " and  md.nombre like @momentoDia";
                cmd.Parameters.AddWithValue("@momentoDia", momentoDia);
            }
            if (!String.IsNullOrEmpty(posicion))
            {
                consulta += " and  p.nombre like @posicion";
                cmd.Parameters.AddWithValue("@posicion", posicion);
            }
            if (!String.IsNullOrEmpty(sitioMedicion))
            {
                consulta += " and  sm.nombre like @sitioMedicion";
                cmd.Parameters.AddWithValue("@sitioMedicion", sitioMedicion);
            }

            consulta += " group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100)), d.id_nroMedicion,d.hora,d.valorMaximo,d.valorMinimo,d.pulso ";
            consulta += " order by m.fecha desc";


            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = detalleMediciones.NewRow();
                    fila["NroMedición"] = (int)dr["id_nroMedicion"];
                    fila["Hora"] = dr["hora"].ToString();
                    fila["Valor Máximo"] = (int)dr["valorMaximo"];
                    fila["Valor Mínimo"] = (int)dr["valorMinimo"];
                    fila["Pulso"] = (int)dr["pulso"];

                    detalleMediciones.Rows.Add(fila);
                }

                cn.Close();
                return detalleMediciones;
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
        public static DataTable calcularPromedioDetalle(int idHistoriaClinica, int idMedicion)
        {
            DataTable promedios = new DataTable();
            DataRow fila;

            promedios.Columns.Add("Promedio Sistolica");
            promedios.Columns.Add("Promedio Diastolica");
            promedios.Columns.Add("Promedio Pulso");

            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select AVG(valorMaximo) as 'PromedioValorMaximo',AVG(valorMinimo) as 'PromedioValorMinimo',AVG(pulso) as 'PromedioPulso'
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_hc_fk=@idHc
                                and m.id_medicion=@IdMedicion
                                group by m.id_medicion;";

            cmd.Parameters.AddWithValue("@idHc", idHistoriaClinica);
            cmd.Parameters.AddWithValue("@IdMedicion", idMedicion);

            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = promedios.NewRow();
                    fila["Promedio Sistolica"] = Convert.ToDouble(dr["PromedioValorMaximo"]);
                    fila["Promedio Diastolica"] = Convert.ToDouble(dr["PromedioValorMinimo"]);
                    fila["Promedio Pulso"] = Convert.ToDouble(dr["PromedioPulso"]);

                    promedios.Rows.Add(fila);
                }

                cn.Close();
                return promedios;
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
        public static DataTable obtenerDetalleMedicionesConFiltro(int idHistoriaClinica)
        {
            DataTable detalleMediciones = new DataTable();
            DataRow fila;

            detalleMediciones.Columns.Add("NroMedición");
            detalleMediciones.Columns.Add("Fecha");
            detalleMediciones.Columns.Add("Hora");
            detalleMediciones.Columns.Add("Valor Máximo");
            detalleMediciones.Columns.Add("Valor Mínimo");
            detalleMediciones.Columns.Add("Pulso");

            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select top(40) d.id_nroMedicion, m.fecha, d.hora,d.valorMaximo,d.valorMinimo,d.pulso
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@idHc
                                group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100)), d.id_nroMedicion,d.hora,d.valorMaximo,d.valorMinimo,d.pulso
                                order by m.fecha desc";

            cmd.Parameters.AddWithValue("@idHc", idHistoriaClinica);
            SqlDataReader dr = null;
            try
            {
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = detalleMediciones.NewRow();
                    fila["NroMedición"] = (int)dr["id_nroMedicion"];
                    fila["Fecha"] = Convert.ToDateTime( dr["fecha"].ToString()).ToShortDateString() +" "+ Convert.ToDateTime(dr["hora"].ToString()).ToShortTimeString();
                    //fila["Hora"] = dr["fecha"].ToString()+ dr["hora"].ToString();
                    fila["Valor Máximo"] = (int)dr["valorMaximo"];
                    fila["Valor Mínimo"] = (int)dr["valorMinimo"];
                    fila["Pulso"] = (int)dr["pulso"];

                    detalleMediciones.Rows.Add(fila);
                }

                cn.Close();
                return detalleMediciones;
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
        public static List<DetalleMedicionPresionArterial> obtenerDetalleMedicionesPresionArterialIdConsulta(int idMedicion,SqlTransaction tran,SqlConnection cn)
        {
            setCadenaConexion();
            DetalleMedicionPresionArterial detalle = null;
            List<DetalleMedicionPresionArterial> detalles = new List<DetalleMedicionPresionArterial>();

            try
            {
                SqlCommand cmd = new SqlCommand();
                String consulta = @"select *
                                    from DetalleMedicionPresionArterial
                                    where id_medicion_fk=@idMedicion";

                cmd.Parameters.AddWithValue("@idMedicion", idMedicion);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        detalles.Add(detalle = (new DetalleMedicionPresionArterial()
                                                {
                                                    hora = Convert.ToDateTime(dr["hora"].ToString()),
                                                    pulso = (int)dr["pulso"],
                                                    valorMaximo=(int)dr["valorMaximo"],
                                                    valorMinimo=(int)dr["valorMinimo"]
                                                })
                        );

                    }
                    cn.Close();
                    return detalles;
            }
            catch (Exception e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
    }
}
