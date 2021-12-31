using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Dtos
{
    public class Constants
    {
        public enum LottoNames
        {
            BC49 = 1,
            Lotto649 = 2,
            LottoMax = 3,
            DailyGrand = 4,
            DailyGrand_GrandNumber = 5,

            //Cash4Life = 4,
            //Cash4Life_CashBall = 5,


        }
        public enum LottoNumberRange
        {
            BC49 = 49,
            Lotto649 = 49,
            LottoMax = 50,
            DailyGrand = 49,
            DailyGrand_GrandNumber = 7,

            //Cash4Life = 60,
            //Cash4Life_CashBall = 4,
        }
    }
}
