using SketchMuse.Domain.DTOs;
using SketchMuse.Infrastructure.ExternalApis;

namespace SketchMuse.Application.Interfaces
{
    public class ImagenesService: IImagenesService
    {
        private readonly BingImageService _bingImageService;
        public ImagenesService(BingImageService bingService) {
            _bingImageService = bingService; 
        }

        public async Task<List<ImagenDTO>> PedirImagenes(string query, int count)
        {
            var imagenes = await _bingImageService.LlamadaApiBing(query, count);
            return imagenes;
        }
    }
}
