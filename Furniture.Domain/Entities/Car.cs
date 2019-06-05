using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Car : EntityBase
    {
        public string Name { get; set; }
        public string model { get; set; }
        public string Number { get; set; }
        public Guid JourneyKey { get; set; }

        public virtual ICollection<Journey> Journeies  { get; set; }

    }
}
