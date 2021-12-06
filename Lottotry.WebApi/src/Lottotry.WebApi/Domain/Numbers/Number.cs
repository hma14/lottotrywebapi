namespace Lottotry.WebApi.Domain.Numbers
{

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using Sieve.Attributes;
    using Lottotry.WebApi.Domain.LottoTypes;
    using System;

    public class Number : BaseEntity
    {
        [Sieve(CanFilter = true, CanSort = true)]
        public int Value { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        [ForeignKey("LottoType")]
        public Guid? LottoTypeId { get; set; }
        public LottoType LottoType { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Distance { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsHit { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int NumberofDrawsWhenHit { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public bool IsBonusNumber { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int TotalHits { get; set; }
    }
}