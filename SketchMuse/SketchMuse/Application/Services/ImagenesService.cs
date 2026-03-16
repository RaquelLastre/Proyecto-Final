using SketchMuse.Domain.DTOs;
using SketchMuse.Infrastructure.ExternalApis;

namespace SketchMuse.Application.Interfaces
{
    public class ImagenesService: IImagenesService
    {
        private readonly BingImageService _bingImageService;
        private readonly UnsplashService _unsplashservice;
        public ImagenesService(BingImageService bingService) {
            _bingImageService = bingService; 
        }

        public async Task<List<ImagenDTO>> PedirImagenes(string query, int count)
        {
            var imagenes = new List<ImagenDTO>();
            await _unsplashservice.LlamadaApiBing(query, count);
           /* try
            {
                await _bingImageService.LlamadaApiBing(query, count);
            }
            catch
            {
                await _unsplashservice.LlamadaApiBing(query, count);
            }*/
             
            return imagenes;
        }
    }
}
