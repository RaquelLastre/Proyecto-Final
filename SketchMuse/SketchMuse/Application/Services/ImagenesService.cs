using SketchMuse.Domain.DTOs;
using SketchMuse.Domain.Entities;
using SketchMuse.Infrastructure.ExternalApis;
using System.Web;

namespace SketchMuse.Application.Interfaces
{
    public class ImagenesService: IImagenesService
    {
        private readonly BingImageService _bingImageService;
        private readonly UnsplashService _unsplashservice;
        public ImagenesService(BingImageService bingService, UnsplashService unsplashService) {
            _bingImageService = bingService; 
            _unsplashservice = unsplashService;
        }

        public async Task<List<ImagenDTO>> PedirImagenes(string query, int count)
        {
            var imagenes = new List<ImagenDTO>();
             try
             {
                 imagenes = await _unsplashservice.LlamadaApiUnsplash(query, count);
             }
             catch
             {
                 imagenes = await _bingImageService.LlamadaApiBing(query, count);
             }
            var resultado = imagenes.Select(i => new ImagenDTO{
                Titulo = i.Titulo,
                Url = HttpUtility.UrlDecode(i.Url)
            }).ToList();


            if (imagenes == null || imagenes.Count == 0)
            {
                throw new Exception("No se pudieron obtener imágenes de ningún servicio externo.");
            }

            return imagenes;
        }
    }
}
