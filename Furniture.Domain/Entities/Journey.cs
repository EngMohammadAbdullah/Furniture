using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Journey : EntityBase
    {
        public DateTime Date { get; set; }
        public DateTime DepartAddress { get; set; }
        public DateTime ArrivalDate { get; set; }

    }
}
