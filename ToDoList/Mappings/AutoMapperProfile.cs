using AutoMapper;
using ToDoList.DTOs;
using ToDoList.Models;

namespace ToDoList.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<TaskToDoCreateDto, TaskToDo>()
           .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => false))
           .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<TaskToDo, TaskToDoReadDto>();
        }
    }
}
