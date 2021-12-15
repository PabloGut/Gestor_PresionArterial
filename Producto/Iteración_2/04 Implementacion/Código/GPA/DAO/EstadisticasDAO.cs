﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades.Clases;
using System.Data.SqlClient;


namespace DAO
{
    public class EstadisticasDAO
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
        public static void InsertarEstadisticas()
        {
            setCadenaConexion();
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);

                SqlCommand cmd = new SqlCommand("p_insert_PromedioModaCantidad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaPromedioEdad> MostrarEstadisticaPromedio()
        {
            SqlConnection cn = null ;
            List<EstadisticaPromedioEdad> estadistica;
            try
            {
                setCadenaConexion();
                estadistica = new List<EstadisticaPromedioEdad>();

                cn = new SqlConnection(cadenaConexion);

                cn.Open();

                string consulta = @"select top 1 id, fecha_registro,promedioEdad from Estadistica_EdadPromedio
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaPromedioEdad()
                    {
                        Id = (int)dr["id"],
                        fechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        promedioEdad = (double)dr["promedioEdad"],

                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaCantidadPorSexo> CantidadPacientesFemenino()
        {
            List<EstadisticaCantidadPorSexo> estadistica = new List<EstadisticaCantidadPorSexo>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Femenino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCantidadPorSexo()
                    {
                        Id = (int)dr["id"],
                        fechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        idSexo = (int)dr["id_sexo"],
                        sexo = dr["sexo"].ToString(),
                        CantidadPacientes = Convert.ToInt32(dr["cantidadPacientesPorSexo"]),
                        totalPacientes = Convert.ToInt32(dr["cantidadTotalPacientes"]),
                        porcentajePorSexo = Convert.ToDouble(dr["Porcentaje"])
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }

        public static List<EstadisticaCantidadPorSexo> CantidadPacientesMasculino()
        {
            List<EstadisticaCantidadPorSexo> estadistica = new List<EstadisticaCantidadPorSexo>();
            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                setCadenaConexion();
                cn.Open();

                string consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Masculino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCantidadPorSexo()
                    {
                        Id = (int)dr["id"],
                        fechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        idSexo = (int)dr["id_sexo"],
                        sexo = dr["sexo"].ToString(),
                        CantidadPacientes = Convert.ToInt32(dr["cantidadPacientesPorSexo"]),
                        totalPacientes = Convert.ToInt32(dr["cantidadTotalPacientes"]),
                        porcentajePorSexo = Convert.ToDouble(dr["Porcentaje"])
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaModaEdad> ModaEdad()
        {
            SqlConnection cn = null;
            List <EstadisticaModaEdad> estadistica = new List<EstadisticaModaEdad>();

            try
            {
                cn = new SqlConnection(cadenaConexion);
                setCadenaConexion();
                cn.Open();

                String consulta = @"select distinct moda_edad
                                from Estadistica_EdadModa
                                where  convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaModaEdad()
                    {
                        //Id = (int)dr["id"],
                        //fechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        modaEdad = Convert.ToInt32(dr["moda_edad"]),

                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }

        public static DataTable CantidadPacientesMasculinoDataTable()
        {
            DataTable estadistica = new DataTable();
            DataRow fila;

            estadistica.Columns.Add("sexo");
            estadistica.Columns.Add("cantidadPacientesPorSexo");

            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                setCadenaConexion();
                cn.Open();

                string consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Masculino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = estadistica.NewRow();
                    fila["sexo"] = dr["sexo"].ToString();
                    fila["cantidadPacientesPorSexo"] = Convert.ToInt32(dr["cantidadPacientesPorSexo"]);
                    estadistica.Rows.Add(fila);
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static DataTable CantidadPacientesFemeninoDataTable()
        {
            DataTable estadistica = new DataTable();
            DataRow fila;

            estadistica.Columns.Add("sexo");
            estadistica.Columns.Add("cantidadPacientesPorSexo");
            estadistica.Columns.Add("Porcentaje");

            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                setCadenaConexion();
                cn.Open();

                string consulta = @"select top 1 id,fecha_registro,id_sexo,sexo,cantidadPacientesPorSexo,cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                    from cantidadPacientesPorSexo
                                    where sexo='Femenino'
                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = estadistica.NewRow();
                    fila["sexo"] = dr["sexo"].ToString();
                    fila["cantidadPacientesPorSexo"] = Convert.ToInt32(dr["cantidadPacientesPorSexo"]);
                    fila["Porcentaje"] = Convert.ToInt32(dr["cantidadPacientesPorSexo"]);
                    estadistica.Rows.Add(fila);
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static DataTable CantidadPacientesPorSexoDataTable()
        {
            DataTable estadistica = new DataTable();
            DataRow fila;

            estadistica.Columns.Add("sexo");
            estadistica.Columns.Add("cantidadPacientesPorSexo");
            estadistica.Columns.Add("Porcentaje");

            SqlConnection cn = null;

            try
            {
                cn = new SqlConnection(cadenaConexion);
                setCadenaConexion();
                cn.Open();

                string consulta = @" Select cantM.id, cantM.fecha_registro,cantM.id_sexo,cantM.sexo, cantM.cantidadPacientesPorSexo, cantM.cantidadTotalPacientes, cantM.Porcentaje
                                     from (select top 1 id, fecha_registro,id_sexo,sexo,ISNULL(cantidadPacientesPorSexo,'N/A') as 'cantidadPacientesPorSexo',cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                                                    from cantidadPacientesPorSexo
                                                                    where sexo ='Masculino'
                                                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
								                                    order by fecha_registro desc) cantM
                                                                    UNION
                                     Select cantF.id, cantF.fecha_registro,cantF.id_sexo,cantF.sexo, cantF.cantidadPacientesPorSexo, cantF.cantidadTotalPacientes, cantF.Porcentaje
                                     from (select top 1 id, fecha_registro,id_sexo,sexo,ISNULL(cantidadPacientesPorSexo,'N/A') as 'cantidadPacientesPorSexo',cantidadTotalPacientes, (cantidadPacientesPorSexo*100)/cantidadTotalPacientes as 'Porcentaje'
                                                                    from cantidadPacientesPorSexo
                                                                    where sexo ='Femenino'
                                                                    and convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
								                                    order by fecha_registro desc) cantF";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = estadistica.NewRow();
                    fila["sexo"] = dr["sexo"].ToString();
                    fila["cantidadPacientesPorSexo"] = Convert.ToInt32(dr["cantidadPacientesPorSexo"]);
                    fila["Porcentaje"] = Convert.ToInt32(dr["Porcentaje"]);
                    estadistica.Rows.Add(fila);
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        /*
        Metodo para buscar la cantidad de pacientes por categoria 
        */
        public static List<EstadisticaCategoriaSitio> CantidadPacientesPorCategoría()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 14  id,fecha_registro,categoria,cantidadPacientes,totalPacientes,conExamen
                                    from Estadistica_MedicionesPorCategoria
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate() , 3)
                                    order by fecha_registro desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCategoriaSitio()
                    {
                        id = (int)dr["id"],
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        Categoria = dr["categoria"].ToString(),
                        CantidadPacientes = Convert.ToInt32(dr["cantidadPacientes"]),
                        TotalPacientes = Convert.ToInt32(dr["totalPacientes"]),
                        ConExamen = dr["conExamen"].ToString()
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }

        public static DataTable CantidadPacientesPorCategoríaDataTableConExamen()
        {
            DataTable estadistica = new DataTable();
            DataRow fila;

            estadistica.Columns.Add("fecha_registro");
            estadistica.Columns.Add("categoria");
            estadistica.Columns.Add("cantidadPacientes");
            estadistica.Columns.Add("totalPacientes");
            estadistica.Columns.Add("conExamen");
            estadistica.Columns.Add("porcentaje");

            SqlConnection cn = null;

            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 7  id,fecha_registro,categoria,cantidadPacientes,totalPacientes,conExamen,((cantidadPacientes*100)/totalPacientes) as 'porcentaje'
                                    from Estadistica_MedicionesPorCategoria
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate() , 3)
                                    and conExamen like 'ConExamen'
                                    order by fecha_registro desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = estadistica.NewRow();
                    fila["fecha_registro"] = dr["fecha_registro"].ToString();
                    fila["categoria"] = dr["categoria"].ToString();
                    fila["cantidadPacientes"] = Convert.ToInt32(dr["cantidadPacientes"]);
                    fila["totalPacientes"] = Convert.ToInt32(dr["totalPacientes"]);
                    fila["conExamen"] = dr["conExamen"].ToString();
                    fila["porcentaje"] = Convert.ToDouble(dr["porcentaje"]);
                    estadistica.Rows.Add(fila);

                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static DataTable CantidadPacientesPorCategoríaDataTableSinExamen()
        {
            DataTable estadistica = new DataTable();
            DataRow fila;

            estadistica.Columns.Add("fecha_registro");
            estadistica.Columns.Add("categoria");
            estadistica.Columns.Add("cantidadPacientes");
            estadistica.Columns.Add("totalPacientes");
            estadistica.Columns.Add("conExamen");
            estadistica.Columns.Add("porcentaje");

            SqlConnection cn = null;

            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 7 id,fecha_registro,categoria,cantidadPacientes,totalPacientes,conExamen,((cantidadPacientes*100)/totalPacientes) as 'porcentaje'
                                    from Estadistica_MedicionesPorCategoria
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    and conExamen like 'SinExamen'
                                    order by fecha_registro desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    fila = estadistica.NewRow();
                    fila["fecha_registro"] = dr["fecha_registro"].ToString();
                    fila["categoria"] = dr["categoria"].ToString();
                    fila["cantidadPacientes"] = Convert.ToInt32(dr["cantidadPacientes"]);
                    fila["totalPacientes"] = Convert.ToInt32(dr["totalPacientes"]);
                    fila["conExamen"] = dr["conExamen"].ToString();
                    fila["porcentaje"] = Convert.ToDouble(dr["porcentaje"]);
                    estadistica.Rows.Add(fila);

                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> PromedioMedicionesConYSinExamen()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select id, fecha_registro,ConExamen,PromedioSistolica,PromedioDiastolica
                                     from Estadistica_PromedioSitioMedicion
                                     where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    and (ConExamen like 'SinExamen' or ConExamen like 'ConExamen')
                                    and sitioMedicion is null
                                    and extremidad is null
                                    order by id desc;";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCategoriaSitio()
                    {
                        id = (int)dr["id"],
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        ConExamen = dr["ConExamen"].ToString(),
                        PromedioSistolica = Convert.ToInt32(dr["PromedioSistolica"]),
                        PromedioDiastolica = Convert.ToInt32(dr["PromedioDiastolica"]),
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> PromedioMedicionesSitioExtremidad()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 4 id, fecha_registro,sitioMedicion,extremidad,PromedioSistolica,PromedioDiastolica
                                     from Estadistica_PromedioSitioMedicion
                                     where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    and ConExamen is null
									and sitioMedicion is not null
									and extremidad is not null
                                    order by id desc;";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCategoriaSitio()
                    {
                        id = (int)dr["id"],
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        SitioMedicion = dr["sitioMedicion"].ToString(),
                        Extremidad = dr["extremidad"].ToString(),
                        PromedioSistolica = Convert.ToInt32(dr["PromedioSistolica"]),
                        PromedioDiastolica = Convert.ToInt32(dr["PromedioDiastolica"]),
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> PromedioMedicionesSitio()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select id, fecha_registro,sitioMedicion,PromedioSistolica,PromedioDiastolica
                                     from Estadistica_PromedioSitioMedicion
                                     where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    and ConExamen is null
									and sitioMedicion is not null
									and extremidad is null
                                    order by id desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCategoriaSitio()
                    {
                        id = (int)dr["id"],
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        SitioMedicion = dr["sitioMedicion"].ToString(),
                        PromedioSistolica = Convert.ToInt32(dr["PromedioSistolica"]),
                        PromedioDiastolica = Convert.ToInt32(dr["PromedioDiastolica"]),
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static void InsertarEstadisticasMedicionesPromedioCategoria()
        {
            setCadenaConexion();
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);

                SqlCommand cmd = new SqlCommand("p_EstadisticaMediciones_PromedioCategoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static void InsertarEstadisticasSitioMedicionPromedio()
        {
            setCadenaConexion();
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(cadenaConexion);

                SqlCommand cmd = new SqlCommand("p_SitioMedicion_Promedio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static List<EstadisticaCategoriaSitio> PromedioSistolicaConsultorio()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select top 14  id,fecha_registro,categoria,cantidadPacientes,totalPacientes,conExamen
                                    from Estadistica_MedicionesPorCategoria
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate() , 3)
                                    order by fecha_registro desc";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    estadistica.Add(new EstadisticaCategoriaSitio()
                    {
                        id = (int)dr["id"],
                        FechaRegistro = Convert.ToDateTime(dr["fecha_registro"]),
                        Categoria = dr["categoria"].ToString(),
                        CantidadPacientes = Convert.ToInt32(dr["cantidadPacientes"]),
                        TotalPacientes = Convert.ToInt32(dr["totalPacientes"]),
                        ConExamen = dr["conExamen"].ToString()
                    });
                }
                cn.Close();
                return estadistica;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static Boolean ExisteCantidadPacientesPorSexo()
        {
            List<EstadisticaCategoriaSitio> estadistica = new List<EstadisticaCategoriaSitio>();
            SqlConnection cn = null;
            Boolean existe=false;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select count(*)
                                    from cantidadPacientesPorSexo 
                                    where convert(varchar,fecha_registro,5)=convert(varchar,GETDATE(),5)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if(Convert.ToInt32(dr[0])>0)
                        existe = true;
                }  

                cn.Close();
                return existe;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static Boolean ExisteMedicionesPorCategoria()
        {
            SqlConnection cn = null;
            Boolean existe = false;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select count(*)
                                    from Estadistica_MedicionesPorCategoria
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate() , 3)";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if(Convert.ToInt32(dr[0]) > 0 )
                        existe = true;
                }
                    

                cn.Close();

                return existe;
            }
            catch (SqlException e)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                throw e;
            }
        }
        public static Boolean ExistePromedioSitioMedicion()
        {
            SqlConnection cn = null;
            Boolean existe = false;
            try
            {
                setCadenaConexion();
                cn = new SqlConnection(cadenaConexion);
                cn.Open();

                string consulta = @"select count(*)
                                    from Estadistica_PromedioSitioMedicion
                                    where convert(varchar, fecha_registro, 3)=convert(varchar, getdate(), 3)
                                    and ConExamen is null
									and sitioMedicion is not null
									and extremidad is null";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if(Convert.ToInt32(dr[0]) > 0)
                        existe = true;
                }
                   

                cn.Close();

                return existe;
            }
            catch (SqlException e)
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
