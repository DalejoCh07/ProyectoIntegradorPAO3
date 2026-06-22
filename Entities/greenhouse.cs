namespace Entities
{
    public class Greenhouse
    {
        public int IdInvernadero { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }

        public Greenhouse() { }

        public Greenhouse(int id, string nombre, string ubicacion, string descripcion)
        {
            IdInvernadero = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            Descripcion = descripcion;
        }

        public override string ToString() => Nombre;
    }
}
