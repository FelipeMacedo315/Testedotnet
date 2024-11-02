using AutoMapper;
using crud_dotnet.entitys;

namespace TodoAPI.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

        }
    }
}