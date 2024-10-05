
using Kennysfintech.Bll.Abstract;
using Kennysfintech.Bll.Concrete;
using Kennysfintech.Bll.Utilities.Abstract;
using Kennysfintech.Bll.Utilities.Concrete;
using Kennysfintech.Dal.Abstract;
using Kennysfintech.Dal.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// JwtSettings ayarlarýný appsettings.json'dan yükle
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// SecretKey boþ ise hata fýrlat
var secretKey = jwtSettings.GetValue<string>("SecretKey");
if (string.IsNullOrEmpty(secretKey))
{
    throw new ArgumentNullException(nameof(secretKey), "SecretKey cannot be null or empty.");
}

// Authentication servisini ekle
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],            // appsettings.json'dan gelen Issuer
        ValidAudience = jwtSettings["Audience"],        // appsettings.json'dan gelen Audience
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))  // SecretKey
    };
});

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddSingleton<IAdminService,AdminService>();
builder.Services.AddSingleton<IUserService,UserService>();
builder.Services.AddSingleton<ITokenService,TokenService>();
builder.Services.AddSingleton<ICompanyService,CompanyService>();
builder.Services.AddSingleton<IRepositoryService, RepositoryMsSqlService>();


builder.Services.AddCors(p => p.AddPolicy("kennysWebCors", bb => { bb.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("kennysWebCors");

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
