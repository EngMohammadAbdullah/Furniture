using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class JourneyOrder : EntityBase
    {
        public Guid OrderKey { get; set; }
        public Guid JourneyKey { get; set; }
        public Journey Journey { get; set; }
        public Order Order { get; set; }

    }
}
