namespace Lottotry.WebApi.Dtos.BC49
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BC49ForCreationDto : BC49ForManipulationDto
    {

        public int DrawNumber { get; set; }
        // add-on property marker - Do Not Delete This Comment
    }
}