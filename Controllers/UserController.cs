using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTrello.Domain.Models;
using MyTrello.Domain.Services;
using MyTrello.Extensions;
using MyTrello.Persistance.Contexts;
using MyTrello.Resources;
using MyTrello.Resources.Communication;

namespace MyTrello.Controllers
{
    [Route("api/[controller]/[action]")]
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
        [ActionName("getAll")]
        public async Task<ResponseResult> GetAllAsync()
        {
            var users = await userService.GetAllAsync();
            var mappedUsers = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            var result = new ResponseResult
            {
                Data = mappedUsers,
                Message = mappedUsers.Count() > 0 ? $"Result: {mappedUsers.Count()} items" : "Result: 0 items",
                Success = true
            };
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ActionName("getOne")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await userService.GetByIdAsync(id);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }

        // POST api/values
        [HttpPost]
        [ActionName("addUser")]
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
        [ActionName("updateUser")]
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
        [ActionName("deleteUser")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await userService.DeleteAsync(id);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }

        // UPDATE USER PHOTO api/user/update_photo/5
        [HttpPost("{id:int}")]
        [ActionName("update_photo")]
        public async Task<IActionResult> UpdateUserPhoto(int id, [FromForm] IFormFile uploadedFile)
        {
            var response = await userService.UpdatePhoto(id, uploadedFile);
            var resource = mapper.Map<User, UserResource>(response.User);
            var res = response.GetResponseResult(resource);
            return Ok(res);
            // Byte[] b = System.IO.File.ReadAllBytes("Files/Natali1.png");   // You can use your own method over here.         
            // return File(b, "image/png");
            //var dir = Server.MapPath("/Images");
            //var path = Path.Combine(dir, id + ".jpg"); //validate the path for security or use other means to generate the path.
            //return base.File("Files/Natali1.png", "image/png");
            //var resource = mapper.Map<User, UserResource>(response.User);
            //var res = response.GetResponseResult(resource);
            //return Ok(base.File("Files/Natali1.png", "image/png"));
            // FileStream fs = new FileStream("Files/Natali1.png", FileMode.Open);
            
            //     HttpResponseMessage res = new HttpResponseMessage(); 
            //     res.Content = new StreamContent(fs);
            //     res.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            //     return res;
            // }
        }
        // GET USER PHOTO api/user/get_photo/Files/User1.png
        [HttpGet("{path}")]
        [ActionName("get_photo")]
        public async Task<IActionResult> GetUserPhoto(string path)
        {
            var result = await System.Threading.Tasks.Task.Run(() => {
                byte[] imageByteArray = null;
                try{
                    FileStream fileStream = new FileStream("Files/" + path, FileMode.Open, FileAccess.Read);
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        imageByteArray = new byte[reader.BaseStream.Length];
                        for (int i = 0; i < reader.BaseStream.Length; i++)
                            imageByteArray[i] = reader.ReadByte();
                    }
                    return imageByteArray;
                }
                catch(FileNotFoundException ex){
                    return null;
                }
            });
            return Ok(result);
        }
    }
}
