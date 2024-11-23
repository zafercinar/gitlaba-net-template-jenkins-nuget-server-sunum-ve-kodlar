using AutoMapper;
using ZACx.Templates.WebApiProject.Core.DTOs.Examples;
using ZACx.Templates.WebApiProject.Core.Models.Response.Examples;
using ZACx.Templates.WebApiProject.Entities.Entities;

namespace ZACx.Templates.WebApiProject.Business.Mappings.Examples
{
    internal class ExampleMappingProfile : Profile
    {
        internal ExampleMappingProfile()
        {
            CreateMap<Example, ExampleDto>()
                .ForMember(destination => destination.Id, operation => operation.MapFrom(source => source.ExampleId));

            CreateMap<ExampleDto, ExampleResponseModel>()
                .ForMember(destination => destination.Example.ExCode, operation => operation.MapFrom(source => source.Code))
                .ForMember(destination => destination.Example.FullName, operation => operation.MapFrom(source => source.Name))
                .ForMember(destination => destination.Example.Definition, operation => operation.MapFrom(source => source.Description))
                .ForMember(destination => destination.Example.IsSendMail, operation => operation.MapFrom(source => source.DoSendMail))
                ;
        }
    }
}
