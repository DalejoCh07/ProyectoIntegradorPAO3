using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IUsuarioController
    {
        Usuario? Login(string nombre, string contrasena);
        void Registrar(Usuario usuario);
        System.Data.DataTable Listar(string? filtro = null);
        void Eliminar(int idUsuario);
    }
}
