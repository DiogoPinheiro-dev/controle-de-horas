using Microsoft.EntityFrameworkCore;
using server.Db;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRecursoService, RecursoService>();

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();;

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>((options) => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
