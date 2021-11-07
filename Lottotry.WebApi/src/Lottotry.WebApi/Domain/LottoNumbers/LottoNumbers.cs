namespace Lottotry.WebApi.Domain.LottoNumbers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Sieve.Attributes;

    [Table("LottoNumbers")]
    public class LottoNumbers
    {
        [Key, Column(Order = 0)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int LottoName { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int DrawNumber { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DrawDate { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Number { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int NumberRange { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Distance { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsHit { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int NumberofDrawsWhenHit { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsBonusNumber { get; set; }

        // add-on property marker - Do Not Delete This Comment
    }
}