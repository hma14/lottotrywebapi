namespace Lottotry.WebApi.Dtos.LottoType
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Lottotry.WebApi.Domain.Numbers;

    public class LottoTypeDto
    {
        public Guid Id { get; set; }
        public int LottoName { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int NumberRange { get; set; }
        public ICollection<Number> Numbers { get; set; }
    }
}