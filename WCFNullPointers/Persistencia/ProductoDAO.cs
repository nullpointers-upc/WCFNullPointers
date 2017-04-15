using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WCFNullPointers.Dominio;

namespace WCFNullPointers.Persistencia
{
    public class ProductoDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";
        public string Crear(Producto producto)
        {
            long id;
            Respuesta respuesta = new Respuesta();
            string sql = "insert into productos (nombre, descripcion, precio, descuento, presentacion, categoriaId, estado) values (@nombre, @descripcion, @precio, @descuento, @presentacion, @categoriaId, @estado)";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@nombre", producto.Nombre));
                    comando.Parameters.Add(new MySqlParameter("@descripcion", producto.Descripcion));
                    comando.Parameters.Add(new MySqlParameter("@precio", producto.Precio));
                    comando.Parameters.Add(new MySqlParameter("@descuento", producto.Descuento));
                    comando.Parameters.Add(new MySqlParameter("@presentacion", producto.Presentacion));
                    comando.Parameters.Add(new MySqlParameter("@categoriaId", producto.CategoriaId));
                    comando.Parameters.Add(new MySqlParameter("@estado", producto.Estado));
                    comando.ExecuteNonQuery();
                    id = comando.LastInsertedId;
                }
                conexion.Close();
                return Obtener(id);
            }
        }
        
        public string Obtener(long id)
        {
            Producto producto = null;
            string sql = "select * from productos where id = @id";
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
                            producto = new Producto()
                            {
                                Id = (int)resultado["id"],
                                Nombre = (string)resultado["nombre"],
                                Descripcion = (string)resultado["descripcion"],
                                Precio = (decimal)resultado["precio"],
                                Descuento = (int)resultado["descuento"],
                                Presentacion = (string)resultado["presentacion"],
                                CategoriaId = (int)resultado["categoriaId"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }
                conexion.Close();
                return new JavaScriptSerializer().Serialize(producto);
            }
        }        
        
        public string Modificar(Producto producto)
        {
            string sql = "update productos set nombre=@nombre, descripcion=@descripcion, precio=@precio, descuento=@descuento, presentacion=@presentacion, categoriaId=@categoriaId, estado = @estado where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@nombre", producto.Nombre));
                    comando.Parameters.Add(new MySqlParameter("@descripcion", producto.Descripcion));
                    comando.Parameters.Add(new MySqlParameter("@precio", producto.Precio));
                    comando.Parameters.Add(new MySqlParameter("@descuento", producto.Descuento));
                    comando.Parameters.Add(new MySqlParameter("@presentacion", producto.Presentacion));
                    comando.Parameters.Add(new MySqlParameter("@categoriaId", producto.CategoriaId));
                    comando.Parameters.Add(new MySqlParameter("@estado", producto.Estado));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
                return Obtener(producto.Id);
            }
        }

        public void Eliminar(int id)
        {
            string sql = "delete from productos where id=@id";
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

        public List<Producto> Listar()
        {
            List<Producto> productos = new List<Producto>();
            Producto producto = null;
            string sql = "select * from productos";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using(MySqlDataReader resultado = comando.ExecuteReader())
                    { 
                        while (resultado.Read())
                        {
                            producto = new Producto()
                            {
                                Id = (int)resultado["id"],
                                Nombre = (string)resultado["nombre"],
                                Descripcion = (string)resultado["descripcion"],
                                Precio = (decimal)resultado["precio"],
                                Descuento = (int)resultado["descuento"],
                                Presentacion = (string)resultado["presentacion"],
                                CategoriaId = (int)resultado["categoriaId"],
                                Estado = (int)resultado["estado"]
                            };
                            productos.Add(producto);
                        }
                    }
                }
            }
            return productos;
        }
    }
}