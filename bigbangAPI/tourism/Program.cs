using tourismBigbang.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using tourismBigBang.Services.UserViewService;
using tourismBigBang.Repository.UserViewRepo;
using tourismBigBang.Repository.AgentViewRepo;
using tourismBigBang.Services.AgentViewService;
using tourismBigBang.Repository.AdminViewRepo;
using tourismBigBang.Services.AdminViewService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TourismContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("loginsetup"));
});
builder.Services.AddScoped<IUserViewRepo, UserViewRepo>();
builder.Services.AddScoped<IUserViewService, UserViewService>();
builder.Services.AddScoped<IAgentViewRepo, AgentViewRepo>();
builder.Services.AddScoped<IAgentViewService, AgentViewService>();
builder.Services.AddScoped<IAdminViewRepo, AdminViewRepo>();
builder.Services.AddScoped<IAdminViewService, AdminViewService>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret.....")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
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

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
