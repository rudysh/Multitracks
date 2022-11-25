using AutoMapper;
using Microsoft.AspNetCore.Routing;
using MTracksApi.Data;
using MTracksApi.Data.Repositories;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;

namespace MTracksApi.Services
{
    public class ArtistService
    {
        private readonly ILogger<ArtistService> _logger;
        private readonly IMapper _mapper;
        private readonly ArtistRepository _artistRepository;

        public ArtistService(ArtistRepository artistRepository, IMapper mapper, ILogger<ArtistService> logger)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PagedResponse<List<Artist>>> GetArtists(PaginationFilterRequest filter,string route)
        {
            return await _artistRepository.GetArtists(filter, route);
        }

        public async Task<PagedResponse<List<Artist>>> GetArtistsByName(string name, PaginationFilterRequest filter, string route)
        {
            return await _artistRepository.GetArtistByName(name, filter, route);
        }

        public async Task<Artist> CreateAsync(CreateArtistRequest request)
        {
            return await _artistRepository.CreateArtist(request);
        }

    }


}
