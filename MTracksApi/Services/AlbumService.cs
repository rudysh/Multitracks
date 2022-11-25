using AutoMapper;
using MTracksApi.Data;
using MTracksApi.Data.Repositories;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;
using System.Drawing.Drawing2D;

namespace MTracksApi.Services
{
    public class AlbumService
    {
        private readonly AlbumRepository _albumssRespository;
        private readonly ILogger<AlbumRepository> _logger;
        readonly IMapper _mapper;
        public AlbumService(AlbumRepository albumRespository, ILogger<AlbumRepository> logger, IMapper mapper)
        {
            _albumssRespository = albumRespository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<Album>>> GetAlbums(PaginationFilterRequest filter, string route)
        {
            return await _albumssRespository.GetAlbumss(filter, route);
        }
    }
}
