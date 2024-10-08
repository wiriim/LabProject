using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class CartFactory
    {
        public static Cart Create(int cartId, int userId, int makeupId, int quantity)
        {
            Cart cart = new Cart()
            {
                CartID = cartId,
                UserID = userId,
                MakeupID = makeupId,
                Quantity = quantity
            };

            return cart;
        }
    }
}