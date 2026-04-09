using SketchMuse.Domain.DTOs;

namespace SketchMuse.Application.Interfaces
{
    public class IAlbumesService
    {
        public interface IAlbumService
        {
            Task GuardarAlbum(string titulo, int usuarioId, List<ImagenDTO> imagenes);
        }
    }
}
