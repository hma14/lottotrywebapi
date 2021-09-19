namespace Lottotry.WebApi.Domain.BC49.Mappings
{
    using Lottotry.WebApi.Dtos.BC49;
    using AutoMapper;
    using Lottotry.WebApi.Domain.BC49;

    public class BC49Profile : Profile
    {
        public BC49Profile()
        {
            //createmap<to this, from this>
            CreateMap<BC49, BC49Dto>()
                .ReverseMap();
            CreateMap<BC49ForCreationDto, BC49>();
            CreateMap<BC49ForUpdateDto, BC49>()
                .ReverseMap();
        }
    }
}