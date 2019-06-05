// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using Furniture.Domain.Entities;
using System;

namespace Furniture.BizLogic.Orders
{
    public class OrderLineItem
    {
        public Item SelectedItem { get; set; }

        public short NumItems { get; set; }
    }


}