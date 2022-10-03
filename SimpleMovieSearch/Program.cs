using Microsoft.EntityFrameworkCore;
using SimpleMovieSearch.DAL;
using SimpleMovieSearch.DAL.Interfaces;
using SimpleMovieSearch.DAL.Repositories;
using SimpleMovieSearch.Domain.Entity;
using SimpleMovieSearch.Service.Execution;
using SimpleMovieSearch.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBaseRepositoriy<Movie>, MovieRepositoriy>();
builder.Services.AddScoped<IMovieService, MovieService>();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
