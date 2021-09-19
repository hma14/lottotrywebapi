namespace Lottotry.WebApi.Domain.Lotto649.Mappings
{
    using Lottotry.WebApi.Dtos.Lotto649;
    using AutoMapper;
    using Lottotry.WebApi.Domain.Lotto649;

    public class Lotto649Profile : Profile
    {
        public Lotto649Profile()
        {
            //createmap<to this, from this>
            CreateMap<Lotto649, Lotto649Dto>()
                .ReverseMap();
            CreateMap<Lotto649ForCreationDto, Lotto649>();
            CreateMap<Lotto649ForUpdateDto, Lotto649>()
                .ReverseMap();
        }
    }
}