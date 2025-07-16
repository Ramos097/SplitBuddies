using Microsoft.Extensions.DependencyInjection;
using Proyecto_1;
using Proyecto_1.Controllers;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;
using Views.Vistas.Auth;
using Views.Vistas.Usuarios;

namespace Views
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //var services = new ServiceCollection();
            ////Inyeccion de dependencias

            //services.AddSingleton<IUsuario, UsuarioService>();
            //services.AddSingleton<IUsuarioController, UsuarioController>();


            ////Registro de formularios
            //services.AddTransient<FrmRegistrarUsuario>();
            
            //services.AddTransient<FrmLogin>(sp => new FrmLogin(sp)); // Importante







            //// Construir el proveedor de servicios
            //var provider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Application.Run(provider.GetRequiredService<FrmLogin>());
            Application.Run(new FrmLogin());
        }
    }
}