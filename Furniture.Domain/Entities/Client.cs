using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Customer :User
    {   

        public virtual ICollection<Order> Orders { get; set; }


        public override string ToString()
        {
            var ff = $"{this.FirstName}  {this.LastName}";
            return this.FirstName + " " + this.LastName;
        }
      
        

        public Customer()
        {
            Orders = new HashSet<Order>();
        }
    }
}
