namespace Lottotry.WebApi.Dtos.Number
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class NumberForManipulationDto
    {
        
        public int Value { get; set; }
        public Guid? LottoTypeId { get; set; }
        public int Distance { get; set; }
        public bool IsHit { get; set; }
        public int NumberofDrawsWhenHit { get; set; }
        public bool IsBonusNumber { get; set; }
    }
}