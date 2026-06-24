using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IAccionController
    {
        int Insertar(Accion accion);
        List<Accion> Listar();
        List<Accion> ListarPorInvernadero(int idInv);
        List<Accion> ListarPorActuador(int idActuador);
    }
}
