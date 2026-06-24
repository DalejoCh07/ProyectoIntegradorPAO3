using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IBatchController
    {
        Batch? ObtenerActivo(int idInv);
        void Insertar(Batch lote);
        void Finalizar(int idLote);
        System.Data.DataTable Historial(int idInv);
    }
}
