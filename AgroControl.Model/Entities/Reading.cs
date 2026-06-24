namespace AgroControl.Model.Entities
{
    public class Reading : BaseEntity
    {
        public int IdLectura { get; init; }
        public decimal Valor { get; init; }
        public DateTime FechaHora { get; init; }
        public int IdSensor { get; init; }
    }
}
