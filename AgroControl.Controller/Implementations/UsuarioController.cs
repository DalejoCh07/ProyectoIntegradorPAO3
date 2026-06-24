using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class UsuarioController : IUsuarioController
    {
        private readonly IUsuarioDAO _dao = new UsuarioDAO();

        public Usuario? Login(string nombre, string contrasena) => _dao.ValidarLogin(nombre, contrasena);
        public void Registrar(Usuario usuario) => _dao.Insert(usuario);
        public System.Data.DataTable Listar(string? filtro = null) => _dao.GetUsuarios(filtro);
        public void Eliminar(int idUsuario) => _dao.Delete(idUsuario);
    }
}
