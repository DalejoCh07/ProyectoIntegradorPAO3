using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class RequirementsController : IRequirementsController
    {
        private readonly IRequirementsDAO _dao = new RequirementsDAO();

        public int Agregar(Requirements req) => _dao.Insert(req);
        public List<Requirements> ObtenerPorPlanta(int idPlanta) => _dao.GetByPlant(idPlanta);
    }
}
