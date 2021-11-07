namespace Lottotry.WebApi.Domain.LottoNumbers.Mappings
{
    using Lottotry.WebApi.Dtos.LottoNumbers;
    using AutoMapper;
    using Lottotry.WebApi.Domain.LottoNumbers;

    public class LottoNumbersProfile : Profile
    {
        public LottoNumbersProfile()
        {
            //createmap<to this, from this>
            CreateMap<LottoNumbers, LottoNumbersDto>()
                .ReverseMap();
            CreateMap<LottoNumbersForCreationDto, LottoNumbers>();
            CreateMap<LottoNumbersForUpdateDto, LottoNumbers>()
                .ReverseMap();
        }
    }
}