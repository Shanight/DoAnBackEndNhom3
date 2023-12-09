using Microsoft.EntityFrameworkCore; 

namespace MyBGList.Models 
{ 
    public class ApplicationDbContext : DbContext 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        { 
        } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18,2)");


            base.OnModelCreating(modelBuilder);

            // Cấu hình liên kết giữa BoardGames và Domains
            modelBuilder.Entity<BoardGames_Domains>() 
                .HasKey(i => new { i.BoardGameId, i.DomainId });

            modelBuilder.Entity<BoardGames_Domains>() 
                .HasOne(x => x.BoardGame) 
                .WithMany(y => y.BoardGames_Domains) 
                .HasForeignKey(f => f.BoardGameId)
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoardGames_Domains>() 
                .HasOne(o => o.Domain) 
                .WithMany(m => m.BoardGames_Domains) 
                .HasForeignKey(f => f.DomainId) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình liên kết giữa BoardGames và Mechanics
            modelBuilder.Entity<BoardGames_Mechanics>() 
                .HasKey(i => new { i.BoardGameId, i.MechanicId });

            modelBuilder.Entity<BoardGames_Mechanics>() 
                .HasOne(x => x.BoardGame) 
                .WithMany(y => y.BoardGames_Mechanics) 
                .HasForeignKey(f => f.BoardGameId) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BoardGames_Mechanics>() 
                .HasOne(o => o.Mechanic) 
                .WithMany(m => m.BoardGames_Mechanics) 
                .HasForeignKey(f => f.MechanicId) 
                .IsRequired() 
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình cho Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Sakamata Chloe 2nd Anniversary Celebration", Price = 1210, ImageUrl = "../img/sanpham.jpg" }
                // Thêm các sản phẩm khác nếu cần
            );
        }

        public DbSet<BoardGame> BoardGames => Set<BoardGame>(); 
        public DbSet<Domain> Domains => Set<Domain>(); 
        public DbSet<Mechanic> Mechanics => Set<Mechanic>(); 
        public DbSet<BoardGames_Domains> BoardGames_Domains => Set<BoardGames_Domains>(); 
        public DbSet<BoardGames_Mechanics> BoardGames_Mechanics => Set<BoardGames_Mechanics>();
       
        public DbSet<Product> Products { get; set; }  // Cấu hình cho Product
        
    }
} 
