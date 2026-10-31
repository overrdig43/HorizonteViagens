using PrototipoPim.RegraDeNegocio;
using PrototipoPim.Repositorio;
using PrototipoPim.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// A Web e a API compartilham os mesmos serviços e dados de demonstração.
builder.Services.AddSingleton<IViagemRepositorio, ViagemRepositorioMemoria>();
builder.Services.AddSingleton<IClienteRepositorio, ClienteRepositorioMemoria>();
builder.Services.AddScoped<ClienteNegocio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Viagens}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
