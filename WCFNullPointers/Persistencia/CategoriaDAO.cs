using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using WCFNullPointers.Dominio;
using System.Web.Script.Serialization;

namespace WCFNullPointers.Persistencia
{
    public class CategoriaDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";
        public string Crear(Categoria categoria)
        {
            long id;
            Respuesta respuesta = new Respuesta();
            string sql = "insert into categorias (nombre, estado) values (@nombre, @estado)";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@nombre", categoria.Nombre));
                        comando.Parameters.Add(new MySqlParameter("@estado", categoria.Estado));
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
            Categoria categoriaEncontrado = null;
            string sql = "select * from categorias where id = @id";
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
                            categoriaEncontrado = new Categoria()
                            {
                                Id = (int)resultado["id"],
                                Nombre = (string)resultado["nombre"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }
                conexion.Close();
                return new JavaScriptSerializer().Serialize(categoriaEncontrado);
            }
        }
        public string Modificar(Categoria categoriaAModificar)
        {
            string sql = "UPDATE categorias SET nombre=@nombre, estado=@estado WHERE id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@id", categoriaAModificar.Id));
                    comando.Parameters.Add(new MySqlParameter("@nombre", categoriaAModificar.Nombre));
                    comando.Parameters.Add(new MySqlParameter("@estado", categoriaAModificar.Estado));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
                return Obtener(categoriaAModificar.Id);
            }
        }

        public void Eliminar(int id)
        {
            string sql = "DELETE FROM categorias WHERE id=@id";
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

        public List<Categoria> Listar()
        {
            List<Categoria> categoriaEncontrados = new List<Categoria>();
            Categoria categoriaEncontrado = null;
            string sql = "SELECT * FROM categorias";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using (MySqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            categoriaEncontrado = new Categoria()
                            {
                                Id = (int)resultado["id"],
                                Nombre = (string)resultado["nombre"],
                                Estado = (int)resultado["estado"]
                            };
                            categoriaEncontrados.Add(categoriaEncontrado);
                        }
                    }

                }
            }
            return categoriaEncontrados;
        }
    }
}