using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sensor
    {
        public int IdSensor { get; set; }
        public string Tipo { get; set; }
        public int IdInvernadero { get; set; }

        // Constructor vacío (necesario para crear objetos vacíos luego)
        public Sensor() { }

        // Constructor con parámetros
        public Sensor(int idSensor, string tipo, int idInvernadero)
        {
            this.IdSensor = idSensor;
            this.Tipo = tipo;
            this.IdInvernadero = idInvernadero;
        }

        // ToString modificado para que al mostrar el sensor en un ComboBox se vea el Tipo
        public override string ToString()
        {
            return Tipo;
        }
    }
}
