using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTrello.Domain.Models;
using MyTrello.Domain.Services;
using MyTrello.Extensions;
using MyTrello.Persistance.Contexts;
using MyTrello.Resources;
using MyTrello.Resources.Communication;

namespace MyTrello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(  IUserService userService,
                                IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        public async Task<ResponseResult> GetAllAsync()
        {
            var users = await userService.GetAllAsync();
            var mappedUsers = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            var result = new ResponseResult
            {
                Data = mappedUsers,
                Message = "",
                Success = true
            };
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var newUser = mapper.Map<SaveUserResource, User>(resource);
            var response = await userService.AddAsync(newUser);
            var userResource = mapper.Map<User, UserResource>(newUser);
            var res = response.GetResponseResult(userResource);
            return Ok(res);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var user = mapper.Map<SaveUserResource, User>(resource);
            var response = await userService.UpdateAsync(id, user);
            var userResoure = mapper.Map<User, UserResource>(user);
            var res = response.GetResponseResult(userResoure);
            return Ok(res);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await userService.DeleteAsync(id);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }
    }
}
