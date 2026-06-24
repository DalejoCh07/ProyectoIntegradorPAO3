namespace AgroControl.Model.Entities
{
    public class Accion : BaseEntity
    {
        public int IdAccion { get; init; }
        public string TipoAccion { get; init; } = "";
        public DateTime FechaHora { get; init; }
        public int Duracion { get; init; }
        public int IdActuador { get; init; }
    }
}
