using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IActuadorDAO
    {
        int Insert(Actuador act);
        List<Actuador> GetAll();
        List<Actuador> GetByGreenhouse(int idInv);
        void Delete(int id);
        string GetEstado(int idActuador, int idInv);
        void SetEstado(int idActuador, int idInv, string estado);
    }
}
