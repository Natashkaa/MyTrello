using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTrello.Domain.Services;
using MyTrello.Resources;
using MyTrello.Resources.Communication;

namespace MyTrello.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<ResponseResult> GetAllAsync()
        {
            var tasks = await taskService.GetAllAsync();
            var mappedUsers = mapper.Map<IEnumerable<MyTrello.Domain.Models.Task>, IEnumerable<TaskResource>>(tasks);
            var result = new ResponseResult
            {
                Data = mappedUsers,
                Message = "",
                Success = true
            };
            return result;
        }
    }
}