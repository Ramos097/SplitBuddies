namespace Models
{
    // Clase que representa un grupo dentro del sistema
    public class Grupo
    {
        // Identificador único del grupo
        // Actualmente es un int, pero podrías considerar GUID si quieres más flexibilidad
        public int Id { get; set; }

        // Nombre del grupo
        public string Nombre { get; set; }
        // Ruta (relativa o absoluta) de la imagen asociada al grupo
        public string Imagen { get; set; }
    }
}
