using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Interfaces
{
    // Interfaz que define las operaciones que debe tener un controlador de gastos
    public interface IGastosController
    {
        // Obtiene los grupos activos de un usuario
        public List<Grupo> crt_obtenerGruposActivos(string idUsuario);

        // Obtiene el último ID de gasto registrado
        public int ctr_ObtenerUltimoIdGasto();

        // Registra un nuevo gasto
        public void ctr_RegistrarGasto(Gasto gasto);

        // Obtiene los gastos de un grupo según su ID
        public List<Gasto> ctr_ObtenerGastosPorGrupo(int idGrupo);

        // Obtiene los grupos en los que el usuario debe dinero
        public List<Grupo> ctr_ObtenerGruposQueDebo(string identificacion);

        // Obtiene los gastos de un usuario específico
        public List<Gasto> ctr_ObtenerGastosPorUsuario(string idUsuario);

        // Obtiene un gasto por su ID
        public Gasto ctr_ObtenerGastoporID(int idGasto);

        // Actualiza la información de un gasto existente
        public void ctr_ActualizarGasto(Gasto gasto);

        // Obtiene una lista de personas a las que el usuario le debe dinero
        public List<string> crt_obtenerAQuieDebeUsuario(string idUsuario);
    }
}




        //public bool crt_AgregarGasto(Models.Gasto gasto);
        //public bool crt_EliminarGasto(int idGasto);
        //public bool crt_ActualizarGasto(Models.Gasto gasto);
        //public Models.Gasto? crt_ObtenerGastoPorId(int idGasto);
    }
}
