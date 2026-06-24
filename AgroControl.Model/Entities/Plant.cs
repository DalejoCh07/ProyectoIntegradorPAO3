namespace AgroControl.Model.Entities
{
    public class Plant : BaseEntity
    {
        public int IdPlanta { get; init; }
        public string Nombre { get; init; } = "";
        public string NombreCien { get; init; } = "";
        public string Descripcion { get; init; } = "";
        public override string ToString() => Nombre;
    }
}
