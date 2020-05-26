using AutoMapper;
using MyTrello.Domain.Models;
using MyTrello.Resources;

namespace MyTrello.Mapping
{
    public class MappToModel : Profile
    {
        public MappToModel()
        {
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
            CreateMap<TaskResource, Task>();
        }
    }
}