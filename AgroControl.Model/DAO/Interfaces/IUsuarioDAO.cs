using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IUsuarioDAO
    {
        Usuario? ValidarLogin(string nombre, string contrasena);
        void Insert(Usuario usuario);
        System.Data.DataTable GetUsuarios(string? filtro = null);
        void Delete(int idUsuario);
    }
}
