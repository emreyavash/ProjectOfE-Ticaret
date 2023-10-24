using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectOfE_Ticaret.Business.Abstract;
using ProjectOfE_Ticaret.Core.JWT;
using ProjectOfE_Ticaret.DataAccess.ContextDb;
using ProjectOfE_Ticaret.Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using ProjectOfE_Ticaret.DataAccess.Abstract;
using ProjectOfE_Ticaret.DataAccess.EntityFramework;
using System.Reflection;
using ProjectOfE_Ticaret.Business.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ETicaretDbContext>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IUserRoleRepository,UserRoleRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IUserRoleDal, EfUserRoleDal>();
builder.Services.AddScoped<IRoleDal, EfRoleDal>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
