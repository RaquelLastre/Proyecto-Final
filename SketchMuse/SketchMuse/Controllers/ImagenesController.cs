using Microsoft.AspNetCore.Mvc;
using SketchMuse.Application.Interfaces;

namespace SketchMuse.Controllers
{
    [ApiController]
    [Route("api/imagenes")]
    public class ImagenesController : ControllerBase
    {
        private readonly IImagenesService _imageService; 
        public ImagenesController(IImagenesService imageService) {
            _imageService = imageService; 
        }
        [HttpGet("search")] public async Task<IActionResult> Search(string query, int count = 10) {
            var images = await _imageService.PedirImagenes(query, count);
            return Ok(images); 
        }
    }
}
