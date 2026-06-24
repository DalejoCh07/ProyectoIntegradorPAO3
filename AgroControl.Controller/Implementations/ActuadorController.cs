using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class ActuadorController : IActuadorController
    {
        private readonly IActuadorDAO _dao = new ActuadorDAO();

        public int Agregar(Actuador act) => _dao.Insert(act);
        public List<Actuador> Listar() => _dao.GetAll();
        public List<Actuador> ListarPorInvernadero(int idInv) => _dao.GetByGreenhouse(idInv);
        public void Eliminar(int id) => _dao.Delete(id);
        public string ObtenerEstado(int idActuador, int idInv) => _dao.GetEstado(idActuador, idInv);
        public void CambiarEstado(int idActuador, int idInv, string estado) => _dao.SetEstado(idActuador, idInv, estado);
    }
}
