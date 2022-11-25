namespace MTracksApi.Data.Requests
{
    public class PaginationFilterRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilterRequest()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilterRequest(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
