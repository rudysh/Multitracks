using Microsoft.EntityFrameworkCore;

namespace MTracksApi.Data
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album{ get; set; }
        public virtual DbSet<Artist> Artist{ get; set; }
        public virtual DbSet<Song> Song { get; set; }
    }
}
