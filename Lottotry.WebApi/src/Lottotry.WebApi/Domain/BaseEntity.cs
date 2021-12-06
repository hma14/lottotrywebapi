using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottotry.WebApi.Domain
{
    public class BaseEntity
    {
        public  virtual Guid Id { get; set; }
    }
}
