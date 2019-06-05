using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Driver:User
    {
        public Guid JourneyKey { get; set; }
        public Journey Journey { get; set; }

        public virtual ICollection<Journey> Journeies { get; set; }

    }
}
