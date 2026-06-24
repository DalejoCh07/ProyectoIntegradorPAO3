using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IReadingDAO
    {
        int Insert(Reading reading);
        List<Reading> GetAll();
        System.Data.DataTable GetHistorialPivot(int idInv);
        System.Data.DataTable GetEstadisticas(DateTime desde, DateTime hasta, int idInv);
        decimal GetUltimaLectura(int idSensor, int idInv);
    }
}
