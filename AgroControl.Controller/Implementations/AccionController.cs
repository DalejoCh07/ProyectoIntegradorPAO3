using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class AccionController : IAccionController
    {
        private readonly IAccionDAO _dao = new AccionDAO();

        public int Insertar(Accion accion) => _dao.Insert(accion);
        public List<Accion> Listar() => _dao.GetAll();
        public List<Accion> ListarPorInvernadero(int idInv) => _dao.GetByGreenhouse(idInv);
        public List<Accion> ListarPorActuador(int idActuador) => _dao.GetByActuador(idActuador);
    }
}
