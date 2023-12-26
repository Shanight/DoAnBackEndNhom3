using HololiveWeb.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext1>(options =>
    options.UseSqlServer("Server=.\\SQLEXPRESS;Database=HololiveShop3;User Id=sa;Password=123;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True"));
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/Products/Create", "/products/create");
}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext1>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();



app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "admin",
        areaName: "Admin",
        pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "products",
        pattern: "products/{action=Index}/{id?}",
        defaults: new { controller = "Products", action = "Index" }
    );

    endpoints.MapControllerRoute(
        name: "events",
        pattern: "events/{action=Index}/{id?}",
        defaults: new { controller = "Events", action = "Index" }
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
