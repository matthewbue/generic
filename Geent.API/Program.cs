using Geent.Infrastructure.ConfigurationDB;
using Geent.Ioc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Obtendo a chave secreta do JWT das configurações
var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];

// Registrando os serviços da aplicação
builder.Services.AddApplicationServices(builder.Configuration);

// Configuração do JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Adicionando CORS e configurando uma política global
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // Permite qualquer origem (para desenvolvimento)
              .AllowAnyMethod()    // Permite qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader();   // Permite qualquer cabeçalho
    });
});

// Adicionando suporte a controladores e serviços adicionais
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicando a política de CORS
app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
