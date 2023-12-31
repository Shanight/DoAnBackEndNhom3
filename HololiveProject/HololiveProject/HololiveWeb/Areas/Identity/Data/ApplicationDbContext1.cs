﻿using HololiveWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HololiveWeb.API.Models;

public class ApplicationDbContext1 : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options)
        : base(options)
    {
    }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> cartItems{get;set;}
    public DbSet<CartModel> cartModels{get;set;}
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
