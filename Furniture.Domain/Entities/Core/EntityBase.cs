using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Domain.Entities.Core
{
    public class EntityBase : IEntity
    {
        public EntityBase()
        {
            Key = Guid.NewGuid();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Key { get; set; }

    }
}
