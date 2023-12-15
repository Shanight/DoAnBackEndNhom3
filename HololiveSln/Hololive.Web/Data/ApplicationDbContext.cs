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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Products> Products { get; set; }
    }
}
