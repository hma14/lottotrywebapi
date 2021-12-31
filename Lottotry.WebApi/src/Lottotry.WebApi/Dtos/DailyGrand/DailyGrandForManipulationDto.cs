namespace Lottotry.WebApi.Dtos.DailyGrand
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class DailyGrandForManipulationDto
    {
        public int DrawNumber { get; set; }
        public DateTime DrawDate { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
    }
}