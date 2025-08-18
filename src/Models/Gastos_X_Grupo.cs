using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Gastos_X_Grupo
    {
        public string Id { get; set; }
        public string IdGrupo { get; set; }
        public string IdGasto { get; set; }
        public string IdUsuarioReportaGasto { get; set; }
        public List<string> idUsuariosDeudores { get; set; }
    }
}
