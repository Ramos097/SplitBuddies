using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Clase modelo que representa la información que se usará en los reportes de gastos.
    // Se utiliza para estructurar los datos que luego pueden mostrarse en una vista o exportarse a un informe.
    public class DatosGastoReporte
    {
        // Nombre del grupo al que pertenece el gasto
        public string Grupo { get; set; }

        // Fecha en que se registró el gasto
        public DateTime Fecha { get; set; }

        // Persona o usuario que hizo el registro del gasto
        public string Registro { get; set; }

        // Nombre o tipo del gasto (ejemplo: "Comida", "Transporte")
        public string Gasto { get; set; }

        // Descripción adicional del gasto (detalles, notas, etc.)
        public string Descripcion { get; set; }

        // Monto total del gasto realizado
        public decimal TotalGasto { get; set; }

        // Cuánto debo yo dentro del gasto registrado
        public decimal Debo { get; set; }

        // Cuánto me deben los demás integrantes del grupo
        public decimal MeDeben { get; set; }

        // Nombres de los deudores (quienes deben este gasto)
        public string Deudores { get; set; }
    }
}

