namespace Models
{
    // Clase que representa un grupo dentro del sistema
    public class Grupo
    {
        // Identificador �nico del grupo
        // Actualmente es un int, pero podr�as considerar GUID si quieres m�s flexibilidad
        public int Id { get; set; }

        // Nombre del grupo
        public string Nombre { get; set; }
        // Ruta (relativa o absoluta) de la imagen asociada al grupo
        public string Imagen { get; set; }
    }
}
