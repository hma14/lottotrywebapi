namespace Lottotry.WebApi.Dtos.LottoNumbers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class LottoNumbersForManipulationDto 
    {
        public DateTime DrawDate { get; set; }
        public int Number { get; set; }
        public int NumberRange { get; set; }
        public int Distance { get; set; }
        public bool IsHit { get; set; }
        public int NumberofDrawsWhenHit { get; set; }
        public bool IsBonusNumber { get; set; }

        // add-on property marker - Do Not Delete This Comment
    }
}