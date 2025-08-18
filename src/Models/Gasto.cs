using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Clase que representa un gasto dentro de un grupo.
    // Se usa para registrar la información básica de un gasto compartido.
    public class Gasto
    {
        // Identificador único del gasto (autonumérico o generado al guardarse)
        public int id { get; set; }

        // Nombre o título del gasto (ejemplo: "Cena", "Gasolina")
        public string Nombre { get; set; }

        // Identificador del grupo al que pertenece este gasto
        public int idGrupo { get; set; }

        // Identificación del usuario que registró el gasto
        public string idUsuarioRegistraGasto { get; set; }

        // Descripción adicional del gasto (detalles, notas, observaciones, etc.)
        public string Descripcion { get; set; }

        // Monto total del gasto
        public decimal Monto { get; set; }

        // Fecha en que se realizó o registró el gasto
        public DateTime Fecha { get; set; }

        // Lista de identificaciones de los miembros que deben este gasto
        // (sirve para repartir y calcular quién debe cuánto)
        public List<string> MiembrosQueDeben { get; set; }
    }
}