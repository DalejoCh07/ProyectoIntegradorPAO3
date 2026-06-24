using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IGreenhouseController
    {
        int Agregar(Greenhouse gh);
        List<Greenhouse> Listar();
        List<Greenhouse> Buscar(string nombre);
        void Eliminar(int id);
    }
}
