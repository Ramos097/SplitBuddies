using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatosGastoReporte
    {
        public string Grupo { get; set; }
        public DateTime Fecha { get; set; }
        public string Registro { get; set; }
        public string Gasto { get; set; }
        public string Descripcion { get; set; }
        public decimal TotalGasto { get; set; }
        public decimal Debo { get; set; }
        public decimal MeDeben { get; set; }
        public string Deudores { get; set; }
    }
}
