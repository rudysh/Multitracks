using Microsoft.EntityFrameworkCore;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;
using MTracksApi.Helper;
using MTracksApi.Services;

namespace MTracksApi.Data.Repositories
{
    public class AlbumRepository : BaseRepository
    {
        private readonly IUriService uriService;

        public AlbumRepository(SqlServerContext context, IUriService uriService) : base(context)
        {
            this.uriService = uriService;
        }

        public async Task<PagedResponse<List<Album>>> GetAlbumss(PaginationFilterRequest filter, string route)
        {
            var validFilter = new PaginationFilterRequest(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Album
                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                            .Take(validFilter.PageSize)
            .ToListAsync();
            var totalRecords = await _context.Album.CountAsync();
            return PaginationHelper.CreatePagedReponse<Album>(pagedData, validFilter, totalRecords, uriService, route);
        }
    }
}
