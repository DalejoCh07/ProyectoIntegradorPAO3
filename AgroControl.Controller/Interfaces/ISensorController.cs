using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface ISensorController
    {
        int Agregar(Sensor sensor);
        Sensor? Obtener(int id);
        List<Sensor> Listar();
        List<Sensor> ListarPorInvernadero(int idInv);
        void Eliminar(int id);
    }
}
