using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IPlantController
    {
        int Agregar(Plant plant);
        Plant? Obtener(int id);
        List<Plant> Listar();
        List<Plant> Buscar(string nombre);
        void Eliminar(int id);
        void GuardarConRequerimientos(Plant planta, Requirements req);
    }
}
