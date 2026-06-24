using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IGreenhouseDAO
    {
        int Insert(Greenhouse gh);
        List<Greenhouse> GetAll();
        List<Greenhouse> Search(string nombre);
        void Delete(int id);
    }
}
