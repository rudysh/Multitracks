using Microsoft.AspNetCore.Mvc;
using MTracksApi.Data.Requests;
using MTracksApi.Services;

namespace MTracksApi.Controllers
{
    [ApiController]
    [Route("album")]
    public class AlbumController : Controller
    {
        private readonly AlbumService _albumService;
        public AlbumController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlbums([FromQuery] PaginationFilterRequest filter)
        {
            var route = Request.Path.Value;

            return Ok(await _albumService.GetAlbums(filter, route));
        }
    }
}
