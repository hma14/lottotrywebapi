namespace Lottotry.WebApi.Dtos.Number
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class NumberForCreationDto : NumberForManipulationDto
    {
        public Guid Id { get; set; }
    }
}