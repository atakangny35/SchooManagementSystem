using Microsoft.IdentityModel.Tokens;
using OkulY�netim.Entity.EntityFramework.Concrete;
using OkulY�netim.Entity.EntityFramework.Context;
using OkulY�netim.Entity.EntityFramework.interfaces;
using OkulY�netim.Utilities.JWT.Abstract;
using OkulY�netim.Utilities.JWT.Constance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using OkulY�netim.Utilities;
using OkulY�netim.Costum_Tools.RabbitMQ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var tokenopt = builder.Configuration.GetSection("TokenOptions").Get<TokenOption>();

builder.Services.AddControllers();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(
        name: "AllowOrigin",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.WithMethods("GET", "POST", "PUT", "DELETE");
        builder.AllowAnyHeader();
    }

    );
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{

    //ValidateIssuer = true,
    //ValidateAudience = true,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero,
    ValidIssuer = tokenopt.Issuer,
    ValidAudience = tokenopt.Audience,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenopt.SecurityKey))

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserRoleRepository, EfUserRoleRepository>();
builder.Services.AddScoped<IUserClassRepository, EfUserClassRepository>();
builder.Services.AddScoped<IUserDersRepository, EfUserDersRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<INoteRepository, EfNoteRepository>();
builder.Services.AddScoped<IMessagesRepository, EfMessagesRepository>();
builder.Services.AddScoped<IClassepository, EfClassRepository>();
builder.Services.AddScoped<IJwtHelper, JwtGenerator>();
builder.Services.AddScoped<HashingHelper>();
builder.Services.AddScoped<IDersRepository,EfDersRepository>();
builder.Services.AddScoped<RabbitMQRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
