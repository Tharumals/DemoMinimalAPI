using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinimalAPI.AutoMapper;
using MinimalAPI.Data;
using MinimalAPI.Models.DTOs;
using MinimalAPI.Repositories;
using MinimalAPI.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ??
        throw new InvalidOperationException("Sorry, your connection is not found"));
});
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "My API",
        Description = "An ASP.NET Core Web API for managing items",
       
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
       Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register", async (RegisterDTO registerDTO, IAccountServices account) =>
{
    return Results.Ok(await account.Register(registerDTO));
}).AllowAnonymous();

app.MapPost("/login", async (LoginDTO loginDTO, IAccountServices account) =>
{
    return Results.Ok(await account.Login(loginDTO));
}).AllowAnonymous();


app.MapGet("/GetProducts", async (IProductServices productService) =>
{
    return Results.Ok(await productService.GetAll());
}).RequireAuthorization();

app.MapGet("/GetProduct/{id:int}", async (IProductServices productService, int id) =>
{
    return Results.Ok(await productService.GetById(id));
}).RequireAuthorization();

app.MapPost("/AddProduct", async (AddRequestDTO request, IProductServices productService) =>
{
    return Results.Ok(await productService.Add(request));
}).RequireAuthorization();

app.MapPut("/UpdateProduct", async (UpdateRequestDTO request, IProductServices productService) =>
{
    return Results.Ok(await productService.Update(request));
}).RequireAuthorization();

app.MapDelete("/DeleteProduct/{id:int}", async (IProductServices productService, int id) =>
{
    return Results.Ok(await productService.Delete(id));
}).RequireAuthorization();
app.Run();


