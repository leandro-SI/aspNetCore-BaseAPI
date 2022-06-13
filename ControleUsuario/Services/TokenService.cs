using ControleUsuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControleUsuario.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> user)
        {
            Claim[] direitosUser = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("lfli803nvnkw9302"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitosUser,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);

        }
    }
}
