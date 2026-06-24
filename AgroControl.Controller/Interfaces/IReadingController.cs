using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IReadingController
    {
        int Insertar(Reading reading);
        List<Reading> Listar();
        System.Data.DataTable HistorialPivot(int idInv);
        System.Data.DataTable Estadisticas(DateTime desde, DateTime hasta, int idInv);
        decimal UltimaLectura(int idSensor, int idInv);
    }
}
