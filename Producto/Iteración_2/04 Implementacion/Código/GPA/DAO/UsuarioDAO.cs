﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Clases;
using System.Data;

namespace DAO
{
    public class UsuarioDAO
    {
        //private static string cadenaConexion = "Data Source=PABLO\\SQLEXPRESS;Initial Catalog=GPA_BD_2;Integrated Security=True";
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
        public static List<Usuario> buscarContraseñaUsuario(string nombre)
        {
            List<Usuario> usuario = new List<Usuario>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "select contraseña from Usuario where nombre_usuario=@nombre";

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@nombre", nombre);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usuario.Add(new Usuario()
                {
                    pass =dr["contraseña"].ToString(),
                });
            }
            cn.Close();
            return usuario;
        }

        /*
         * 
         * Método para que buscar un usuario.
         * Toma como parámetros el nombre y la contraseña del usuario.
         * Accede a la base de datos obtiene el id_usuario.
         * Retorna el usuario correspondiente.
         * 
         */
        public static List<Usuario> buscarUsuario(string nombre, string pass)
        {
            setCadenaConexion();
            List<Usuario> usuarios = new List<Usuario>();
            
            SqlConnection cn = new SqlConnection(getCadenaConexion());
            try
            {

                cn.Open();

                string consulta = "select id_usuario from Usuario where nombre_usuario=@nombre and pwdcompare(@pass,contraseña)=1";

                SqlCommand cmd = new SqlCommand();


                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@pass", pass);


                cmd.CommandText = consulta;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        id_usuario = (int)dr["id_usuario"],
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
            return usuarios;
        }

        public static List<Usuario> buscarUsuarioPorNombre(string nombre)
        {
            List<Usuario> usuarios = new List<Usuario>();

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();

            string consulta = "SELECT id_usuario FROM Usuario WHERE nombre_usuario LIKE @paramNombre";

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.AddWithValue("@paramNombre", nombre);

            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usuarios.Add(new Usuario()
                {
                    id_usuario = (int)dr["id_usuario"],
                });
            }
            cn.Close();
            return usuarios;
        }
    }
}
