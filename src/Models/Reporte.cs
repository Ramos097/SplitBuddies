using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reporte
    {
        // Tipo de reporte: Mensual, Anual, Rango, Personal, etc.
        public string Tipo { get; set; }

        // Lista de gastos detallados para este reporte
        public List<DatosGastoReporte> DatosGastos { get; set; }

        // Total que debo (suma de todos los gastos donde el usuario es deudor)
        public decimal TotalDebo { get; set; }

        // Total que me deben (suma de todos los gastos donde otros me deben a mí)
        public decimal TotalMeDeben { get; set; }
    }
}
