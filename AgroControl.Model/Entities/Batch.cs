namespace AgroControl.Model.Entities
{
    public class Batch : BaseEntity
    {
        public int IdLote { get; init; }
        public int CantPlantas { get; init; }
        public DateTime FechaSiembra { get; init; }
        public DateTime? FechaCosecha { get; init; }
        public int IdInvernadero { get; init; }
        public int IdPlanta { get; init; }
        public string NombrePlanta { get; init; } = "";
    }
}
