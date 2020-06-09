using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyTrello.Domain.Services;
using MyTrello.Extensions;
using MyTrello.Resources;
using MyTrello.Resources.Communication;

namespace MyTrello.Controllers
{
    
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IMapper mapper;
        public TaskController( ITaskService taskService,
                               IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }
        // GET api/values
        [HttpGet]
        [ActionName("getAll")]
        public async Task<ResponseResult> GetAllAsync()
        {
            var tasks = await taskService.GetAllAsync();
            var mappedTasks = mapper.Map<IEnumerable<MyTrello.Domain.Models.Task>, IEnumerable<TaskResource>>(tasks);
            var result = new ResponseResult
            {
                Data = mappedTasks,
                Message = mappedTasks.Count() > 0 ? $"Result: {mappedTasks.Count()} items" : "Result: 0 items",
                Success = true
            };
            return result;
        }
        [HttpGet("{id}")]
        [ActionName("userTasks")]
        public async Task<ResponseResult> GetUsersTasks(int id)
        {
            var usersTasks = await taskService.GetUsersTasksAsync(id);
            var mappedUsersTasks = mapper.Map<IEnumerable<MyTrello.Domain.Models.Task>, IEnumerable<TaskResource>>(usersTasks);
            var result = new ResponseResult
            {
                Data = mappedUsersTasks,
                Message = mappedUsersTasks.Count() > 0 ? $"Result: {mappedUsersTasks.Count()} items" : "Result: 0 items",
                Success = true
            };
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ActionName("getOne")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await taskService.GetByIdAsync(id);
            var resource = mapper.Map<Domain.Models.Task, TaskResource>(response.Task);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }

        // POST api/values
        [HttpPost]
        [ActionName("addTask")]
        public async Task<IActionResult> PostAsync([FromBody] SaveTaskResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var newTask = mapper.Map<SaveTaskResource, MyTrello.Domain.Models.Task>(resource);
            newTask.Task_CreateDate = DateTime.Now.Date;
            var response = await taskService.AddAsync(newTask);
            var taskResource = mapper.Map<MyTrello.Domain.Models.Task, TaskResource>(newTask);
            var res = response.GetResponseResult(taskResource);
            return Ok(res);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ActionName("updateTask")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTaskResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var updatedTask = mapper.Map<SaveTaskResource, MyTrello.Domain.Models.Task>(resource);
            var response = await taskService.UpdateAsync(id, updatedTask);
            var taskResoure = mapper.Map<MyTrello.Domain.Models.Task, TaskResource>(updatedTask);
            var res = response.GetResponseResult(taskResoure);
            return Ok(res);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ActionName("deleteTask")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await taskService.DeleteAsync(id);
            var resource = mapper.Map<MyTrello.Domain.Models.Task, TaskResource>(response.Task);
            var res = response.GetResponseResult(resource);
            return Ok(res);
        }
    }
}