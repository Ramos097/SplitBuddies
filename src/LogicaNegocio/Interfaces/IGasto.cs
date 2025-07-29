using System;
using Models;

namespace Controllers.Interfaces
{
    public interface IGasto
    {
        void AgregarGasto(Gasto gasto);
        List<Gasto> ObtenerGastos();
        List<Gasto> ObtenerGastosPorUsuario(string identificacion);
    }
}
