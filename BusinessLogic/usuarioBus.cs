using System.Security.Cryptography;
using System.Text;
using DataAccess; // Referencia a tu clase DataAccess
using Entities; // Referencia a tu capa de entidades
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogic
{
    public class UsuarioBus
    {
        public static Usuario ValidarLogin(string nombreUsuario, string contrasena)
        {
            // 1. Preparamos la consulta SQL con parámetros (@) para evitar Inyección SQL
            string sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS WHERE nombre = @nombre AND contrasena = @contrasena";

            // 2. Armamos la lista de parámetros usando List<SqlParameter> como lo pide tu DataAccess
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombreUsuario));
            parametros.Add(new SqlParameter("@contrasena", contrasena));

            // 3. Ejecutamos la consulta usando el método getQuery (que es el que devuelve un DataTable)
            // Nota: Si tu clase DataAccess está dentro de otro namespace, asegúrate de llamarla correctamente, por ejemplo: AccesoDatos.DataAccess.getQuery(...)
            DataTable dt = DataAccess.DataAccess.getQuery(sql, parametros);

            // 4. Verificamos si la base de datos nos devolvió algún registro
            if (dt.Rows.Count > 0)
            {
                // ¡Éxito! Las credenciales coinciden. Llenamos el objeto Usuario.
                Usuario usuarioLogueado = new Usuario();
                usuarioLogueado.IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]);
                usuarioLogueado.Nombre = dt.Rows[0]["nombre"].ToString();
                usuarioLogueado.TipoUsuario = dt.Rows[0]["tipoUsuario"].ToString();

                return usuarioLogueado;
            }
            else
            {
                // Falló el login (usuario no existe o clave incorrecta)
                return null;
            }
        }

        // Agrega este método dentro de tu clase UsuarioBus existente
        public static void insertar(Usuario usuario)
        {
            string sql = "INSERT INTO USUARIOS (nombre, contrasena, tipoUsuario) VALUES (@nombre, @password, @rol)";

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", usuario.Nombre));
            parametros.Add(new SqlParameter("@password", usuario.Contrasena)); // Ajusta "Contrasena" si tu propiedad se llama distinto en la Entidad
            parametros.Add(new SqlParameter("@rol", usuario.TipoUsuario));

            DataAccess.DataAccess.execQuery(sql, parametros);
        }
        public static DataTable getUsuarios(string filtro = "")
        {
            string sql;
            List<SqlParameter> parametros = new List<SqlParameter>();

            if (string.IsNullOrEmpty(filtro))
            {
                sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS ORDER BY nombre";
            }
            else
            {
                sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS WHERE nombre LIKE @filtro ORDER BY nombre";
                parametros.Add(new SqlParameter("@filtro", "%" + filtro + "%"));
            }

            return parametros.Count > 0
                ? DataAccess.DataAccess.getQuery(sql, parametros)
                : DataAccess.DataAccess.getQuery(sql);
        }

        // Método para eliminar un usuario por su ID
        public static void eliminar(int idUsuario)
        {
            string sql = "DELETE FROM USUARIOS WHERE idUsuario = @id";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@id", idUsuario)
            };

            DataAccess.DataAccess.execQuery(sql, parametros);
        }

    }
}
