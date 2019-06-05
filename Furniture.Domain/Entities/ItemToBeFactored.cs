using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class ItemToBeFactored : EntityBase
    {
        public Guid ItemKey { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public Guid FactorKey { get; set; }
        public Guid OrderKey { get; set; }
        public string Notes { get; set; }

        public Factor Factor { get; set; }
        public Order Order { get; set; }


    }
}
