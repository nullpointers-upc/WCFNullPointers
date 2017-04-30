using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WCFNullPointers.Dominio;


namespace WCFNullPointers.Persistencia
{
    public class PedidoDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";

        public Pedido Crear(Pedido pedido)
        {
            long id;
            Respuesta respuesta = new Respuesta();
            string sql = "insert into pedidos (fecha, usuarioId, direccion, estado, total) values (@fecha, @usuarioId, @direccion, @estado, @total)";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@fecha", pedido.Fecha));
                    comando.Parameters.Add(new MySqlParameter("@usuarioId", pedido.UsuarioId));
                    comando.Parameters.Add(new MySqlParameter("@direccion", pedido.Direccion));
                    comando.Parameters.Add(new MySqlParameter("@estado", pedido.Estado));
                    comando.Parameters.Add(new MySqlParameter("@total", pedido.Total));
                    comando.ExecuteNonQuery();
                    id = comando.LastInsertedId;
                }
                conexion.Close();
                return Obtener((int)id);
            }

        }

        public  Pedido Obtener(int id)
        {
            Pedido pedido = null;
            string sql = "select * from pedidos where id = @id";
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
                            pedido = new Pedido()
                            {
                                Id = (int)resultado["id"],
                                Fecha = (DateTime)resultado["fecha"],
                                UsuarioId = (int)resultado["usuarioId"],
                                Direccion = (string)resultado["direccion"],
                                Estado = (int)resultado["estado"]
                            };
                        }
                    }
                }

                pedido.detalles = ListarDetalles(pedido.Id);

                return pedido;
            }


        }

        public Pedido Modificar(Pedido pedido)
        {
            string sql = "update pedidos set fecha=@fecha, usuarioId=@usuarioId, direccion=@direccion, estado=@estado, total=@total where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@fecha", pedido.Fecha));
                    comando.Parameters.Add(new MySqlParameter("@usuarioId", pedido.UsuarioId));
                    comando.Parameters.Add(new MySqlParameter("@direccion", pedido.Direccion));
                    comando.Parameters.Add(new MySqlParameter("@estado", pedido.Estado));
                    comando.Parameters.Add(new MySqlParameter("@total", pedido.Total));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
                return Obtener(pedido.Id);
            }

        }

        public void Eliminar (int Id)
        {
            string sql = "delete from pedidos where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@id", Id));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }

        }

        public List<Pedido> Listar()
        {
            List<Pedido> pedidos = new List<Pedido>();
            Pedido pedido = null;
            string sql = "select * from pedidos";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using (MySqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedido = new Pedido()
                            {
                                Id = (int)resultado["id"],
                                Fecha = (DateTime)resultado["fecha"],
                                UsuarioId = (int)resultado["usuarioId"],
                                Direccion = (string)resultado["direccion"],
                                Estado = (int)resultado["estado"],
                                Total = (decimal)resultado["total"],

                            };
                            pedidos.Add(pedido);
                        }
                    }
                }
            }
            return pedidos;
        }


        public List<PedidoDetalle> ListarDetalles(int id)
        {
            List<PedidoDetalle> pedidosDetalle = new List<PedidoDetalle>();
            PedidoDetalle pedidoDetalle = null;
            string sql = "select * from pedidosDetalle where pedidoId = " + id;
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using (MySqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            pedidoDetalle = new PedidoDetalle()
                            {
                                Id = (int)resultado["id"],
                                PedidoId = (int)resultado["pedidoId"],
                                ProductoId = (int)resultado["productoId"],
                                Cantidad = (int)resultado["cantidad"],
                                Precio = (decimal)resultado["precio"],
                                Total = (decimal)resultado["total"]
                            };
                            pedidosDetalle.Add(pedidoDetalle);
                        }
                    }
                }
            }
            return pedidosDetalle;
        }












    }
}