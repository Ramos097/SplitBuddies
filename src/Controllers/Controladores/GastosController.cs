using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using LogicaNegocio.Services;
using Models;
using Proyecto_1.Services;

// Namespace: sirve para organizar el código en grupos lógicos
namespace Controllers.Controladores
{
    // Clase que controla las operaciones relacionadas con los gastos
    // Implementa la interfaz IGastosController
    public class GastosController : IGastosController
    {
        // Campo privado que guarda la referencia al servicio de gastos
        private readonly IGasto _gastoService;

        // Constructor: inicializa el servicio de gastos cuando se crea el controlador
        public GastosController()
        {
            _gastoService = new GastoService();
        }

        // Método: obtiene los grupos activos de un usuario
        public List<Grupo> crt_obtenerGruposActivos(string idUsuario)
        {
            return _gastoService.obtenerGruposActivos(idUsuario);
        }

        // Método: actualiza la información de un gasto
        public void ctr_ActualizarGasto(Gasto gasto)
        {
            _gastoService.ActualizarGasto(gasto);
        }

        // Método: busca un gasto por su ID
        public Gasto ctr_ObtenerGastoporID(int idGasto)
        {
            return _gastoService.ObtenerGastoporID(idGasto);
        }

        // Método: obtiene todos los gastos de un grupo específico
        public List<Gasto> ctr_ObtenerGastosPorGrupo(int idGrupo)
        {
            return _gastoService.ObtenerGastosPorGrupo(idGrupo);
        }

        // Método: obtiene todos los gastos hechos por un usuario
        public List<Gasto> ctr_ObtenerGastosPorUsuario(string idUsuario)
        {
            return _gastoService.ObtenerGastosPorUsuario(idUsuario);
        }

        // Método: obtiene los grupos en los que el usuario debe dinero
        public List<Grupo> ctr_ObtenerGruposQueDebo(string identificacion)
        {
            return _gastoService.ObtenerGruposQueDebo(identificacion);
        }

        // Método: obtiene el último ID de gasto registrado
        public int ctr_ObtenerUltimoIdGasto()
        {
            return _gastoService.ObtenerUltimoIdGasto();
        }

        // Método: registra un nuevo gasto
        public void ctr_RegistrarGasto(Gasto gasto)
        {
            _gastoService.RegistrarGasto(gasto);
            return; // este return no es necesario, pero no afecta
        }

        // Método: obtiene una lista de personas a las que el usuario debe dinero
        public List<string> crt_obtenerAQuieDebeUsuario(string idUsuario)
        {
            return _gastoService.obtenerAQuieDebeUsuario(idUsuario);
        }
    }
}
