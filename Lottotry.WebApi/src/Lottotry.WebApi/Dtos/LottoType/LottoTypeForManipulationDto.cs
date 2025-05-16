namespace Lottotry.WebApi.Dtos.LottoType
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Lottotry.WebApi.Domain.Numbers;


    public abstract class LottoTypeForManipulationDto
    {
        public int LottoName { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int NumberRange { get; set; }
    }
}