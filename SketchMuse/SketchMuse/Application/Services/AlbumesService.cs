using SketchMuse.Domain.DTOs;
using SketchMuse.Domain.Entities;
using SketchMuse.Infrastructure.Data;
using static SketchMuse.Application.Interfaces.IAlbumesService;

namespace SketchMuse.Application.Interfaces
{
    public class AlbumesService : IAlbumService
    {
        private readonly MiDbcontext _context;

        public AlbumesService(MiDbcontext context)
        {
            _context = context;
        }

        public async Task GuardarAlbum(string titulo, int usuarioId, List<ImagenDTO> imagenes)
        {
            var album = new Album
            {
                Titulo = titulo,
                UsuarioId = usuarioId,
                UsedAt = DateTime.UtcNow,
                Imagenes = imagenes.Select(i => new Imagen
                {
                    Url = i.Url,
                    Titulo = i.Titulo
                }).ToList()
            };

            _context.Albumes.Add(album);
            await _context.SaveChangesAsync();
        }
    }
}
