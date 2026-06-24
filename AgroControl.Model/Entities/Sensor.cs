namespace AgroControl.Model.Entities
{
    public class Sensor : BaseEntity
    {
        public int IdSensor { get; init; }
        public string Tipo { get; init; } = "";
        public int IdInvernadero { get; init; }
        public override string ToString() => Tipo;
    }
}
