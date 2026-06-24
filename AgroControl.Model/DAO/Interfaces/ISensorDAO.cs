using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface ISensorDAO
    {
        int Insert(Sensor sensor);
        Sensor? GetById(int id);
        List<Sensor> GetAll();
        List<Sensor> GetByGreenhouse(int idInv);
        void Delete(int id);
    }
}
