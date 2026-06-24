namespace AgroControl.Model.Entities
{
    public class Requirements : BaseEntity
    {
        public int IdRequerimientos { get; init; }
        public decimal TempAireMin { get; init; }
        public decimal TempAireMax { get; init; }
        public decimal HumAireMin { get; init; }
        public decimal HumAireMax { get; init; }
        public decimal HumSueloMin { get; init; }
        public decimal HumSueloMax { get; init; }
        public decimal LuzMin { get; init; }
        public decimal LuzMax { get; init; }
        public int IdPlanta { get; init; }
    }
}
