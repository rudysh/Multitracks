using Microsoft.AspNetCore.Mvc;
using MTracksApi.Data;
using MTracksApi.Data.Requests;
using MTracksApi.Services;

namespace MTracksApi.Controllers
{
    [ApiController]
    [Route("artist")]
    public class ArtistController : Controller
    {
        private readonly ArtistService _artistService;

        public ArtistController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet()]
        public async Task<IActionResult> IndexArtists([FromQuery] PaginationFilterRequest filter)
        {
            var route = Request.Path.Value;

            return Ok(await _artistService.GetArtists(filter, route));
        }

        [HttpGet("search/{name}")]
        public async Task<IActionResult> IndexArtists(string name, [FromQuery] PaginationFilterRequest filter)
        {
            var route = Request.Path.Value;

            return Ok(await _artistService.GetArtistsByName(name, filter, route));
        }

        [HttpPost("add")]
        public async Task<Artist> Create([FromBody] CreateArtistRequest request)
        {
            return await _artistService.CreateAsync(request);
        }


    }
}
