using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Services;
using server.Interfaces;
// using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IRecursoService, RecursoService>();

builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ISubTarefaService, SubTarefaService>();
builder.Services.AddScoped<IApontamentoService, ApontamentoService>();

builder.Services.AddScoped<IEmpresaClienteService, EmpresaClienteService>();
builder.Services.AddScoped<IEmpresaRecursoService, EmpresaRecursoService>();
builder.Services.AddScoped<IEmpresaServicoService, EmpresaServicoService>();

builder.Services.AddControllers();
    // .AddJsonOptions(options =>
    // {
    //     options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //     options.JsonSerializerOptions.MaxDepth = 64; // Opcional: aumenta o limite de profundidade
    // });

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
