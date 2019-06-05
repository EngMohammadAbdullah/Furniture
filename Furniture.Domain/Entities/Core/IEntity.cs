using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Furniture.Domain.Entities.Core
{

    public interface IEntity
    {


        [Key]
        Guid Key { get; set; }
    }
}