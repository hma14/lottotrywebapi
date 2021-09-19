namespace Lottotry.WebApi.Domain.LottoMax.Mappings
{
    using Lottotry.WebApi.Dtos.LottoMax;
    using AutoMapper;
    using Lottotry.WebApi.Domain.LottoMax;

    public class LottoMaxProfile : Profile
    {
        public LottoMaxProfile()
        {
            //createmap<to this, from this>
            CreateMap<LottoMax, LottoMaxDto>()
                .ReverseMap();
            CreateMap<LottoMaxForCreationDto, LottoMax>();
            CreateMap<LottoMaxForUpdateDto, LottoMax>()
                .ReverseMap();
        }
    }
}