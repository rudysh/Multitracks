namespace MTracksApi.Data.Requests
{
    public class FindArtistRequest : PaginationFilterRequest
    {
        public string? artistTittle { get; set; }
    }
}
