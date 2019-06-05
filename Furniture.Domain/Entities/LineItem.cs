using Furniture.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities
{
    public class LineItem : EntityBase, IValidatableObject
    {


        public Guid LineItemId { get; set; }


        //LineNum في حال كان في ال Order أكثر  من خمس طلبيات 
        //public byte LineNum { get; set; }

        public short NumItems { get; set; }

        /// <summary>
        /// This holds a copy of the book price. We do this in case the price of the book changes,
        /// e.g. if the price was discounted in the future the order is still correct.
        /// </summary>
        public decimal ItemPrice { get; set; }
        public string Color { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        // relationships

        //  public Guid OrderKey { get; set; }
        public Guid ItemKey { get; set; }

        public Item ChosenItem { get; set; }
        //public Order ChoosenOrder { get; set; }
        IEnumerable<ValidationResult> IValidatableObject.Validate //#C
            (ValidationContext validationContext)                 //#C
        {
            var currContext =
                validationContext.GetService(typeof(DbContext));//#D

            if (ChosenItem.Price < 0)                      //#E
                yield return new ValidationResult(         //#E
$"Sorry, the book '{ChosenItem.Name}' is not for sale."); //#E

            //            if (NumBooks > 100)
            //                yield return new ValidationResult(//#F
            //"If you want to order a 100 or more books" +       //#F
            //" please phone us on 01234-5678-90",              //#F
            //                    new[] { nameof(NumBooks) });  //#F
        }
    }
}
