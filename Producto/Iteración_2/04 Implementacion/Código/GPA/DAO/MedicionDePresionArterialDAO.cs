using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAO
{
    public class MedicionDePresionArterialDAO
    {
        private static string cadenaConexion;

        public static void SetCadenaConexion()
        {
            CadenaConexion singleton = CadenaConexion.getInstancia();
            cadenaConexion = singleton.getCadena();
        }
        public static string GetCadenaConexion()
        {
            return cadenaConexion;
        }

        public static int RegistrarMedicionDePresionArterial(MedicionDePresionArterial medicion)
        {

            SqlTransaction tran = null;

            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,promedio,id_sitioMedicion_fk,horaInicio,id_ubicacionExtremidad_fk)
                                VALUES (@paramFecha,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramPromedio,@paramId_sitioMedicion_fk,@paramHoraInicio,@paramId_ubicacionExtremidad_fk)";

            SqlConnection cn = new SqlConnection(GetCadenaConexion());

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

        public static int RegistrarMedicionDePresionArterial(MedicionDePresionArterial medicion, SqlTransaction tran, SqlConnection cn , int id_hc)
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
        public static void RegistrarMedicionDePresionArterialEnHistoriaClinica(MedicionDePresionArterial medicion)
        {

            SqlConnection cn=null;

            string consulta = @"INSERT INTO MedicionDePrecionArterial(fecha,horaInicio,id_extremidad_fk,id_ubicacionExtremidad_fk,id_posicion_fk,id_clasificacion_fk,id_momentoDelDia_fk,id_sitioMedicion_fk,id_hc_fk)
                                VALUES (@paramFecha,@paramHoraInicio,@paramId_extremidad_fk,@paramId_ubicacionExtremidad_fk,@paramId_posicion_fk,@paramId_clasificacion_fk,@paramId_momentoDelDia_fk,@paramId_sitioMedicion_fk,@idHc)";

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran = null;
            try
            {
                SetCadenaConexion();
                cn = new SqlConnection(GetCadenaConexion());

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
        public static DataTable ObtenerMedicionesPresionArterial(int idHistoriaClinica, DateTime? fechaDesde, DateTime? fechaHasta, String extremidad, String momentoDia, String posicion, String ubicacionExtremidad, String sitioMedicion)
        {
            DataTable mediciones = new DataTable();
            DataTable promedios = new DataTable();
            DataRow fila;
            SqlConnection cn = null;

            mediciones.Columns.Add("id_medicion");
            mediciones.Columns.Add("Hora Inicio");
            mediciones.Columns.Add("Fecha");
            mediciones.Columns.Add("Extremidad");
            mediciones.Columns.Add("Ubicacion Extremidad");
            mediciones.Columns.Add("Sitio Medicion");
            mediciones.Columns.Add("Momento del día");
            mediciones.Columns.Add("Posición");

            mediciones.Columns.Add("Promedio Sistólica");
            mediciones.Columns.Add("Promedio Diastólica");
            mediciones.Columns.Add("Promedio Pulso");
            try
            {
                SetCadenaConexion();

            cn = new SqlConnection(GetCadenaConexion());

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
                                and 1=1";

            cmd.Parameters.AddWithValue("@idHc", idHistoriaClinica);

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

            consulta +=" group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100)) order by m.fecha desc";
            
            SqlDataReader dr = null;

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

                    fila["Promedio Sistólica"] = promedios.Rows[0]["Promedio Sistólica"];
                    fila["Promedio Diastólica"]= promedios.Rows[0]["Promedio Diastólica"];
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
                throw e;
            }
        }

        public static List<MedicionDePresionArterial> ObtenerMedicionesPresionArterialIdConsulta(int idConsulta)
        {
            SetCadenaConexion();
            MedicionDePresionArterial medicion = null;
            List<MedicionDePresionArterial> listaMediciones = new List<MedicionDePresionArterial>();
            SqlConnection cn = new SqlConnection(GetCadenaConexion());
            SqlTransaction tran = null;
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                String consulta = @"select CONCAT(mpa.fecha,' ',mpa.horaInicio) as 'Fecha Hora',ext.nombre as 'Extremidad',uext.nombre as 'Ubicacion Extremidad',sm.nombre as 'Sitio de Medición',pos.nombre as 'Posición',mdia.nombre as 'Momento del día',mpa.id_medicion
                                    from Consulta c, ExamenGeneral ex, MedicionDePrecionArterial mpa, Extremidad ext,UbicacionExtremidad uext, SitioMedicion sm,Posicion pos,MomentoDelDia mdia
                                    where c.id_examenGeneral_fk=ex.id_examenGeneral
                                    and ex.id_medicion_fk=mpa.id_medicion
                                    and mpa.id_extremidad_fk=ext.id_extremidad
                                    and ext.id_extremidad=uext.id_extremidad_fk
                                    and mpa.id_ubicacionExtremidad_fk=uext.id_ubicacionExtremidad
                                    and mpa.id_sitioMedicion_fk=sm.id_sitioMedicion
                                    and mpa.id_posicion_fk=pos.id_posicion
                                    and mpa.id_momentoDelDia_fk=mdia.id_momentoDelDia
                                    and sm.nombre like 'Consultorio'
                                    and c.id_consulta=@idConsulta
                                    order by CONCAT(c.fechaConsulta,' ',c.horaConsulta) desc";

                cmd.Parameters.AddWithValue("@idConsulta", idConsulta);

                tran = cn.BeginTransaction();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                cmd.Transaction = tran;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        medicion = new MedicionDePresionArterial();
                        medicion.fecha = Convert.ToDateTime(dr["Fecha Hora"].ToString());

                        medicion.extremidad=(new Extremidad()
                                            {
                                                nombre = dr["Extremidad"].ToString()
                                            });
                        medicion.ubicacion = (new UbicacionExtremidad()
                        {
                             nombre=dr["Ubicacion Extremidad"].ToString()
                        });

                        medicion.sitio = (new SitioMedicion()
                                            {
                                                nombre=dr["Sitio de Medición"].ToString()
                                            });
                        medicion.posicion = (new Posicion()
                        {
                            nombre=dr["Posición"].ToString()
                        });
                        medicion.momento = (new MomentoDia()
                        {
                            nombre= dr["Momento del día"].ToString()
                        });

                        medicion.id_medicion = (int)dr["id_medicion"];

                       
                        listaMediciones.Add(medicion);
                    }
                    dr.Close();
                    foreach(MedicionDePresionArterial me in listaMediciones)
                    {
                        me.mediciones = DetalleMedicionPresionArterialDAO.obtenerDetalleMedicionesPresionArterialIdConsulta(me.id_medicion, tran, cn);
                    }

                    cn.Close();
                    return listaMediciones;
                }
                else
                {
                    return null;
                }
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
        public static DataTable ObtenerMedicionesPresionArterialConFiltro(int idHistoriaClinica, DateTime? fechaDesde, DateTime? fechaHasta,String extremidad, String momentoDia, String posicion, String ubicacionExtremidad,String sitioMedicion)
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

            mediciones.Columns.Add("Promedio Sistólica");
            mediciones.Columns.Add("Promedio Diastólica");
            mediciones.Columns.Add("Promedio Pulso");

            mediciones.Columns.Add("Hora");
            mediciones.Columns.Add("valorMaximo");
            mediciones.Columns.Add("valorMinimo");
            mediciones.Columns.Add("Pulso");

            mediciones.Columns.Add("FechaHora");
            SetCadenaConexion();

            SqlConnection cn = new SqlConnection(GetCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select top(50) m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'Ubicacion Extremidad',CAST(sm.nombre as nvarchar(100)) as 'Sitio Medicion',CAST(md.nombre as nvarchar(100)) as 'Momento del día',CAST(p.nombre as nvarchar(100)) as 'Posición',d.hora,d.valorMaximo,d.valorMinimo,d.pulso
                                from MedicionDePrecionArterial m, DetalleMedicionPresionArterial d,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_medicion=d.id_medicion_fk
                                and m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@idHc
                                and 1=1";
            cmd.Parameters.AddWithValue("@idHc", idHistoriaClinica);

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
                cmd.Parameters.AddWithValue("@posicion",posicion);
            }
            if (!String.IsNullOrEmpty(sitioMedicion))
            {
                consulta += " and  sm.nombre like @sitioMedicion";
                cmd.Parameters.AddWithValue("@sitioMedicion", sitioMedicion);
            }

            consulta += " group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100)),d.hora,d.valorMaximo,d.valorMinimo,d.pulso" +
                        " order by m.fecha desc";



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
                    fila["Fecha"] = Convert.ToDateTime(dr["fecha"].ToString()).ToShortDateString() + " " + Convert.ToDateTime(dr["hora"].ToString()).ToShortTimeString();
                    //fila["Fecha"] = dr["fecha"].ToString();
                    fila["Extremidad"] = dr["Extremidad"].ToString();
                    fila["Ubicacion Extremidad"] = dr["Ubicacion Extremidad"].ToString();
                    fila["Sitio Medicion"] = dr["Sitio Medicion"].ToString();
                    fila["Momento del día"] = dr["Momento del día"].ToString();
                    fila["Posición"] = dr["Posición"].ToString();
                    fila["hora"] = dr["hora"].ToString();
                    fila["valorMaximo"] = dr["valorMaximo"].ToString();
                    fila["valorMinimo"] = dr["valorMinimo"].ToString();
                    fila["pulso"] = dr["pulso"].ToString();

                    DateTime fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    DateTime hora = Convert.ToDateTime(dr["hora"].ToString());
                    fila["FechaHora"]=fecha.ToShortDateString()+ "\r\n" + hora.ToShortTimeString();
                    promedios = DetalleMedicionPresionArterialDAO.calcularPromedioDetalle(idHistoriaClinica, (int)dr["id_medicion"]);

                    fila["Promedio Sistólica"] = promedios.Rows[0]["Promedio Sistólica"];
                    fila["Promedio Diastólica"] = promedios.Rows[0]["Promedio Diastólica"];
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
                throw e;
            }
        }

        public static DataTable ObtenerMediciones(int idHistoriaClinica)
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

            SetCadenaConexion();

            SqlConnection cn = new SqlConnection(GetCadenaConexion());

            SqlCommand cmd = new SqlCommand();

            string consulta = @"select  m.id_medicion,m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)) as 'Extremidad',CAST(uex.nombre as nvarchar(100)) as 'Ubicacion Extremidad',CAST(sm.nombre as nvarchar(100)) as 'Sitio Medicion',CAST(md.nombre as nvarchar(100)) as 'Momento del día',CAST(p.nombre as nvarchar(100)) as 'Posición'
                                from MedicionDePrecionArterial m,Extremidad ex,UbicacionExtremidad uex,SitioMedicion sm, MomentoDelDia md, Posicion p
                                where m.id_extremidad_fk=ex.id_extremidad
                                and m.id_ubicacionExtremidad_fk=uex.id_ubicacionExtremidad
                                and m.id_posicion_fk=p.id_posicion
                                and m.id_momentoDelDia_fk=md.id_momentoDelDia
                                and m.id_sitioMedicion_fk= sm.id_sitioMedicion
                                and m.id_hc_fk=@idHc
								group by m.id_medicion, m.horaInicio,m.fecha,CAST(ex.nombre as nvarchar(100)),CAST(uex.nombre as nvarchar(100)),CAST(sm.nombre as nvarchar(100)),CAST(md.nombre as nvarchar(100)),CAST(p.nombre as nvarchar(100))
								order by m.fecha asc";

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
                    fila["Fecha"] = Convert.ToDateTime(dr["fecha"].ToString()).ToShortDateString();
                    //fila["Fecha"] = dr["fecha"].ToString();
                    fila["Extremidad"] = dr["Extremidad"].ToString();
                    fila["Ubicacion Extremidad"] = dr["Ubicacion Extremidad"].ToString();
                    fila["Sitio Medicion"] = dr["Sitio Medicion"].ToString();
                    fila["Momento del día"] = dr["Momento del día"].ToString();
                    fila["Posición"] = dr["Posición"].ToString();

                    promedios = DetalleMedicionPresionArterialDAO.calcularPromedioDetalle(idHistoriaClinica, (int)dr["id_medicion"]);

                    fila["Promedio Valor Máximo"] = promedios.Rows[0]["Promedio Valor Máximo"];
                    fila["Promedio Valor Mínimo"] = promedios.Rows[0]["Promedio Valor Mínimo"];
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
                throw e;
            }
        }
    }
}
