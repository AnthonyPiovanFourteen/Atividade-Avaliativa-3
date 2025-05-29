using Microsoft.EntityFrameworkCore;
using PetShopAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

var conexao = builder.Configuration.GetConnectionString("DefaultConnection");
if (conexao == null)
    conexao = "Data Source=petshop.db";

builder.Services.AddDbContext<PetShopContext>(opt => opt.UseSqlite(conexao));

// Adiciona o Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Garante que o banco de dados seja criado ao iniciar a aplicação
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<PetShopContext>();
try
{
    context.Database.EnsureCreated();
}
catch (Exception ex)
{
    Console.WriteLine("Erro: " + ex.Message);
}

app.Run();
