using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reading
    {
        public int IdLectura { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdSensor { get; set; }

        // Constructor vacío (obligatorio para evitar errores de instanciación)
        public Reading() { }

        // Constructor con parámetros para facilitar el registro de nuevos datos
        public Reading(int idLectura, decimal valor, DateTime fechaHora, int idSensor)
        {
            this.IdLectura = idLectura;
            this.Valor = valor;
            this.FechaHora = fechaHora;
            this.IdSensor = idSensor;
        }
    }
}
