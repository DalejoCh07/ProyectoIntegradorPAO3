using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class GreenhouseController : IGreenhouseController
    {
        private readonly IGreenhouseDAO _dao = new GreenhouseDAO();

        public int Agregar(Greenhouse gh) => _dao.Insert(gh);
        public List<Greenhouse> Listar() => _dao.GetAll();
        public List<Greenhouse> Buscar(string nombre) => _dao.Search(nombre);
        public void Eliminar(int id) => _dao.Delete(id);
    }
}
