using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Requirements
    {
        // 1. Atributos (Las columnas de tu tabla)
        public int IdRequerimientos { get; set; }
        public decimal TempAireMin { get; set; }
        public decimal TempAireMax { get; set; }
        public decimal HumAireMin { get; set; }
        public decimal HumAireMax { get; set; }
        public decimal HumSueloMin { get; set; }
        public decimal HumSueloMax { get; set; }
        public decimal LuzMin { get; set; }
        public decimal LuzMax { get; set; }
        public int IdPlanta { get; set; }

        // Objeto relacionado (Tal como lo tenías en tu código de referencia)
        public Plant PlantaRelacionada { get; set; }

        // 2. Constructor vacío (Obligatorio para instanciar sin datos iniciales)
        public Requirements() { }

        // 3. Constructor con parámetros (¡El que nos faltaba!)
        // Permite crear el requerimiento en una sola línea.
        public Requirements(int idReq, decimal tMin, decimal tMax, decimal haMin, decimal haMax,
                             decimal hsMin, decimal hsMax, decimal lMin, decimal lMax, int idPlanta)
        {
            this.IdRequerimientos = idReq;
            this.TempAireMin = tMin;
            this.TempAireMax = tMax;
            this.HumAireMin = haMin;
            this.HumAireMax = haMax;
            this.HumSueloMin = hsMin;
            this.HumSueloMax = hsMax;
            this.LuzMin = lMin;
            this.LuzMax = lMax;
            this.IdPlanta = idPlanta;
        }

        // 4. Método ToString() (Para mostrar algo legible si lo pones en un ListBox)
        public override string ToString()
        {
            return $"Requerimientos de Planta ID: {IdPlanta}";
        }
    }
}