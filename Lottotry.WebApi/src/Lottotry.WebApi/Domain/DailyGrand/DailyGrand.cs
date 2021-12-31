namespace Lottotry.WebApi.Domain.DailyGrand
{

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using Sieve.Attributes;
    using System;

    [Table("DailyGrand")]
    public class DailyGrand : BaseEntity
    {
        [Required]
        [Sieve(CanFilter = true, CanSort = false)]
        public int DrawNumber { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DrawDate { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number1 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number2 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number3 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number4 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number5 { get; set; }
    }
}