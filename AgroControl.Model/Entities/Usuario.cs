namespace AgroControl.Model.Entities
{
    public class Usuario : BaseEntity
    {
        public int IdUsuario { get; init; }
        public string Nombre { get; init; } = "";
        public string Contrasena { get; init; } = "";
        public string TipoUsuario { get; init; } = "";
    }
}
