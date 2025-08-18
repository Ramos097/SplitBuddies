using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Gasto
    {
            public int id { get; set; } 
            public string Nombre { get; set; }
            public int idGrupo { get; set; }
            public string idUsuarioRegistraGasto { get; set; }
            public string Descripcion { get; set; }
            public decimal Monto { get; set; }
            public DateTime Fecha { get; set; }
            public List<string> MiembrosQueDeben { get; set; }

    }
}



