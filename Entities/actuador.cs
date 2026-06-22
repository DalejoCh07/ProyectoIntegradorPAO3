namespace Entities
{
    public class Actuador
    {
        public int IdActuador { get; set; }
        public string Tipo { get; set; }
        public int IdInvernadero { get; set; }
        public string Estado { get; set; }

        public Actuador() { }

        public Actuador(int id, string tipo, int idInvernadero, string estado)
        {
            IdActuador = id;
            Tipo = tipo;
            IdInvernadero = idInvernadero;
            Estado = estado;
        }

        public override string ToString() => Tipo;
    }
}
