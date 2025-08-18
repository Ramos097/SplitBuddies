using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Clase que representa la relación entre un gasto y un grupo
    // Útil como tabla intermedia para mapear gastos dentro de los grupos
    public class Gastos_X_Grupo
    {
        // Identificador único de este registro (puede ser GUID o un consecutivo)
        public string Id { get; set; }

        // Identificador del grupo al que pertenece el gasto
        public string IdGrupo { get; set; }

        // Identificador del gasto asociado
        public string IdGasto { get; set; }

        // Identificación del usuario que reportó/registró el gasto
        public string IdUsuarioReportaGasto { get; set; }

        // Lista de identificaciones de usuarios que deben pagar este gasto
        public List<string> IdUsuariosDeudores { get; set; }
    }
}
