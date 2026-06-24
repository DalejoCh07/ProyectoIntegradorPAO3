using System.Data;
using System.Data.SqlClient;
using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;

namespace AgroControl.Model.DAO.Implementations
{
    public class UsuarioDAO : IUsuarioDAO
    {
        public Usuario? ValidarLogin(string nombre, string contrasena)
        {
            string sql = "SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS WHERE nombre = @nombre AND contrasena = @contrasena";
            var pars = new List<SqlParameter>
            {
                new("@nombre", nombre), new("@contrasena", contrasena)
            };
            DataTable dt = DataAccess.GetQuery(sql, pars);
            if (dt.Rows.Count == 0) return null;
            return new Usuario
            {
                IdUsuario = Convert.ToInt32(dt.Rows[0]["idUsuario"]),
                Nombre = dt.Rows[0]["nombre"].ToString()!,
                TipoUsuario = dt.Rows[0]["tipoUsuario"].ToString()!
            };
        }

        public void Insert(Usuario usuario)
        {
            string sql = "INSERT INTO USUARIOS (nombre, contrasena, tipoUsuario) VALUES (@nombre, @password, @rol)";
            var pars = new List<SqlParameter>
            {
                new("@nombre", usuario.Nombre),
                new("@password", usuario.Contrasena),
                new("@rol", usuario.TipoUsuario)
            };
            DataAccess.ExecQuery(sql, pars);
        }

        public DataTable GetUsuarios(string? filtro = null)
        {
            if (string.IsNullOrEmpty(filtro))
                return DataAccess.GetQuery("SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS ORDER BY nombre");
            var pars = new List<SqlParameter> { new("@filtro", "%" + filtro + "%") };
            return DataAccess.GetQuery("SELECT idUsuario, nombre, tipoUsuario FROM USUARIOS WHERE nombre LIKE @filtro ORDER BY nombre", pars);
        }

        public void Delete(int idUsuario)
        {
            var pars = new List<SqlParameter> { new("@id", idUsuario) };
            DataAccess.ExecQuery("DELETE FROM USUARIOS WHERE idUsuario = @id", pars);
        }
    }
}
