using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using WCFNullPointers.Dominio;
using System.Web.Script.Serialization;

namespace WCFNullPointers.Persistencia
{
    public class UsuarioDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";
        private object conexion;

        public string Crear(Usuario usuarioACrear)
        {
            long id;
            Respuesta respuesta = new Respuesta();
            string sql = "insert into usuarios (codigo, contrasena, dni, nombre, apellidos, telefono) values (@codigo, @contrasena, @dni, @nombre, @apellidos, @telefono)";

            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@codigo", usuarioACrear.Codigo));
                        comando.Parameters.Add(new MySqlParameter("@contrasena", usuarioACrear.Contrasena));
                        comando.Parameters.Add(new MySqlParameter("@dni", usuarioACrear.Dni));
                        comando.Parameters.Add(new MySqlParameter("@nombre", usuarioACrear.Nombre));
                        comando.Parameters.Add(new MySqlParameter("@apellidos", usuarioACrear.Apellidos));
                        comando.Parameters.Add(new MySqlParameter("@telefono", usuarioACrear.Telefono));
                        comando.ExecuteNonQuery();
                        id = comando.LastInsertedId;
                    }
                }
                catch (Exception e)
                {
                    respuesta.code = 200;
                    respuesta.error = e.ToString();
                    return new JavaScriptSerializer().Serialize(respuesta);
                }
                conexion.Close();
                return Obtener(id);
            }
        }
        public string Obtener(long id)
        {
            Usuario usuarioEncontrado = null;
            Respuesta respuesta = new Respuesta();
            string sql = "select * from usuarios where id = @id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@id", id));
                        using (MySqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                usuarioEncontrado = new Usuario()
                                {
                                    Id = (int)resultado["id"],
                                    Codigo = (string)resultado["codigo"],
                                    Contrasena = (string)resultado["contrasena"],
                                    Dni = (string)resultado["dni"],
                                    Nombre = (string)resultado["nombre"],
                                    Apellidos = (string)resultado["apellidos"],
                                    Telefono = (string)resultado["telefono"]
                                };
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    respuesta.code = 200;
                    respuesta.error = e.ToString();
                    return new JavaScriptSerializer().Serialize(respuesta);
                }
                respuesta.code = 100;
                respuesta.data = new JavaScriptSerializer().Serialize(usuarioEncontrado);
                conexion.Close();
                return new JavaScriptSerializer().Serialize(respuesta);
            }
        }
        public string Login(string codigo, string contrasena)
        {
            Usuario usuarioEncontrado = null;
            Respuesta respuesta = new Respuesta();
            string sql = "select * from usuarios where codigo = @codigo and contrasena = @contrasena";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@codigo", codigo));
                        comando.Parameters.Add(new MySqlParameter("@contrasena", contrasena));
                        using (MySqlDataReader resultado = comando.ExecuteReader())
                        {
                            if (resultado.Read())
                            {
                                usuarioEncontrado = new Usuario()
                                {
                                    Id = (int)resultado["id"],
                                    Codigo = (string)resultado["codigo"],
                                    Contrasena = (string)resultado["contrasena"],
                                    Dni = (string)resultado["dni"],
                                    Nombre = (string)resultado["nombre"],
                                    Apellidos = (string)resultado["apellidos"],
                                    Telefono = (string)resultado["telefono"]
                                };
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    respuesta.code = 200;
                    respuesta.error = e.ToString();
                    return new JavaScriptSerializer().Serialize(respuesta);
                }
                respuesta.code = 100;
                respuesta.data = new JavaScriptSerializer().Serialize(usuarioEncontrado);
                conexion.Close();
                return new JavaScriptSerializer().Serialize(respuesta);
            }
        }
        public string Modificar (Usuario usuarioAModificar)

            {
            Usuario usuarioModificado = null;
            Respuesta respuesta = new Respuesta();
            string sql = "UPDATE usuario SET codigo=@codigo, contrasena=@contrasena, dni=@dni, nombre=@nombre, apellidos=@apellidos, telefono=@telefono WHERE dni=@dni";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                try
                { 
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@codigo",usuarioAModificar.Codigo));
                        comando.Parameters.Add(new MySqlParameter("@contrasena", usuarioAModificar.Contrasena));
                        comando.Parameters.Add(new MySqlParameter("@dni", usuarioAModificar.Dni));
                        comando.Parameters.Add(new MySqlParameter("@nombre", usuarioAModificar.Nombre));
                        comando.Parameters.Add(new MySqlParameter("@apellidos", usuarioAModificar.Apellidos));
                        comando.Parameters.Add(new MySqlParameter("@telefono", usuarioAModificar.Telefono));
                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    respuesta.code = 200;
                    respuesta.error = e.ToString();
                    return new JavaScriptSerializer().Serialize(respuesta);
                }
                respuesta.code = 100;
                respuesta.data = new JavaScriptSerializer().Serialize(usuarioAModificar);
                conexion.Close();
                return new JavaScriptSerializer().Serialize(respuesta);
            }


        }

        public void Eliminar(int dni)

        {
            string sql = "DELETE FROM usuario WHERE dni=@dni";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
            
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuarioEncontrados = new List<Usuario>();
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM usuarios";
            using (MySqlCommand comando = new MySqlCommand(sql, conexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using(MySqlDataReader resultado = comando.ExecuteReader())
                    { 
                        while (resultado.Read())
                    {
                            usuarioEncontrado = new Usuario()
                            {
                                Id = (int)resultado["id"],
                                Codigo = (string)resultado["codigo"],
                                Contrasena = (string)resultado["contrasena"],
                                Dni = (string)resultado["dni"],
                                Nombre = (string)resultado["nombre"],
                                Apellidos = (string)resultado["apellidos"],
                                Telefono = (string)resultado["telefono"]

                            };
                            usuarioEncontrados.Add(usuarioEncontrado);
                        }
                      }

                }
            return usuarioEncontrados;
        }
    }
}