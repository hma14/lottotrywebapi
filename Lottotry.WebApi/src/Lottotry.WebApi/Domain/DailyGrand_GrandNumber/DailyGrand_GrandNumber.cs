namespace Lottotry.WebApi.Domain.DailyGrand_GrandNumber
{

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using Sieve.Attributes;
    using System;

    public class DailyGrand_GrandNumber : BaseEntity
    {
        [Required]
        [Sieve(CanFilter = true, CanSort = false)]
        public int DrawNumber { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DrawDate { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int GrandNumber { get; set; }
    }
}