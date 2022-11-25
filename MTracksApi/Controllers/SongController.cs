using Microsoft.AspNetCore.Mvc;
using MTracksApi.Data.Requests;
using MTracksApi.Services;

namespace MTracksApi.Controllers
{
    [ApiController]
    [Route("song")]
    public class SongController : Controller
    {
        private readonly SongService _songService;

        public SongController(SongService songService)
        {
            _songService = songService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> IndexArtists([FromQuery] PaginationFilterRequest filter)
        {
            var route = Request.Path.Value;

            return Ok(await _songService.GetSongs(filter, route));
        }
    }
}
