using Identity.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Microsoft.ServiceFabric.Services.Remoting.V2.FabricTransport.Client;
using musicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace musicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IIdentityService service;

        public UserController()
        {
            var proxyFactory = new ServiceProxyFactory(c => new FabricTransportServiceRemotingClientFactory());
            service = proxyFactory.CreateServiceProxy<IIdentityService>(new Uri("fabric:/musicproject/Identity"), new ServicePartitionKey(0));
        }

        // POST api/<ProductsController>
        [HttpPost("signup")]
        [AllowAnonymous]

        public async Task<ObjectResult> signup([FromBody] UserDTO value)
        {
            
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Username = value.Username,
                Email = value.Email,
                Password = value.Password,
                Role = "user"
            };
           
            bool result = await service.AddUser(newUser);
            if (result)
            {
                return Ok(value);
            }
            else
            {
                return BadRequest("user already taken");
            }
                      
        }

        // POST api/<ProductsController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ObjectResult> validate([FromBody] UserDTO value)
        {

            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Username = value.Username,
                Email = value.Email,
                Password = value.Password,
                Role = "user"
            };
            Dictionary<string,Guid> role = await service.ValiDateUser(newUser);
            if (role == null || role.Keys.FirstOrDefault() == "")
            {
                return BadRequest("no user found or wrong password");
            }
            else
            {

                var jwtsvc = new JWTServices(value, role.Keys.FirstOrDefault());
                var token = await jwtsvc.GenerateJwtToken(value);
                tokenDTO result = new tokenDTO
                {
                    Token = token,
                    User = role
                };
                return Ok(result);

            };
        }
    }
}
