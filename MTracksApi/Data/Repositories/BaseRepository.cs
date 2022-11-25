namespace MTracksApi.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly SqlServerContext _context;
        public BaseRepository(SqlServerContext context)
        {
            _context = context;
        }
    }
}
