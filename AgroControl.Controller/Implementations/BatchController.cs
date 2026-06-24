using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class BatchController : IBatchController
    {
        private readonly IBatchDAO _dao = new BatchDAO();

        public Batch? ObtenerActivo(int idInv) => _dao.GetActivo(idInv);
        public void Insertar(Batch lote) => _dao.Insert(lote);
        public void Finalizar(int idLote) => _dao.Finalizar(idLote);
        public System.Data.DataTable Historial(int idInv) => _dao.GetHistorial(idInv);
    }
}
