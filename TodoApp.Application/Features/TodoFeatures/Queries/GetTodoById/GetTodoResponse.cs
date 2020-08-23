using AutoMapper;
using System;
using TodoApp.Application.Mappings;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Features.TodoFeatures.Queries.GetTodoById
{
    public class GetTodoResponse: IMapFrom<Todo>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public int PriorityLevel { get; set; }
        public DateTime CreatedOn { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Todo, GetTodoResponse>()
                .ForMember(d => d.PriorityLevel, opt => opt.MapFrom(s => (int)s.Priority));
        }
    }
}
