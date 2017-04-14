﻿using System;
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
                //  return Obtener(id);
                return "bingo";
            }
        }      
    }
}