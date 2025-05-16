namespace Lottotry.WebApi.Dtos.LottoType
{

    using System.Collections.Generic;
    using Lottotry.WebApi.Domain.Numbers;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LottoTypeForCreationDto : LottoTypeForManipulationDto
    {
        public ICollection<Number> Numbers { get; set; }

    }
}