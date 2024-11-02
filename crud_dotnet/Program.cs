using AutoMapper;
using crud_dotnet.entitys;
using crud_dotnet.Middleware;
using crud_dotnet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de serviços adicionais
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseInMemoryDatabase("NomeDoBancoEmMemoria"));  
builder.Services.AddScoped<crud_dotnet.Interface.IUserServices, UserServices>();  
builder.Services.AddAutoMapper(typeof(Program));  // Adicione esta linha
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLogging();  

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.UseAuthorization();

app.MapControllers();

app.Run();
