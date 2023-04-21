using FNStore.Data.EF;
using FNStore.Data.EF.Repositories;
using FNStore.Domain.Contracts.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FNStoreDataContext>(options => options.UseNpgsql(@"postgres://postgres:Postgres2023!@postgres-compose:15432/fnstore"));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<FNStoreDataContext>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepositoryEF>();

builder.Services.AddScoped<ITipoDeProdutoRepository, TipoDeProdutoRepositoryEF>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoryEF>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryEF<>));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => options.LoginPath = "/Conta/Login");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Index");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Produtos}/{action=DelProd}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Produtos}/{action=AddEdit}/{id?}");
});

app.Run();