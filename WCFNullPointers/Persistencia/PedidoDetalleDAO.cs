﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFNullPointers.Dominio;

namespace WCFNullPointers.Persistencia
{
    public class PedidoDetalleDAO
    {
        private string CadenaConexion = "datasource=localhost;database=nullpointers;userid=root";
        public PedidoDetalle Crear(PedidoDetalle pedidoDetalle)
        {
            long id;
            string sql = "insert into pedidosDetalle (pedidoId, productoId, cantidad, precio, total) values (@pedidoId, @productoId, @cantidad, @precio, @total)";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@pedidoId", pedidoDetalle.PedidoId));
                    comando.Parameters.Add(new MySqlParameter("@productoId", pedidoDetalle.ProductoId));
                    comando.Parameters.Add(new MySqlParameter("@cantidad", pedidoDetalle.Cantidad));
                    comando.Parameters.Add(new MySqlParameter("@precio", pedidoDetalle.Precio));
                    comando.Parameters.Add(new MySqlParameter("@total", pedidoDetalle.Total));
                    comando.ExecuteNonQuery();
                    id = comando.LastInsertedId;
                }
                conexion.Close();
                return Obtener((int)id);
            }
        }
        
        public PedidoDetalle Obtener(int id)
        {
            PedidoDetalle pedidoDetalle = null;
            string sql = "select * from pedidosDetalle where id = @id";
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
                            pedidoDetalle = new PedidoDetalle()
                            {
                                Id = (int)resultado["id"],
                                PedidoId = (int)resultado["pedidoId"],
                                ProductoId = (int)resultado["productoId"],
                                Cantidad = (int)resultado["cantidad"],
                                Precio = (decimal)resultado["precio"],
                                Total = (decimal)resultado["total"]
                            };
                        }
                    }
                }
            }
            return pedidoDetalle;
        }
        
        public PedidoDetalle Modificar(PedidoDetalle pedidoDetalle)
        {
            string sql = "update pedidosDetalle set pedidoId=@pedidoId, productoId=@productoId, cantidad=@cantidad, precio=@precio, total=@total where id=@id";
            using (MySqlConnection conexion = new MySqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new MySqlParameter("@Id", pedidoDetalle.Id));
                    comando.Parameters.Add(new MySqlParameter("@pedidoId", pedidoDetalle.PedidoId));
                    comando.Parameters.Add(new MySqlParameter("@productoId", pedidoDetalle.ProductoId));
                    comando.Parameters.Add(new MySqlParameter("@cantidad", pedidoDetalle.Cantidad));
                    comando.Parameters.Add(new MySqlParameter("@precio", pedidoDetalle.Precio));
                    comando.Parameters.Add(new MySqlParameter("@total", pedidoDetalle.Total));
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
                return Obtener(pedidoDetalle.Id);
            }
        }
        
        public void Eliminar(int id)
        {
            string sql = "delete from pedidosDetalle where id=@id";
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
        
        public List<PedidoDetalle> Listar()
        {
            List<PedidoDetalle> pedidosDetalle = new List<PedidoDetalle>();
            PedidoDetalle pedidoDetalle = null;
            string sql = "select * from pedidosDetalle";
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