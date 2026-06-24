namespace AgroControl.Model.Entities
{
    public class Greenhouse : BaseEntity
    {
        public int IdInvernadero { get; init; }
        public string Nombre { get; init; } = "";
        public string Ubicacion { get; init; } = "";
        public string Descripcion { get; init; } = "";
        public override string ToString() => Nombre;
    }
}
