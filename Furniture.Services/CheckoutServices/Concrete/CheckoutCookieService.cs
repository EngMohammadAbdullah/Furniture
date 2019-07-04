// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using Furniture.BizLogic.Orders;
using Furniture.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Furniture.Services.CheckoutServices.Concrete
{
    public class CheckoutCookieService
    {
        private List<OrderLineItem> _lineItems;

        /// <summary>
        /// Because we don't get user to log in we assign them a uniquie GUID and store it in the cookie
        /// </summary>
        public Guid EmployeeKey { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid CutomerKey { get; private set; }

        /// <summary>
        /// This returns the line items in the order they were places
        /// </summary>
        public ImmutableList<OrderLineItem> LineItems =>
            _lineItems.ToImmutableList();

        public CheckoutCookieService(string cookieContent)
        {
            DecodeCookieString(cookieContent);
        }

        public CheckoutCookieService(IRequestCookieCollection cookiesIn)
        {
            var cookieHandler = new CheckoutCookie(cookiesIn);
            DecodeCookieString(cookieHandler.GetValue());
        }

        public void AddLineItem(OrderLineItem newItem)
        {
            _lineItems.Add(newItem);
        }

        public void AddCustomer(Guid customerKey)
        {
            this.CutomerKey = customerKey;
        }
        public void UpdateCustomer(Guid customerKey)
        {
            this.CutomerKey = customerKey;
        }
        public void UpdateLineItem(int itemIndex, OrderLineItem replacement)
        {
            if (itemIndex < 0 || itemIndex > _lineItems.Count)
                throw new InvalidOperationException($"System error. Attempt to remove line item index {itemIndex}. _lineItems.Count = {_lineItems.Count}");

            _lineItems[itemIndex] = replacement;
        }

        public void DeleteLineItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex > _lineItems.Count)
                throw new InvalidOperationException($"System error. Attempt to remove line item index {itemIndex}. _lineItems.Count = {_lineItems.Count}");

            _lineItems.RemoveAt(itemIndex);
        }

        public void ClearAllLineItems()
        {
            _lineItems.Clear();
        }

        public string EncodeForCookie()
        {
            var sb = new StringBuilder();
            sb.Append(EmployeeKey.ToString("N"));
            foreach (var lineItem in _lineItems)
            {
                sb.AppendFormat(",{0},{1}", lineItem.SelectedItem, lineItem.NumItems);
            }
            return sb.ToString();
        }

        //---------------------------------------------------
        //private methods

        private void DecodeCookieString(string cookieContent)
        {
            _lineItems = new List<OrderLineItem>();

            if (cookieContent == null)
            {
                //No cookie exists, so create new user and no orders
                EmployeeKey = Guid.NewGuid();
                return;
            }

            //Has cookie, so decode it
            var parts = cookieContent.Split(',');
            EmployeeKey = Guid.Parse(parts[0]);
            for (int i = 0; i < (parts.Length - 1) / 2; i++)
            {
                _lineItems.Add(new OrderLineItem
                {
                    SelectedItem = new Item { Key = Guid.Parse(parts[i * 2 + 1]) },
                    NumItems = short.Parse(parts[i * 2 + 2])
                });
            }
        }
    }
}