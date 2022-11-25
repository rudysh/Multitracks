using AutoMapper;
using MTracksApi.Data;
using MTracksApi.Data.Repositories;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;
using System.Drawing.Drawing2D;

namespace MTracksApi.Services
{
    public class SongService
    {
        private readonly SongRepository _songRespository;
        private readonly ILogger<AlbumRepository> _logger;
        readonly IMapper _mapper;
        public SongService(SongRepository songRespository, ILogger<AlbumRepository> logger, IMapper mapper)
        {
            _songRespository = songRespository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<Song>>> GetSongs(PaginationFilterRequest filter, string route)
        {
            return await _songRespository.GetSongs(filter, route);
        }
    }
}
