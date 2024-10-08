using LabProject.Factory;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace LabProject.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetUserTransaction(int id)
        {
            return TransactionHeaderRepository.GetUserTransaction(id);
        }
        public static List<TransactionHeader> GetTransactionList()
        {
            return TransactionHeaderRepository.GetTransactionList();
        }

        public static List<TransactionDetail> GetTransactionDetail(int id)
        {
            return TransactionDetailRepository.GetTransactionDetail(id);
        }

        public static List<TransactionHeader> GetHandledTransaction()
        {
            return TransactionHeaderRepository.GetHandledTransaction();
        }

        public static List<TransactionHeader> GetUnhandledTransaction()
        {
            return TransactionHeaderRepository.GetUnhandledTransaction();
        }

        public static void handleTransaction(int id)
        {
            TransactionHeader transactionHeader = TransactionHeaderRepository.GetTransaction(id);
            TransactionHeaderRepository.handleTransaction(transactionHeader);
        }

        public static int GenerateCartId()
        {
            Cart cart = CartRepository.GetLastCart();
            if (cart == null)
            {
                return 1;
            }
            int lastId = cart.CartID;
            lastId++;
            return lastId;
        }

        public static Response<Cart> insertCart(int userId, int makeupId, int quantity)
        {
            Cart cart = CartFactory.Create(GenerateCartId(), userId, makeupId, quantity);
            CartRepository.CreateCart(cart);
            return new Response<Cart>()
            {
                Message = "Success",
                IsSuccess = true,
                Payload = cart
            };
        }

        public static void clearCart(int userID)
        {
            CartRepository.clearCart(userID);
            return;
        }

        public static int GenerateTransactionId()
        {
            TransactionHeader t = TransactionHeaderRepository.GetLastTransaction();
            if (t == null)
            {
                return 1;
            }
            int lastId = t.TransactionID;
            lastId++;
            return lastId;
        }

        public static void createTransaction(int userId, DateTime date)
        {
            List<Cart> carts = GetCartList(userId);
            int id = GenerateTransactionId();
            TransactionHeaderRepository.createTransaction(userId, date, id);
            foreach (var x in carts)
            {
                TransactionDetailRepository.createTransactionDetail(id, x.MakeupID, x.Quantity);
            }
            return;
        }

        public static List<Cart> GetCartList(int UserID)
        {
            return CartRepository.GetCartList(UserID);
        }

        public static List<TransactionDetail> getTransactionDetailList(int id)
        {
            return TransactionDetailRepository.getTransactionDetailList(id);
        }

        public static Cart GetCartByMakeupID(int makeupID)
        {
            return TransactionHeaderRepository.GetCartByMakeupID(makeupID);
        }
    }
}