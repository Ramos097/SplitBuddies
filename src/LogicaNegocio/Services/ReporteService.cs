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
    public class ReporteService : IReporte
    {

        private readonly IGruposUsuarios _gruposUsuariosService;
        private readonly IGrupo _grupoService;
        private readonly IUsuario _usuarioService;
        private readonly IGasto _gastoService;
        public ReporteService()
        {

            _gruposUsuariosService = new GrupoUsuariosService();
            _grupoService = new GrupoService();
            _usuarioService = new UsuarioService();
            _gastoService = new GastoService();
        }






        public Reporte ReporteGrupoAnual(string idUsuario, int idGrupo, DateTime anio, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gastos = _gastoService.ObtenerGastosPorGrupo(idGrupo);

            

            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gastos.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Year == anio.Year).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            if( TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gastos.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Year == anio.Year).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count);
            }

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);


                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);
                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1)* gasto.MiembrosQueDeben.Count);
                   
                }



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


            Reporte reporte = new Reporte
            {
                
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };
            



            return reporte;


        }

        public Reporte ReporteGrupoMensual(string idUsuario, int idGrupo, DateTime mensAnio, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gastos = _gastoService.ObtenerGastosPorGrupo(idGrupo);
            


            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gastos.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Year == mensAnio.Year && g.Fecha.Month== mensAnio.Month).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gastos.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Year == mensAnio.Year && g.Fecha.Month == mensAnio.Month).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count);
            }

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);


                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) * gasto.MiembrosQueDeben.Count);

                }



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


            Reporte reporte = new Reporte
            {
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };




            return reporte;
        }

        public Reporte ReporteGrupoRango(string idUsuario, int idGrupo, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gastos = _gastoService.ObtenerGastosPorGrupo(idGrupo);
         


            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gastos.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Date >=fechaInicio.Date && g.Fecha.Date<=fechaFin.Date).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gastos.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Date >= fechaInicio.Date && g.Fecha.Date <= fechaFin.Date).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count);
            }

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);

                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) * gasto.MiembrosQueDeben.Count);

                }



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


            Reporte reporte = new Reporte
            {
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };




            return reporte;
        }

        public Reporte ReportePersonalAnual(string idUsuario, DateTime anio, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gruposMeDeben = _gastoService.ObtenerGastosPorUsuario(idUsuario);
            var gruposDebo = _gastoService.ObtenerGastosQueDebeUsuario(idUsuario);
            
            
            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gruposMeDeben.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Year == anio.Year).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1))* g.MiembrosQueDeben.Count);
            }

            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gruposDebo.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Year == anio.Year).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);
                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) * gasto.MiembrosQueDeben.Count);

                }



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


            Reporte reporte = new Reporte
            {

                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };




            return reporte; ;
        }



        public Reporte ReportePersonalMensual(string idUsuario, DateTime mensAnio, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gruposMeDeben = _gastoService.ObtenerGastosPorUsuario(idUsuario);
            var gruposDebo = _gastoService.ObtenerGastosQueDebeUsuario(idUsuario);


            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gruposDebo.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Year == mensAnio.Year && g.Fecha.Month == mensAnio.Month).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gruposMeDeben.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Year == mensAnio.Year && g.Fecha.Month == mensAnio.Month).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count);
            }

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);


                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) * gasto.MiembrosQueDeben.Count);

                }



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


            Reporte reporte = new Reporte
            {
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };




            return reporte;
        }

        public Reporte ReportePersonalRango(string idUsuario, DateTime fechaInicio, DateTime fechaFin, string TipoDeuda)
        {

            List<Gasto> gastosReporte = new List<Gasto>();
            var totalGastosMeDeben = 0m;
            var totalGastosQueDebo = 0m;

            var gruposMeDeben = _gastoService.ObtenerGastosPorUsuario(idUsuario);
            var gruposDebo = _gastoService.ObtenerGastosQueDebeUsuario(idUsuario);


            if (TipoDeuda.Equals("DEBO"))
            {
                gastosReporte = gruposDebo.Where(g => g.MiembrosQueDeben.Any(m => m.Equals(idUsuario)) && g.Fecha.Date >= fechaInicio.Date && g.Fecha.Date <= fechaFin.Date).ToList();
                totalGastosQueDebo = gastosReporte.Sum(g => g.Monto / (g.MiembrosQueDeben.Count + 1));
            }

            if (TipoDeuda.Equals("ME_DEBEN"))
            {
                gastosReporte = gruposMeDeben.Where(g => g.idUsuarioRegistraGasto.Equals(idUsuario) && g.Fecha.Date >= fechaInicio.Date && g.Fecha.Date <= fechaFin.Date).ToList();
                totalGastosMeDeben = gastosReporte.Sum(g => (g.Monto / (g.MiembrosQueDeben.Count + 1)) * g.MiembrosQueDeben.Count);
            }

            var GastoReportes = new List<DatosGastoReporte>();
            foreach (var gasto in gastosReporte)
            {
                var usuarioRegistro = _usuarioService.ObtenerUsuarioById(gasto.idUsuarioRegistraGasto);


                var grupo = _grupoService.ObtenerPorId(gasto.idGrupo);

                var Debo = 0m;
                var MeDeben = 0m;

                //30 000 =  30 000 / 3  =  10 000   
                if (TipoDeuda.Equals("DEBO"))
                {
                    Debo = gasto.Monto / (gasto.MiembrosQueDeben.Count + 1);
                }

                //30 000 =  30 000 / 3  =  10 000  * 2 = 20 000

                if (TipoDeuda.Equals("ME_DEBEN"))
                {
                    MeDeben = (gasto.Monto / (gasto.MiembrosQueDeben.Count + 1) * gasto.MiembrosQueDeben.Count);

                }



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


            Reporte reporte = new Reporte
            {
               
                Tipo = TipoDeuda,
                TotalDebo = totalGastosQueDebo,
                DatosGastos = GastoReportes,
                TotalMeDeben = totalGastosMeDeben

            };




            return reporte;
        }
    }
}
