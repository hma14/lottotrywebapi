namespace Lottotry.WebApi.Domain.DailyGrand.Mappings
{

    using Lottotry.WebApi.Dtos.DailyGrand;
    using AutoMapper;
    using Lottotry.WebApi.Domain.DailyGrand;

    public class DailyGrandProfile : Profile
    {
        public DailyGrandProfile()
        {
            //createmap<to this, from this>
            CreateMap<DailyGrand, DailyGrandDto>()
                .ReverseMap();
            CreateMap<DailyGrandForCreationDto, DailyGrand>();
            CreateMap<DailyGrandForUpdateDto, DailyGrand>()
                .ReverseMap();
        }
    }
}