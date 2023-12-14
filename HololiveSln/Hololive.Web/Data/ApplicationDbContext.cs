using Hololive.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Hololive.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<HololiveEntity> Users { get; set; }

        public DbSet<Products> Products { get; set; }
    }
}
