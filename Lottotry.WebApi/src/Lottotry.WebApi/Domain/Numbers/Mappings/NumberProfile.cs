namespace Lottotry.WebApi.Domain.Numbers.Mappings
{

    using Lottotry.WebApi.Dtos.Number;
    using AutoMapper;
    using Lottotry.WebApi.Domain.Numbers;

    public class NumberProfile : Profile
    {
        public NumberProfile()
        {
            //createmap<to this, from this>
            CreateMap<Number, NumberDto>()
                .ReverseMap();
            CreateMap<NumberForCreationDto, Number>();
            CreateMap<NumberForUpdateDto, Number>()
                .ReverseMap();
        }
    }
}