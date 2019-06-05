using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Factor : EntityBase
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<ItemToBeFactored> FactoredItems { get; set; }

    }
}
