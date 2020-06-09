using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTrello.Domain.Models;
using MyTrello.Domain.Services;
using MyTrello.Extensions;
using MyTrello.Resources;

namespace MyTrello.Controllers
{
    [Route("/api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService service;
        private readonly IMapper mapper;
        public AuthenticateController(IAuthenticationService service,
                                      IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            var authUser = await service.AuthenticateAsync(user.User_Email, user.User_Password);
            var userResource = mapper.Map<User, UserResource>(authUser.User);
            var res = authUser.GetResponseResult(userResource);
            return Ok(res);
        }
    }
}