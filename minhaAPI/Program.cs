using Microsoft.EntityFrameworkCore;
using minhaAPI.Data;
using minhaAPI.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicione essa linha para configurar o contexto do Entity Framework com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoAzureSQL")));

// Add services to the container.
builder.Services.AddControllers();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Uma API simples para gerenciamento de nomes.",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = string.Empty,
            Url = new Uri("https://seusite.com.br"),
        },
        License = new OpenApiLicense
        {
            Name = "Use sob LICX",
            Url = new Uri("https://exemplo.com/licenca"),
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
