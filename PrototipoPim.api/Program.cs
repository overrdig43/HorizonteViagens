using PrototipoPim.RegraDeNegocio;
using PrototipoPim.Repositorio;
using PrototipoPim.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registra os serviços e repositórios para a injeção de dependência.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IViagemRepositorio, ViagemRepositorioMemoria>();
builder.Services.AddSingleton<IClienteRepositorio, ClienteRepositorioMemoria>();
builder.Services.AddScoped<ClienteNegocio>();

var app = builder.Build();

// A especificação OpenAPI fica disponível no ambiente de desenvolvimento.
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
