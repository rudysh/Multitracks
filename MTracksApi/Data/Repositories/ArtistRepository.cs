using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;
using MTracksApi.Helper;
using MTracksApi.Services;

namespace MTracksApi.Data.Repositories
{
    public class ArtistRepository : BaseRepository
    {
        private readonly IUriService uriService;
        public ArtistRepository(SqlServerContext context, IUriService uriService) : base(context)
        {
            this.uriService = uriService;
        }


        public async Task<PagedResponse<List<Artist>>> GetArtists(PaginationFilterRequest filter, string route)
        {
            var validFilter = new PaginationFilterRequest(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Artist
                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                            .Take(validFilter.PageSize)
            .ToListAsync();
            var totalRecords = await _context.Artist.CountAsync();
            return PaginationHelper.CreatePagedReponse<Artist>(pagedData, validFilter, totalRecords, uriService, route);
        }

        public async Task<PagedResponse<List<Artist>>> GetArtistByName(string name, PaginationFilterRequest filter, string route)
        {
            var validFilter = new PaginationFilterRequest(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.Artist.Where(f => f.title.Contains(name))
                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                    .Take(validFilter.PageSize).ToListAsync();
            var totalRecords = await _context.Artist.Where(f => f.title.Contains(name)).CountAsync();
            return PaginationHelper.CreatePagedReponse<Artist>(pagedData, validFilter, totalRecords, uriService, route);

        }

        public async Task<Artist> CreateArtist(CreateArtistRequest request)
        {
            var newArtist = new Artist{ };
            newArtist.heroURL = request.heroURL;
            newArtist.dateCreation = request.dateCreation;
            newArtist.imageURL = request.imageURL;
            newArtist.biography = request.biography;
            newArtist.title = request.title;
            await _context.AddAsync(newArtist);
            await _context.SaveChangesAsync();
            return newArtist;
        }
    }
}
