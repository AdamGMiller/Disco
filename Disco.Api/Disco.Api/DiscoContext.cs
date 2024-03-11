using Microsoft.EntityFrameworkCore;

namespace Disco.Api
{
    using Disco.Api.Entities;

    public class DiscoContext : DbContext
    {
        public DiscoContext(DbContextOptions<DiscoContext> options) : base(options) { }

        public DbSet<Tile> Tiles { get; set; }
    }
}
