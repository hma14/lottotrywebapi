using Lottotry.WebApi.Dtos.LottoNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Dtos
{
    public class LottoNumbersResponseDto
    {
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }

        public LottoNumbersDto[] Numbers { get; set; }
         
    }
}
