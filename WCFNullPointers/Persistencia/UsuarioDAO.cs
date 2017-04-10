using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFNullPointers.Dominio;

namespace WCFNullPointers.Persistencia
{
    public class UsuarioDAO
    {
        private string CadenaConexion = "Data Source=(local);Initial Catalog=nullpointer;Integrated Security=SSPI;";
        public Usuario Crear(Usuario usuarioACrear)
        {
            Usuario usuarioCreado = null;
            string sql = "insertUsuario";
            int id;
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@nombre", usuarioACrear.Nombre));
                    comando.Parameters.Add(new SqlParameter("@clave", usuarioACrear.Clave));
                    comando.Parameters.Add(new SqlParameter("@dni", usuarioACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@telefono", usuarioACrear.Telefono));
                    comando.Parameters.Add(new SqlParameter("@nombreCompleto", usuarioACrear.NombreCompleto));
                    SqlParameter usuarioId = new SqlParameter("@id", SqlDbType.Int);
                    usuarioId.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(usuarioId);
                    comando.ExecuteNonQuery();
                    id = (int)comando.Parameters["@id"].Value;
                }
                usuarioCreado = Obtener(id);
                return usuarioCreado;
            }
        }
        public Usuario Obtener(int id)
        {
            Usuario usuarioEncontrado = null;
            string sql = "select * from usuario where id = @id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@id", id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                Nombre = (string)resultado["nombre"],
                                Clave = (string)resultado["clave"],
                                Dni = (string)resultado["dni"],
                                Telefono = (string)resultado["telefono"],
                                NombreCompleto = (string)resultado["nombreCompleto"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }
    }
}