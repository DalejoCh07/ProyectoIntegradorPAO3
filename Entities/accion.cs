using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Accion
    {
        public int IdAccion { get; set; }
        public string TipoAccion { get; set; }
        public DateTime FechaHora { get; set; }
        public int Duracion { get; set; }
        public int IdActuador { get; set; }

        // Constructor vacío (obligatorio)
        public Accion() { }

        // Constructor con parámetros para instanciar rápidamente
        public Accion(int idAccion, string tipoAccion, DateTime fechaHora, int duracion, int idActuador)
        {
            this.IdAccion = idAccion;
            this.TipoAccion = tipoAccion;
            this.FechaHora = fechaHora;
            this.Duracion = duracion;
            this.IdActuador = idActuador;
        }
    }
}
