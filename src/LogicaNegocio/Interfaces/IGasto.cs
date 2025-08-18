using System;
using Models;

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Interfaces
{
    // Interfaz que define las operaciones que debe implementar un servicio de gastos
    public interface IGasto
    {
        // Obtiene los grupos activos en los que participa un usuario
        public List<Grupo> obtenerGruposActivos(string idUsuario);

        // Obtiene el último ID de gasto registrado
        public int ObtenerUltimoIdGasto();

        // Registra un nuevo gasto en el sistema
        public void RegistrarGasto(Gasto gasto);

        // Obtiene todos los gastos de un grupo específico
        public List<Gasto> ObtenerGastosPorGrupo(int idGrupo);

        // Obtiene los grupos en los que el usuario debe dinero
        public List<Grupo> ObtenerGruposQueDebo(string identificacion);

        // Obtiene todos los gastos realizados por un usuario
        public List<Gasto> ObtenerGastosPorUsuario(string idUsuario);

        // Obtiene todos los gastos que un usuario todavía debe
        public List<Gasto> ObtenerGastosQueDebeUsuario(string idUsuario);

        // Obtiene un gasto específico a partir de su ID
        public Gasto ObtenerGastoporID(int idGasto);

        // Actualiza la información de un gasto existente
        public void ActualizarGasto(Gasto gasto);

        // Obtiene una lista de personas a las que el usuario le debe dinero
        public List<string> obtenerAQuieDebeUsuario(string idUsuario);
    }
}

