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

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query, [FromQuery] int count = 10) {
            try
            {
                var images = await _imageService.PedirImagenes(query, count);
                return Ok(images);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(503, new
                {
                    mensaje = "Tenemos problemas técnicos que ya se están resolviendo",
                    detalles = ex.Message
                });
            }
        }
    }
}
