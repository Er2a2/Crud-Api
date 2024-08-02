using AutoMapper;
using Crud_Api.Models.Entities;
namespace Crud_Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest =>  dest.FullName, opt => opt.MapFrom(src => $"{src.Name} {src.Family}"));
        }
        //sad
    }
}
