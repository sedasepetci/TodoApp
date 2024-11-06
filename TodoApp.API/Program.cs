
using Core.Tokens.Configurations;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Middlewares;
using TodoApp.DataAccess;
using TodoApp.DataAccess.Abstracts;
using TodoApp.DataAccess.Concretes;
using TodoApp.DataAccess.Contexts;
using TodoApp.Models.Entities;
using TodoApp.Service;
using TodoApp.Service.Abstracts;
using TodoApp.Service.Concretes;
using TodoApp.Service.Profiles;
using TodoApp.Service.Rules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddDataAccessDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();
builder.Services.AddScoped<DecoderService>();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<TokenOption>(builder.Configuration.GetSection("TokenOption"));


builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<BaseDbContext>();

var tokenOption = builder.Configuration.GetSection("TokenOption").Get<TokenOption>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt=>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOption.Issuer,
        ValidAudience = tokenOption.Audience[0],
        IssuerSigningKey = SecurityKeyHelper.GetSecurityKey(tokenOption.SecurityKey)
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler(_ => { });
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();