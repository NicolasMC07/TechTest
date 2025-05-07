using api.Interfaces.Repository;
using api.Repositories;
using api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la conexión a SQL Server
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => 
    {
        policy.WithOrigins("http://localhost:5290") 
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
