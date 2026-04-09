using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SketchMuse.Application.Interfaces;
using SketchMuse.Infrastructure.Data;
using System.Security.Claims;
using static SketchMuse.Application.Interfaces.IAlbumesService;

namespace SketchMuse.Controllers
{
    [ApiController]
    [Route("api/albumes")]
    public class AlbumesController:ControllerBase
    {
                private readonly IAlbumesService _albumService;
        private readonly MiDbcontext _context;
        public AlbumesController(IAlbumesService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("user-albumes")]
        [Authorize]
        public async Task<IActionResult> GetMisAlbumes()
        {
            var albumesprueba = await _context.Albumes
    .Include(a => a.Imagenes)
    .Where(a => a.UsuarioId == 2)
    .ToListAsync();

            Console.WriteLine(albumesprueba.Count);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();
            Console.WriteLine("UsuarioId del token: " + userIdClaim);

            int usuarioId = int.Parse(userIdClaim);

            var albumes = await _albumService.GetAlbumesUsuario(usuarioId);

            return Ok(albumes);
        }
    }
}
