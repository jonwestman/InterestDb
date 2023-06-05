using AutoMapper;
using InterestDb.Models;
using InterestDb.Models.DTO;

namespace InterestDb.Helper
{
	public class MappingConfig : Profile
	{
        public MappingConfig()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<InterestLink, InterestLinkDto>().ReverseMap();
			CreateMap<InterestLink, InterestLinkAddDto>().ReverseMap();
		}
    }
}
