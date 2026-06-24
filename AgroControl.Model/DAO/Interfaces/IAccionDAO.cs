using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IAccionDAO
    {
        int Insert(Accion accion);
        List<Accion> GetAll();
        List<Accion> GetByGreenhouse(int idInv);
        List<Accion> GetByActuador(int idActuador);
    }
}
