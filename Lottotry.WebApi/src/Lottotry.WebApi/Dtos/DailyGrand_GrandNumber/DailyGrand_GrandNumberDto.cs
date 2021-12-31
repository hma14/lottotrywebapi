namespace Lottotry.WebApi.Dtos.DailyGrand_GrandNumber
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DailyGrand_GrandNumberDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int GrandNumber { get; set; }
    }
}