using HololiveWeb.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HololiveWeb API", Version = "v1" });
});

// Add your DbContext registration here
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HololiveWeb API V1");
    });
}

app.UseHttpsRedirection();

// Endpoint for getting all Abouts
app.MapGet("/api/abouts", (ApplicationDbContext dbContext) =>
{
    var abouts = dbContext.Abouts.ToList();
    return abouts;
})
.WithName("GetAbouts")
.WithOpenApi();

// POST endpoint for About
app.MapPost("/api/abouts", (ApplicationDbContext dbContext, About about) =>
{
    dbContext.Abouts.Add(about);
    dbContext.SaveChanges();
    return Results.Created($"/api/abouts/{about.Id}", about);
})
.WithName("CreateAbout")
.WithOpenApi();

// PUT endpoint for About
app.MapPut("/api/abouts/{id}", (int id, ApplicationDbContext dbContext, About about) =>
{
    if (id != about.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(about).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateAbout")
.WithOpenApi();

// DELETE endpoint for About
app.MapDelete("/api/abouts/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingAbout = dbContext.Abouts.Find(id);
    if (existingAbout == null)
    {
        return Results.NotFound();
    }

    dbContext.Abouts.Remove(existingAbout);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteAbout")
.WithOpenApi();

// Endpoint for getting all Products
app.MapGet("/api/products", (ApplicationDbContext dbContext) =>
{
    var products = dbContext.Products.ToList();
    return products;
})
.WithName("GetProducts")
.WithOpenApi();

// POST endpoint for Product
app.MapPost("/api/products", (ApplicationDbContext dbContext, Product product) =>
{
    dbContext.Products.Add(product);
    dbContext.SaveChanges();
    return Results.Created($"/api/products/{product.Id}", product);
})
.WithName("CreateProduct")
.WithOpenApi();

// PUT endpoint for Product
app.MapPut("/api/products/{id}", (int id, ApplicationDbContext dbContext, Product product) =>
{
    if (id != product.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateProduct")
.WithOpenApi();

// DELETE endpoint for Product
app.MapDelete("/api/products/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingProduct = dbContext.Products.Find(id);
    if (existingProduct == null)
    {
        return Results.NotFound();
    }

    dbContext.Products.Remove(existingProduct);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteProduct")
.WithOpenApi();

// Endpoint for getting all Users
app.MapGet("/api/users", (ApplicationDbContext dbContext) =>
{
    var users = dbContext.Users.ToList();
    return users;
})
.WithName("GetUsers")
.WithOpenApi();

// POST endpoint for User
app.MapPost("/api/users", (ApplicationDbContext dbContext, User user) =>
{
    dbContext.Users.Add(user);
    dbContext.SaveChanges();
    return Results.Created($"/api/users/{user.Id}", user);
})
.WithName("CreateUser")
.WithOpenApi();

// PUT endpoint for User
app.MapPut("/api/users/{id}", (int id, ApplicationDbContext dbContext, User user) =>
{
    if (id != user.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateUser")
.WithOpenApi();

// DELETE endpoint for User
app.MapDelete("/api/users/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingUser = dbContext.Users.Find(id);
    if (existingUser == null)
    {
        return Results.NotFound();
    }

    dbContext.Users.Remove(existingUser);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteUser")
.WithOpenApi();

// Endpoint for getting all Categories
app.MapGet("/api/categories", (ApplicationDbContext dbContext) =>
{
    var categories = dbContext.Categories.ToList();
    return categories;
})
.WithName("GetCategories")
.WithOpenApi();

// POST endpoint for Category
app.MapPost("/api/categories", (ApplicationDbContext dbContext, Category category) =>
{
    dbContext.Categories.Add(category);
    dbContext.SaveChanges();
    return Results.Created($"/api/categories/{category.Id}", category);
})
.WithName("CreateCategory")
.WithOpenApi();

// PUT endpoint for Category
app.MapPut("/api/categories/{id}", (int id, ApplicationDbContext dbContext, Category category) =>
{
    if (id != category.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateCategory")
.WithOpenApi();

// DELETE endpoint for Category
app.MapDelete("/api/categories/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingCategory = dbContext.Categories.Find(id);
    if (existingCategory == null)
    {
        return Results.NotFound();
    }

    dbContext.Categories.Remove(existingCategory);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteCategory")
.WithOpenApi();

// Endpoint for getting all Events
app.MapGet("/api/events", (ApplicationDbContext dbContext) =>
{
    var events = dbContext.Events.ToList();
    return events;
})
.WithName("GetEvents")
.WithOpenApi();

// POST endpoint for Event
app.MapPost("/api/events", (ApplicationDbContext dbContext, Event eventItem) =>
{
    dbContext.Events.Add(eventItem);
    dbContext.SaveChanges();
    return Results.Created($"/api/events/{eventItem.Id}", eventItem);
})
.WithName("CreateEvent")
.WithOpenApi();

// PUT endpoint for Event
app.MapPut("/api/events/{id}", (int id, ApplicationDbContext dbContext, Event eventItem) =>
{
    if (id != eventItem.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(eventItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateEvent")
.WithOpenApi();

// DELETE endpoint for Event
app.MapDelete("/api/events/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingEvent = dbContext.Events.Find(id);
    if (existingEvent == null)
    {
        return Results.NotFound();
    }

    dbContext.Events.Remove(existingEvent);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteEvent")
.WithOpenApi();

// Endpoint for getting all Carts
app.MapGet("/api/carts", (ApplicationDbContext dbContext) =>
{
    var carts = dbContext.Carts.ToList();
    return carts;
})
.WithName("GetCarts")
.WithOpenApi();

// POST endpoint for Cart
app.MapPost("/api/carts", (ApplicationDbContext dbContext, Cart cart) =>
{
    dbContext.Carts.Add(cart);
    dbContext.SaveChanges();
    return Results.Created($"/api/carts/{cart.Id}", cart);
})
.WithName("CreateCart")
.WithOpenApi();

// PUT endpoint for Cart
app.MapPut("/api/carts/{id}", (int id, ApplicationDbContext dbContext, Cart cart) =>
{
    if (id != cart.Id)
    {
        return Results.BadRequest("Id mismatch");
    }

    dbContext.Entry(cart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("UpdateCart")
.WithOpenApi();

// DELETE endpoint for Cart
app.MapDelete("/api/carts/{id}", (int id, ApplicationDbContext dbContext) =>
{
    var existingCart = dbContext.Carts.Find(id);
    if (existingCart == null)
    {
        return Results.NotFound();
    }

    dbContext.Carts.Remove(existingCart);
    dbContext.SaveChanges();
    return Results.NoContent();
})
.WithName("DeleteCart")
.WithOpenApi();

app.Run();
