namespace AgroControl.Model.Entities
{
    public class Actuador : BaseEntity
    {
        public int IdActuador { get; init; }
        public string Tipo { get; init; } = "";
        public int IdInvernadero { get; init; }
        public string Estado { get; init; } = "OFF";
        public override string ToString() => Tipo;
    }
}
