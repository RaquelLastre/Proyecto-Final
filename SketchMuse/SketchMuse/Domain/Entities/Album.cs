using System.Data;

namespace SketchMuse.Domain.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; } = null!;
        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();
        public List<String> ImagenesAprobadas { get; set; } = new List<String>();
        public List<String> ImagenesRechazadas { get; set; } = new List<String>();

    }
}
