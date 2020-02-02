using Gunetberg.Domain;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gunetberg.Helpers
{
    public class TokenHelper
    {
        public static string GenerateToken(long id, Role role)
        {
            var utcNow = DateTime.UtcNow;

            //Claims
            var claimsIdentity = new ClaimsIdentity();
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Actor, id.ToString()));

            //Duración del token debe estar en configuración
            //Clave del token debe estar en configuración

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(
                    issuer: "http://gunetberg.es",
                    audience: "http://gunetberg.es",
                    subject: claimsIdentity,
                    notBefore: utcNow,
                    expires: utcNow.AddHours(1),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.Default.GetBytes("MG6zwQQsHys72LwmNUNHH3ZkS3w8WtL3KuugDpcfEDh8jVJZPjM5qQxTyruXZcTsERaUmz7GsH8xduwVew96ZTd5zWDYZ3AhJK5znpbt6vayHbkAtq6r6strmbJMDBGeLK4n6ARR7Y8fnnWkHYD6Y6NesEe67TdfRmCDzmkTV7mehZeAvt5BHfEw9r4SS4b69D2qMTz27CB4UmZ6rhwLxDXjTvWjGYfYFtgdXEb2pmAH54r4SfKuunkKW5q6uSP5")),
                        SecurityAlgorithms.HmacSha256Signature
                        )
                );

            return tokenHandler.WriteToken(token);

        }
    }
}
