namespace MTracksApi.Data.Requests
{
    public class CreateArtistRequest
    {
        public DateTime dateCreation { get; set; }
        public string? title { get; set; }
        public string? biography { get; set; }
        public string? imageURL { get; set; }
        public string? heroURL { get; set; }
    }
}
