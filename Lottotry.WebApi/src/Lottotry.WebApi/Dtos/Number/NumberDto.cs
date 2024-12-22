namespace Lottotry.WebApi.Dtos.Number
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NumberDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public int Distance { get; set; }
        public bool IsHit { get; set; }
        public int NumberofDrawsWhenHit { get; set; }
        public bool IsBonusNumber { get; set; }
        public int TotalHits { get; set; }

        // new
        public bool? IsNextPotentialHit { get; set; }

        public int Probability { get; set; }

    }
}