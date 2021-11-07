namespace Lottotry.WebApi.Domain.LottoMax
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Sieve.Attributes;

    [Table("LottoMax")]
    public class LottoMax
    {
        [Key]
        [Required]
        [Sieve(CanFilter = true, CanSort = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number6 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Number7 { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int Bonus { get; set; }

        // add-on property marker - Do Not Delete This Comment
    }
}