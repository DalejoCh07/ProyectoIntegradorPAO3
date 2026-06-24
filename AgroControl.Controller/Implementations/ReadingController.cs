using AgroControl.Model.Entities;
using AgroControl.Model.DAO.Interfaces;
using AgroControl.Model.DAO.Implementations;
using AgroControl.Controller.Interfaces;

namespace AgroControl.Controller.Implementations
{
    public class ReadingController : IReadingController
    {
        private readonly IReadingDAO _dao = new ReadingDAO();

        public int Insertar(Reading reading) => _dao.Insert(reading);
        public List<Reading> Listar() => _dao.GetAll();
        public System.Data.DataTable HistorialPivot(int idInv) => _dao.GetHistorialPivot(idInv);
        public System.Data.DataTable Estadisticas(DateTime desde, DateTime hasta, int idInv)
            => _dao.GetEstadisticas(desde, hasta, idInv);
        public decimal UltimaLectura(int idSensor, int idInv) => _dao.GetUltimaLectura(idSensor, idInv);
    }
}
