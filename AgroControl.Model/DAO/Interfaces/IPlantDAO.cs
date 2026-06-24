using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IPlantDAO
    {
        int Insert(Plant plant);
        Plant? GetById(int id);
        List<Plant> GetAll();
        List<Plant> Search(string nombre);
        void Delete(int id);
    }
}
