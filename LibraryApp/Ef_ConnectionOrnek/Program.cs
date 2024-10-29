using Ef_ConnectionOrnek.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("HomeConnection");

builder.Services.AddDbContext<LibraryContext>(Options=>Options.UseSqlServer(connectionString));

 

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );

app.Run(); 

