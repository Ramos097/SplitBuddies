using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Reporte
    {
        
        public string Tipo { get; set; }
        public List<DatosGastoReporte> DatosGastos { get; set; }
        public decimal TotalDebo { get; set; }
        public decimal TotalMeDeben { get; set; }
    }
}
