using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IRequirementsController
    {
        int Agregar(Requirements req);
        List<Requirements> ObtenerPorPlanta(int idPlanta);
    }
}
