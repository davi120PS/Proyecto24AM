using Microsoft.EntityFrameworkCore;
using Proyecto24AM.Context;
using Proyecto24AM.Services.IServices;
using Proyecto24AM.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//register services here
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("DefaultConenection")));

//Inyección de dependencias
builder.Services.AddTransient<IArticleServices, ArticleServices>();
//INVESTIGAR DIFERENCIA DE TIPOS DE DEPENDENCIA, TRASIENT, SCOPED,SIGLETON

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Article}/{action=Index}/{id?}");

app.Run();  
