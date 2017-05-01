﻿using MySql.Data.MySqlClient;
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
                    
                    id = comando.LastInsertedId;
                }

                sql = "insert into pedidosDetalle (pedidoId, productoId, cantidad, precio, total) values (@pedidoId, @productoId, @cantidad, @precio, @total)";
                foreach (PedidoDetalle detalle in pedido.detalles)
                {
                    using(MySqlCommand comando = new MySqlCommand(sql, conexion))
                    {
                        comando.Parameters.Add(new MySqlParameter("@pedidoId", id));
                        comando.Parameters.Add(new MySqlParameter("@productoId", detalle.ProductoId));
                        comando.Parameters.Add(new MySqlParameter("@cantidad", detalle.Cantidad));
                        comando.Parameters.Add(new MySqlParameter("@precio", detalle.Precio));
                        comando.Parameters.Add(new MySqlParameter("@total", detalle.Total));
                        comando.ExecuteNonQuery();
                    }
                }
                    conexion.Close();
                    return Obtener((int)id);
            }
          
        }

        public Pedido Obtener(int id)
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
                                Estado = (int)resultado["estado"],
                                Total = (decimal)resultado["total"]
                            };
                        }
                    }
                }
                pedido.detalles = ListarDetalles(pedido.Id);
                return pedido;
            }
        }

        public void Eliminar (int Id)
        {
            string sql = "delete from pedidosDetalle where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                  conexion.Open();
                  using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                   {
                    comando.Parameters.Add(new MySqlParameter("@id", Id));
                    comando.ExecuteNonQuery();
                   }
                    sql = "delete from pedidos where id=@id";
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
                                Total = (decimal)resultado["total"]
                            };
                            pedido.detalles = ListarDetalles(pedido.Id);
                            pedidos.Add(pedido);
                        }
                    }
                }
                conexion.Close();
            }
            return pedidos;
        }

        public List<PedidoDetalle> ListarDetalles(int id)
        {
            List<PedidoDetalle> pedidosDetalle = new List<PedidoDetalle>();
            PedidoDetalle pedidoDetalle = null;
            string sql = "select pd.*, pr.nombre productoNombre from pedidosDetalle pd join productos pr on pr.id = pd.productoId where pd.pedidoId = " + id;
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
                                ProductoNombre = (string)resultado["productoNombre"],
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

        public Pedido ActualizarEstado(int id, int estado)
        {
            string sql = "update pedidos set estado=@estado where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@id", id));
                    comando.Parameters.Add(new MySqlParameter("@estado", estado));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
                return Obtener(id);
            }
        }
    }
}