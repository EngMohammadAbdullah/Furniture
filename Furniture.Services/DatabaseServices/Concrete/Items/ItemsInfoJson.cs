using Furniture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Services.DatabaseServices.Concrete
{
    public class ItemsInfoJson
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

    }
}
