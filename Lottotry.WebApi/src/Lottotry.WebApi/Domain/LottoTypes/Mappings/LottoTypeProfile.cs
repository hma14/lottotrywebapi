namespace Lottotry.WebApi.Domain.LottoTypes.Mappings
{

    using Lottotry.WebApi.Dtos.LottoType;
    using AutoMapper;
    using Lottotry.WebApi.Domain.LottoTypes;

    public class LottoTypeProfile : Profile
    {
        public LottoTypeProfile()
        {
            //createmap<to this, from this>
            CreateMap<LottoType, LottoTypeDto>()
                .ReverseMap();
            CreateMap<LottoTypeForCreationDto, LottoType>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Prevent Id overwrite
            CreateMap<LottoTypeForUpdateDto, LottoType>()
                .ReverseMap();
        }
    }
}