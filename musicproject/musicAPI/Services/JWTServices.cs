using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using musicAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


public class JWTServices
{
    private readonly UserDTO identityDTO;
    private readonly string role;

    public JWTServices(UserDTO identityDTO, string role)
    {
        this.identityDTO = identityDTO;
        this.role = role;
    }

    //returnen van een anoniem object
    public async Task<object> GenerateJwtToken(UserDTO identityDTO)
    {
        //0. Geen gebruik van de signin manager voor het token-> deze signin manager 
        //maakt een autorisatie cookie aan . De signin manager gebruiken (Cookie 
        // authenticatie) zou kunnen als backup voor een falend token.

        //=> Token aanmaken na loggedin user  met extra claims + verplichte JWT claims.

        //1. Gebruiker opzoeken in de database met async UserManager en hash vergelijking

                
        try
        {

            //2.2. Noodzakelijke claims komende vd JWD spec
            var claims = new List<Claim>
             {
                //JWT claims zijn ingebouwd in de JWT spec: "sub"scriber, JWT Id
                 new Claim(JwtRegisteredClaimNames.Sub, identityDTO.Username),  //subscriber
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim("role", role),
                 new Claim("username", identityDTO.Username),
             };   //nog de extra userClaims toevoegen.

            //3. Sigin credentials met de symmetric key & encryptie methode
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Musicprojectdinkkeynoglangermisschien"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); //key en protocol

            //4. aanmaken van het token
            var token = new JwtSecurityToken(
             issuer: "http://laptopjules:8863",  //onze website
             audience: "http://laptopjules",//gebruikers
             claims: claims,
             expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(30)),
             signingCredentials: creds //controleert token v
             );

            //5. user info returnen (vervaldatum als additionele info)
            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token), //token generator
                expiration = token.ValidTo
            };
        }
        catch (Exception exc)
        {
            
        }
        return new { error = "Failed to generate JWT token" }; //minimale info ->meer in de logger
    }
}