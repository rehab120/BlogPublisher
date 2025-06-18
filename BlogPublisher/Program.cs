using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Context;
using WebApplication1.Repositry;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogDbContext>(
 OptionsBuilder =>
 {
     OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("con"));
 }

);
//Register
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

}
 ).AddEntityFrameworkStores<BlogDbContext>();
builder.Services.AddScoped<IAuthorRepositry, AuthorRepositry>();
builder.Services.AddScoped<IPostRepositry, PostRepositry>();
builder.Services.AddScoped<IDepartmentRepositry, DepartmentRepositry>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Filter Authorize "Cookie"
app.UseAuthorization();//hint

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
