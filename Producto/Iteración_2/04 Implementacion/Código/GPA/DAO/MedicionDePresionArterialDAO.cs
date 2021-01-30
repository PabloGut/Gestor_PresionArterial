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
    public class MedicionDePresionArterialDAO
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

        public static int registrarMedicionDePresionArterial(MedicionDePresionArterial medicion)
        {

            SqlTransaction tran = null;

            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,promedio,id_sitioMedicion_fk,horaInicio,id_ubicacionExtremidad_fk)
                                VALUES (@paramFecha,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramPromedio,@paramId_sitioMedicion_fk,@paramHoraInicio,@paramId_ubicacionExtremidad_fk)";

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            try
            {
                cn.Open();
                tran = cn.BeginTransaction();

                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@paramFecha", medicion.fecha.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_posicion_fk", medicion.posicion.id_posicion);
                if (medicion.clasificacion==null)
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", medicion.clasificacion.id_clasificacion);
                }
                cmd.Parameters.AddWithValue("@paramId_momentoDelDia_fk", medicion.momento.idMomentoDia);
                cmd.Parameters.AddWithValue("@paramPromedio", medicion.promedio);
                cmd.Parameters.AddWithValue("@paramId_sitioMedicion_fk", medicion.sitio.id_sitioMedicion);
                cmd.Parameters.AddWithValue("@paramHoraInicio", medicion.horaInicio.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_ubicacionExtremidad_fk", medicion.ubicacion.id_ubicacionExtremidad);
                

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("select @@Identity", cn, tran);
                medicion.id_medicion = (int)cmd1.ExecuteScalar();

                foreach (DetalleMedicionPresionArterial detalle in medicion.mediciones)
                {
                    DetalleMedicionPresionArterialDAO.registrarDetallesMedicionPresionArterial(medicion.id_medicion, detalle, tran, cn);
                }

                tran.Commit();
                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error al insertar medición de presión arterial: " + e.Message);
            }
            return medicion.id_medicion;
        }

        public static int registrarMedicionDePresionArterial(MedicionDePresionArterial medicion, SqlTransaction tran, SqlConnection cn , int id_hc)
        {
            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,promedio,id_sitioMedicion_fk,horaInicio,id_extremidad_fk,id_ubicacionExtremidad_fk, id_hc_fk)
                                VALUES (@paramFecha,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramPromedio,@paramId_sitioMedicion_fk,@paramHoraInicio,@paramId_extremidad,@paramId_ubicacionExtremidad_fk,@paramId_hc)";
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@paramFecha", medicion.fecha.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_posicion_fk", medicion.posicion.id_posicion);
                if (medicion.clasificacion == null)
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", medicion.clasificacion.id_clasificacion);
                }
                cmd.Parameters.AddWithValue("@paramId_momentoDelDia_fk", medicion.momento.idMomentoDia);
                cmd.Parameters.AddWithValue("@paramPromedio", medicion.promedio);
                cmd.Parameters.AddWithValue("@paramId_sitioMedicion_fk", medicion.sitio.id_sitioMedicion);
                cmd.Parameters.AddWithValue("@paramHoraInicio", medicion.horaInicio.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_ubicacionExtremidad_fk", medicion.ubicacion.id_ubicacionExtremidad);
                cmd.Parameters.AddWithValue("@paramId_extremidad", medicion.extremidad.id_extremidad);
                cmd.Parameters.AddWithValue("@paramId_hc", id_hc);

                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('MedicionDePrecionArterial')", cn, tran);
                medicion.id_medicion = Convert.ToInt32(cmd1.ExecuteScalar());

                foreach (DetalleMedicionPresionArterial detalle in medicion.mediciones)
                {
                    DetalleMedicionPresionArterialDAO.registrarDetallesMedicionPresionArterial(medicion.id_medicion, detalle, tran, cn);
                }
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw e;
                //throw new Exception("Error al insertar medición de presión arterial: " + e.Message);
            }
            return medicion.id_medicion;
        }
        public static void registrarMedicionDePresionArterialEnHistoriaClinica(MedicionDePresionArterial medicion)
        {
            setCadenaConexion();
            SqlConnection cn = new SqlConnection(getCadenaConexion());

            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,horaInicio,id_extremidad_fk,id_ubicacionExtremidad_fk,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,id_sitioMedicion_fk,id_hc_fk)
                                VALUES (@paramFecha,@paramHoraInicio,@paramId_extremidad_fk,@paramId_ubicacionExtremidad_fk,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramId_sitioMedicion_fk,@idHc)";

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran = null;
            try
            {
                

                cmd.Parameters.AddWithValue("@paramFecha", medicion.fecha.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_posicion_fk", medicion.posicion.id_posicion);
                cmd.Parameters.AddWithValue("@paramId_extremidad_fk", medicion.extremidad.id_extremidad);
                if (medicion.clasificacion == null)
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@paramId_clasificacion_fk", medicion.clasificacion.id_clasificacion);
                }
                cmd.Parameters.AddWithValue("@paramId_momentoDelDia_fk", medicion.momento.idMomentoDia);
                cmd.Parameters.AddWithValue("@paramId_sitioMedicion_fk", medicion.sitio.id_sitioMedicion);
                cmd.Parameters.AddWithValue("@paramHoraInicio", medicion.horaInicio.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
                cmd.Parameters.AddWithValue("@paramId_ubicacionExtremidad_fk", medicion.ubicacion.id_ubicacionExtremidad);
                cmd.Parameters.AddWithValue("@idHc", medicion.idHc);

                cn.Open();
                tran = cn.BeginTransaction();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand("SELECT IDENT_CURRENT('MedicionDePrecionArterial')", cn, tran);
                medicion.id_medicion = Convert.ToInt32(cmd1.ExecuteScalar());

                foreach (DetalleMedicionPresionArterial detalle in medicion.mediciones)
                {   
                    DetalleMedicionPresionArterialDAO.registrarDetallesMedicionPresionArterial(medicion.id_medicion, detalle, tran, cn);
                }

                tran.Commit();
                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    tran.Rollback();
                    cn.Close();
                }
                throw new Exception("Error al insertar medición de presión arterial: " + e.Message);
            }
        }
        public static DataTable obtenerMedicionesPresionArterial(int idHistoriaClinica)
        {
            DataTable mediciones = new DataTable();
            DataTable promedios = new DataTable();
            DataRow fila;

            mediciones.Columns.Add("id_medicion");
            mediciones.Columns.Add("Hora Inicio");
            mediciones.Columns.Add("Fecha");
            mediciones.Columns.Add("Extremidad");
            mediciones.Columns.Add("Ubicacion Extremidad");
            mediciones.Columns.Add("Sitio Medicion");
            mediciones.Columns.Add("Momento del día");
            mediciones.Columns.Add("Posición");

            mediciones.Columns.Add("Promedio Valor Máximo");
            mediciones.Columns.Add("Promedio Valor Mínimo");
            mediciones.Columns.Add("Promedio Pulso");

            setCadenaConexion();

            SqlConnection cn = new SqlConnection(getCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select top(10) m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'Ubicacion Extremidad',CAST(sm.nombre as nvarchar(100)) as 'Sitio Medicion',CAST(md.nombre as nvarchar(100)) as 'Momento del día',CAST(p.nombre as nvarchar(100)) as 'Posición'
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@idHc
                                group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100))
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
                    fila = mediciones.NewRow();
                    fila["id_medicion"] = (int)dr["id_medicion"];
                    fila["Hora Inicio"] = dr["horaInicio"];
                    fila["Fecha"] = dr["fecha"].ToString();
                    fila["Extremidad"] = dr["Extremidad"].ToString();
                    fila["Ubicacion Extremidad"] = dr["Ubicacion Extremidad"].ToString();
                    fila["Sitio Medicion"] = dr["Sitio Medicion"].ToString();
                    fila["Momento del día"] = dr["Momento del día"].ToString();
                    fila["Posición"] = dr["Posición"].ToString();

                    promedios=DetalleMedicionPresionArterialDAO.calcularPromedioDetalle(idHistoriaClinica, (int)dr["id_medicion"]);

                    fila["Promedio Valor Máximo"] = promedios.Rows[0]["Promedio Valor Máximo"];
                    fila["Promedio Valor Mínimo"]= promedios.Rows[0]["Promedio Valor Mínimo"];
                    fila["Promedio Pulso"] = promedios.Rows[0]["Promedio Pulso"];

                    mediciones.Rows.Add(fila);
                }

                cn.Close();
                return mediciones;
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
