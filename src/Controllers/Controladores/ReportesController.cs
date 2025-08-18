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

// Namespace: organiza el código en un grupo lógico
namespace Controllers.Controladores
{
    // Clase que controla la generación de reportes
    // Implementa la interfaz IReporteController
    public class ReportesController : IReporteController
    {
        // Campo privado que guarda la referencia al servicio de reportes
        private readonly IReporte _reporteService;

        // Constructor: inicializa el servicio de reportes cuando se crea el controlador
        public ReportesController()
        {
            _reporteService = new ReporteService();
        }

        // Método: genera un reporte anual de un grupo
        public Reporte ctr_ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoAnual(idUsuario, idGrupo, anio, TipoDeuda);
        }

        // Método: genera un reporte mensual de un grupo
        public Reporte ctr_ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoMensual(idUsuario, idGrupo, mensAnio, TipoDeuda);
        }

        // Método: genera un reporte de un grupo dentro de un rango de fechas
        public Reporte ctr_ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {
            return _reporteService.ReporteGrupoRango(idUsuario, idGrupo, fechaInicio, fechaFin, TipoDeuda);
        }

        // Método: genera un reporte anual personal (solo del usuario)
        public Reporte ctr_ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda)
        {
            return _reporteService.ReportePersonalAnual(idUsuario, anio, TipoDeuda);
        }

        // Método: genera un reporte mensual personal (solo del usuario)
        public Reporte ctr_ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda)
        {
            return _reporteService.ReportePersonalMensual(idUsuario, mensAnio, TipoDeuda);
        }

        // Método: genera un reporte personal dentro de un rango de fechas
        public Reporte ctr_ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {
            return _reporteService.ReportePersonalRango(idUsuario, fechaInicio, fechaFin, TipoDeuda);

