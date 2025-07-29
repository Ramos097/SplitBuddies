using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;
using Controllers.Interfaces;

namespace Proyecto_1.Services
{
    public class GastoService : IGasto
    {
        private readonly string _rutaArchivo;

        public GastoService()
        {
            string? basePath = AppContext.BaseDirectory;
            string? srcPath = Directory.GetParent(basePath)?.Parent?.Parent?.Parent?.Parent?.FullName;

            string almacenamientoPath = Path.Combine(srcPath!, "LogicaNegocio", "Almacenamiento");

            if (!Directory.Exists(almacenamientoPath))
                Directory.CreateDirectory(almacenamientoPath);

            _rutaArchivo = Path.Combine(almacenamientoPath, "gastos.json");
        }

        public void AgregarGasto(Gasto gasto)
        {
            var lista = LeerArchivo();
            lista.Add(gasto);
            EscribirArchivo(lista);
        }

        public List<Gasto> ObtenerGastos()
        {
            return LeerArchivo();
        }

        public List<Gasto> ObtenerGastosPorUsuario(string identificacion)
        {
            return LeerArchivo().Where(g => g.Identificacion == identificacion).ToList();
        }

        private List<Gasto> LeerArchivo()
        {
            if (!File.Exists(_rutaArchivo))
                return new List<Gasto>();

            try
            {
                var json = File.ReadAllText(_rutaArchivo);
                return JsonSerializer.Deserialize<List<Gasto>>(json) ?? new List<Gasto>();
            }
            catch
            {
                return new List<Gasto>();
            }
        }

        private void EscribirArchivo(List<Gasto> lista)
        {
            try
            {
                var opciones = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(lista, opciones);
                File.WriteAllText(_rutaArchivo, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los gastos: " + ex.Message);
            }
        }
    }
}
