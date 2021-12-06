namespace Lottotry.WebApi.Domain.LottoTypes
{

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using Sieve.Attributes;
    using System;
    using Lottotry.WebApi.Domain.Numbers;
    using System.Collections.Generic;

    public class LottoType : BaseEntity
    {
        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int LottoName { get; set; }

        [Required]
        [Sieve(CanFilter = true, CanSort = true)]
        public int DrawNumber { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime DrawDate { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int NumberRange { get; set; }

        public ICollection<Number> Numbers { get; set; }
    }
}