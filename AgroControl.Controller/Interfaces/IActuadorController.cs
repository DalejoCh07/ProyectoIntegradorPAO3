using AgroControl.Model.Entities;

namespace AgroControl.Controller.Interfaces
{
    public interface IActuadorController
    {
        int Agregar(Actuador act);
        List<Actuador> Listar();
        List<Actuador> ListarPorInvernadero(int idInv);
        void Eliminar(int id);
        string ObtenerEstado(int idActuador, int idInv);
        void CambiarEstado(int idActuador, int idInv, string estado);
    }
}
