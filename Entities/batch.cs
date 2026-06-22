using System;

namespace Entities
{
    public class Batch
    {
        public int IdLote { get; set; }
        public int CantPlantas { get; set; }
        public DateTime FechaSiembra { get; set; }
        public DateTime? FechaCosecha { get; set; } // Puede ser nulo
        public int IdInvernadero { get; set; }
        public int IdPlanta { get; set; }

        // Propiedad adicional para facilitar la visualización en pantalla
        public string NombrePlanta { get; set; }

        public Batch() { }
    }
}
