using AgroControl.Model.Entities;

namespace AgroControl.Model.DAO.Interfaces
{
    public interface IBatchDAO
    {
        Batch? GetActivo(int idInv);
        void Insert(Batch lote);
        void Finalizar(int idLote);
        System.Data.DataTable GetHistorial(int idInv);
    }
}
