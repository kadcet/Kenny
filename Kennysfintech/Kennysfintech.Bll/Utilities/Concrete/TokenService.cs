using Kennysfintech.Bll.Utilities.Abstract;
using Kennysfintech.Model.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kennysfintech.Bll.Utilities.Concrete
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserDto user)
        {
            // 1. Token'a eklenecek bilgiler (Claims)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),               // Kullanıcı ID
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),             // Kullanıcı adı
            new Claim(ClaimTypes.Name, user.NameSurname),                             // Kullanıcı tam adı
            new Claim(JwtRegisteredClaimNames.Email, user.EMail),                    // Kullanıcı email
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())        // Token ID (benzersiz ID)
        };

            // 2. SecretKey (appsettings.json'dan alınıyor)
            var secretKey = _configuration["JwtSettings:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentNullException(nameof(secretKey), "SecretKey cannot be null or empty.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 3. Token'in ne kadar süre geçerli olacağı (Expiration)
            var expiration = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationMinutes"]));

            // 4. JWT oluşturma
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],           // Token'ı oluşturan (issuer)
                audience: _configuration["JwtSettings:Audience"],       // Token'ı alan (audience)
                claims: claims,                                         // Token'a eklenen bilgiler (claims)
                expires: expiration,                                    // Geçerlilik süresi
                signingCredentials: creds                               // İmzalama anahtarı ve algoritması
            );

            // 5. Token'ı string olarak döndürme
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
