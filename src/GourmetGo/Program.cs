using GourmetGo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
    name: "cliente",
    pattern: "cliente",
    defaults: new { controller = "Cliente", action = "Index" });

app.MapControllerRoute(
    name: "cardapio",
    pattern: "cliente/cardapio",
    defaults: new { controller = "Cliente", action = "Cardapio" });
app.MapControllerRoute(
    name: "pedidos",
    pattern: "cliente/pedidos",
    defaults: new { controller = "Cliente", action = "Pedidos" });
app.MapControllerRoute(
    name: "configuracoes",
    pattern: "cliente/configuracoes",
    defaults: new { controller = "Cliente", action = "Configuracoes" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
