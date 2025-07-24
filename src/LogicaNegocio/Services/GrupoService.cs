using Models;
using Proyecto_1.Interfaces;
using Proyecto_1.Services;
using System;
using System.Collections.Generic;

namespace LogicaNegocio.Services
{
    public class GrupoService : IGrupo
    {
        private readonly List<Grupo> _grupos = new List<Grupo>();

        public void CrearGrupo(Grupo grupo)
        {
            _grupos.Add(grupo);
        }

        public List<Grupo> ObtenerGrupos()
        {
            return _grupos;
        }

        public void AgregarMiembro(string grupoId, Usuario usuario)
        {
            var grupo = _grupos.Find(g => g.Id == grupoId);
            if (grupo != null && !grupo.Miembros.Any(m => m.Identificacion == usuario.Identificacion))
            {
                grupo.Miembros.Add(usuario);
            }
        }

        public Grupo ObtenerPorId(string id)
        {
            return _grupos.FirstOrDefault(g => g.Id == id);
        }
    }
}
