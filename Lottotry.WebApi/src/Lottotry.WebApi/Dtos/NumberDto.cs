using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Dtos
{
    public class NumberDto
    {
        public int Number { get; set; }
        public int NumberRange { get; set; }
        public int Distance { get; set; }
        public bool IsHit { get; set; }
        public int NumberofDrawsWhenHit { get; set; }
        public bool IsBonusNumber { get; set; }

    }
}
