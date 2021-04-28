using Microsoft.EntityFrameworkCore;

namespace Pastebin_backend.Models
{
    public class PastebinContext : DbContext
    {
        public PastebinContext(DbContextOptions<PastebinContext> options)
            : base(options)
        {
        }

        public DbSet<Pastebin> Pastebins { get; set; }
    }
}
