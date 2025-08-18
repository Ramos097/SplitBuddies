using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using LogicaNegocio.Interfaces;
using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;

namespace LogicaNegocio.Services
{
    // Servicio que implementa la lógica de generación de reportes
    // sobre los gastos a nivel de grupos y personales.
    public class ReporteService : IReporte
    {
        // Dependencias hacia otros servicios
        private readonly IGruposUsuarios _gruposUsuariosService;
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;
        private readonly IGasto _gastoService;

        // Constructor: inicializa las dependencias necesarias
        public ReporteService()
        {
            _gruposUsuariosService = new GrupoUsuariosService();
            _grupoService = new GrupoService();
            _usuarioService = new UsuarioService();
            _gastoService = new GastoService();
        }

        // ============================================================
        // ----------------- REPORTES A NIVEL DE GRUPO ----------------
        // ============================================================

        // Genera un reporte ANUAL de un grupo específico
        public Reporte ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda)
        {
            // Lista para almacenar los gastos a incluir en el reporte
            List<Gasto> gastosReporte = new List<Gasto>();

            // Variables acumuladoras
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            // Se obtienen los gastos asociados al grupo
            var gastos = _gastoService.ObtenerGastosPorGrupo(idGrupo);

            // Caso 1: usuario debe dinero (DEBO)
            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gastos.Where(g =>
                        g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) &&
                        g.Fecha.Year == anio.Year
                    ).ToList();

                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            // Caso 2: usuarios le deben al usuario actual (ME_DEBEN)
            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gastos.Where(g =>
                        g.idUsuarioRegistraGasto.Equals(idUsuario) &&
                        g.Fecha.Year == anio.Year
                    ).ToList();

                totalGastosMeDeben = gastosReporte.Sum(g =>
                        (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count
                    );
            }

            // Construcción de los datos detallados de cada gasto
            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);
                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                // Si el usuario debe: se divide el monto entre los participantes
                if (TipoDeuda.Equals("DEBO"))
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);

                // Si al usuario le deben: se calcula el monto de los demás participantes
                if (TipoDeuda.Equals("ME_DEBEN"))
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1)) * gasto.MiembrosQueDeben.Count;

                DatosGastoReporte datosGastoReporte = new DatosGastoReporte
                {
                    Grupo = grupo.Nombre,
                    Fecha = gasto.Fecha,
                    Registro = usuarioRegistro.NombreCompleto,
                    Gasto = gasto.Nombre,
                    Descripcion = gasto.Descripcion,
                    TotalGasto = gasto.Monto,
                    Debo = Debo,
                    MeDeben = MeDeben,
                    Deudores = string.Join(", ", gasto.MiembrosQueDeben)
                };
                GastoReportes.Add(datosGastoReporte);
            }

            // Armar objeto Reporte con resultados
            Reporte reporte = new Reporte
            {
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben
            };

            return reporte;
        }

        // Métodos ReporteGrupoMensual y ReporteGrupoRango funcionan igual que el Anual,
        // solo que filtran por mes o por rango de fechas.

        // ============================================================
        // ----------------- REPORTES PERSONALES ---------------------
        // ============================================================

        // Genera reporte ANUAL a nivel personal
        public Reporte ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda)
        {
            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            // Separa los gastos donde el usuario es acreedor (ME_DEBEN)
            // y donde es deudor (DEBO)
            var gruposMeDeben = _gastoService.ObtenerGastosPorUsuario(idUsuario);
            var gruposDebo = _gastoService.ObtenerGastosQueDebeUsuario(idUsuario);

            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gruposMeDeben.Where(g =>
                        g.idUsuarioRegistraGasto.Equals(idUsuario) &&
                        g.Fecha.Year == anio.Year
                    ).ToList();

                totalGastosMeDeben = gastosReporte.Sum(g =>
                        (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count
                    );
            }

            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gruposDebo.Where(g =>
                        g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) &&
                        g.Fecha.Year == anio.Year
                    ).ToList();

                totalGastosQueDebo = gastosReporte.Sum(g =>
                        g.Monto / (g.MiembrosQueDeben.Count + 1)
                    );
            }

            // Se arma el detalle con cada gasto
            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);
                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = TipoDeuda.Equals("DEBO") ? gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) : 0m;
                var MeDeben = TipoDeuda.Equals("ME_DEBEN") ? (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1)) * gasto.MiembrosQueDeben.Count : 0m;

                DatosGastoReporte datosGastoReporte = new DatosGastoReporte
                {
                    Grupo = grupo.Nombre,
                    Fecha = gasto.Fecha,
                    Registro = usuarioRegistro.NombreCompleto,
                    Gasto = gasto.Nombre,
                    Descripcion = gasto.Descripcion,
                    TotalGasto = gasto.Monto,
                    Debo = Debo,
                    MeDeben = MeDeben,
                    Deudores = string.Join(", ", gasto.MiembrosQueDeben)
                };
                GastoReportes.Add(datosGastoReporte);
            }

            // Retornar el reporte armado
            Reporte reporte = new Reporte
            {
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben
            };

            return reporte;
        }

        // Métodos ReportePersonalMensual y ReportePersonalRango siguen la misma lógica,
        // cambiando únicamente el criterio de filtrado (por mes o por rango de fechas).
    }
}
