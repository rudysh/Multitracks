using MTracksApi.Data.Requests;

namespace MTracksApi.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilterRequest filter, string route);
    }
}
