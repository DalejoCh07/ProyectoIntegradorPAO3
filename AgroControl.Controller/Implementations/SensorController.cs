using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class SensorController : ISensorController
    {
        private readonly ISensorDAO _dao = new SensorDAO();

        public int Agregar(Sensor sensor) => _dao.Insert(sensor);
        public Sensor? Obtener(int id) => _dao.GetById(id);
        public List<Sensor> Listar() => _dao.GetAll();
        public List<Sensor> ListarPorInvernadero(int idInv) => _dao.GetByGreenhouse(idInv);
        public void Eliminar(int id) => _dao.Delete(id);
    }
}
