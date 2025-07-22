namespace Models
{
    public class Grupo
    {
        public string Id { get; set; } // Puedes usar un GUID si lo prefieres
        public string Nombre { get; set; }
        public string Imagen { get; set; } // Ruta de imagen del grupo
        public List<Usuario> Miembros { get; set; }

        public Grupo()
        {
            Miembros = new List<Usuario>();
        }
    }
}
