using Microsoft.EntityFrameworkCore;
using MTracksApi.Data.Requests;
using MTracksApi.Data.Responses;
using MTracksApi.Helper;
using MTracksApi.Services;

namespace MTracksApi.Data.Repositories
{
    public class SongRepository : BaseRepository
    {
        private readonly IUriService uriService;

        public SongRepository(SqlServerContext context, IUriService uriService) : base(context)
        {
            this.uriService = uriService;
        }

        public async Task<PagedResponse<List<Song>>> GetSongs(PaginationFilterRequest filter, string route)
        {
            var validFilter = new PaginationFilterRequest(filter.PageNumber, filter.PageSize);

            var pagedData = await _context.Song
                            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                            .Take(validFilter.PageSize)
                            .ToListAsync();
            var totalRecords = await _context.Song.CountAsync();
            return PaginationHelper.CreatePagedReponse<Song>(pagedData, validFilter, totalRecords, uriService, route);
        }
    }
}
