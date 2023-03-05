using Assignment_Asp.NET1.Contexts;
using Assignment_Asp.NET1.Models.Identity;
using Assignment_Asp.NET1.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<IdentityContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Login";
});



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
