using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyTrello.Domain.Models;

namespace MyTrello.Extensions
{
    public static class UserExtensions
    {
        public static void GenerateTokenString(this User user, string secret, int expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.User_FirstName));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),//theme of token
                Expires = DateTime.UtcNow.AddMinutes(expires),//token lifetime
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
        }
    }
}