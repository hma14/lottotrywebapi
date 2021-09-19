namespace Lottotry.WebApi.Dtos.Lotto649
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Lotto649ForManipulationDto 
    {
        public DateTime DrawDate { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int Number6 { get; set; }
        public int Bonus { get; set; }

        // add-on property marker - Do Not Delete This Comment
    }
}