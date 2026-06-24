using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IRequirementsDAO
    {
        int Insert(Requirements req);
        List<Requirements> GetByPlant(int idPlanta);
    }
}
