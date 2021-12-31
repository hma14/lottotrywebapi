namespace Lottotry.WebApi.Domain.DailyGrand_GrandNumber.Mappings
{

    using Lottotry.WebApi.Dtos.DailyGrand_GrandNumber;
    using AutoMapper;
    using Lottotry.WebApi.Domain.DailyGrand_GrandNumber;

    public class DailyGrand_GrandNumberProfile : Profile
    {
        public DailyGrand_GrandNumberProfile()
        {
            //createmap<to this, from this>
            CreateMap<DailyGrand_GrandNumber, DailyGrand_GrandNumberDto>()
                .ReverseMap();
            CreateMap<DailyGrand_GrandNumberForCreationDto, DailyGrand_GrandNumber>();
            CreateMap<DailyGrand_GrandNumberForUpdateDto, DailyGrand_GrandNumber>()
                .ReverseMap();
        }
    }
}