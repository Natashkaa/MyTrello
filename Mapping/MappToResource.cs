using AutoMapper;
using MyTrello.Domain.Models;
using MyTrello.Resources;
using System.Linq;

namespace MyTrello.Mapping
{
    public class MappToResource : Profile
    {
        public MappToResource()
        {
            CreateMap<User, UserResource>();
            CreateMap<Task, TaskResource>()
                        .ForMember(t => t.User, el => el.MapFrom(u => new User(){ 
                                                                                 UserId = (int)u.Users.UserId,
                                                                                 User_FirstName = u.Users.User_FirstName,
                                                                                 User_LastName = u.Users.User_LastName,
                                                                                 User_Email = u.Users.User_Email,
                                                                                 User_PhotoPath = u.Users.User_PhotoPath
                                                                                }));
        }
    }
}