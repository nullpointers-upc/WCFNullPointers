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
        public string Crear(Usuario usuarioACrear)
        {
            long id;
            string sql = "insert into usuarios (codigo, contrasena, dni, nombre, apellidos, telefono) values (@codigo, @contrasena, @dni, @nombre, @apellidos, @telefono)";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
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
                conexion.Close();
                return Obtener(id);
            }
        }

        public string Obtener(long id)
        {
            Usuario usuarioEncontrado = null;
            string sql = "select * from usuarios where id = @id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
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
                conexion.Close();
                return new JavaScriptSerializer().Serialize(usuarioEncontrado);
            }
        }

        public string Login(string codigo, string contrasena)
        {
            Usuario usuarioEncontrado = null;
            string sql = "select * from usuarios where codigo = @codigo and contrasena = @contrasena";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
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
                conexion.Close();
                if (usuarioEncontrado == null)
                    return null;
                else
                    return Obtener(usuarioEncontrado.Id);
            }
        }

        public string Modificar(Usuario usuarioAModificar)
        {
            string sql = "UPDATE usuarios SET codigo=@codigo, contrasena=@contrasena, dni=@dni, nombre=@nombre, apellidos=@apellidos, telefono=@telefono WHERE id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
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
                conexion.Close();
                return Obtener(usuarioAModificar.Id);
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM usuarios WHERE id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@id", id));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> usuariosEncontrados = new List<Usuario>();
            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM usuarios";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
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
                            usuariosEncontrados.Add(usuarioEncontrado);
                        }
                    }

                }
            }
            return usuariosEncontrados;
        }
    }
}