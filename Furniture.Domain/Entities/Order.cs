using Furniture.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class Order : EntityBase
    {

        public Guid CustomerKey { get; set; }
        public Guid EmployeeKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public Address Address { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }

        public bool SoftDeleted { get; set; }
        public virtual ICollection<JourneyOrder> JourneyOrder { get; set; }

        
        public virtual ICollection<Item> Items
        { get; set; }
        public virtual ICollection<LineItem> OrderedItems
        { get; set; }
        public virtual ICollection<ItemToBeFactored> ItemToBeFactored
        { get; set; }


        public Order() : base()
        {

            Items = new HashSet<Item>();
            ItemToBeFactored = new HashSet<ItemToBeFactored>();
            JourneyOrder = new HashSet<JourneyOrder>();
            CreatedOn = DateTime.Now;

        }
    }
}
