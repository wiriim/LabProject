using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace LabProject.Repository
{
    public class CartRepository
    {
        public static Database1Entities2 db = new Database1Entities2();
        public static List<Cart> GetCartList(int UserID)
        {
            return (from Cart in db.Carts where Cart.UserID == UserID select Cart).ToList();
        }

        public static void clearCart(int userID)
        {
            List<Cart> carts = (from Cart in db.Carts where Cart.UserID == userID select Cart).ToList();
            db.Carts.RemoveRange(carts);
            db.SaveChanges();
            return;
        }

        public static void CreateCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
            return;
        }

        public static Cart GetLastCart()
        {
            Cart cart = db.Carts.ToList().LastOrDefault();
            return cart;
        }
    }
}