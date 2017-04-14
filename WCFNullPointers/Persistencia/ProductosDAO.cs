using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using WCFNullPointers.Dominio;
using System.Web.Script.Serialization;


namespace WCFNullPointers.Persistencia
{
    public class ProductosDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";
        private object conexion;

        public string Crear(Productos ProductosACrear)
        {
            long id;
            Respuesta respuesta = new Respuesta();
            string sql = "insert into Productos (nombre, descripcion, precio, descuento, presentacion, categoriaId, estado) values (@nombre, @descripcion, @precio, @descuento, @presentacion, @categoriaId, @estado)";
    
        using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                
                    conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@nombre", ProductosACrear.nombre));
                        comando.Parameters.Add(new MySqlParameter("@descripcion", ProductosACrear.descripcion));
                        comando.Parameters.Add(new MySqlParameter("@precio", ProductosACrear.precio));
                        comando.Parameters.Add(new MySqlParameter("@descuento", ProductosACrear.Descuento));
                        comando.Parameters.Add(new MySqlParameter("@presentacion", ProductosACrear.Presentacion));
                        comando.Parameters.Add(new MySqlParameter("@categoriaId", ProductosACrear.CategoriaId));
                        comando.Parameters.Add(new MySqlParameter("@estado", ProductosACrear.Estado));
                        comando.ExecuteNonQuery();
                        id = comando.LastInsertedId;
                    }
                
            
                conexion.Close();
                return Obtener(id);
            }
        }
    }
}