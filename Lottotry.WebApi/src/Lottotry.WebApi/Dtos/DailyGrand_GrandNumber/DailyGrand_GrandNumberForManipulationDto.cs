namespace Lottotry.WebApi.Dtos.DailyGrand_GrandNumber
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class DailyGrand_GrandNumberForManipulationDto
    {
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int GrandNumber { get; set; }
    }
}