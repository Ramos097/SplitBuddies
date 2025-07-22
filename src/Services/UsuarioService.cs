using Models;
using Proyecto_1.Interfaces;

namespace Proyecto_1.Services
{
	public class UsuarioService : IUsuario
	{
		private List<Usuario> usuarios;

		public UsuarioService()
		{
			usuarios = new List<Usuario>();
			
		}

		public void AgregarUsuario(Usuario usuario)
		{
			usuarios.Add(usuario);
		}

		public List<Usuario> ObtenerUsuarios()
		{
			return usuarios;
		}

		public bool ValidarIdentificacionRepetida(string id)
		{
			return usuarios.Any(u => u.Identificacion == id);
		}

		public string CopiarImagen(string rutaOriginal)
		{
			
			string destino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagenes");

			if (!Directory.Exists(destino))
				Directory.CreateDirectory(destino);

			string nombreArchivo = Path.GetFileName(rutaOriginal);
			string rutaDestino = Path.Combine(destino, nombreArchivo);

			File.Copy(rutaOriginal, rutaDestino, true);

			return rutaDestino;
		}

		public Usuario ValidarAutenticacion(string id, string pass)
		{
			return usuarios.FirstOrDefault(u => u.Identificacion == id && u.Contrasena == pass);
		}
	}
}
