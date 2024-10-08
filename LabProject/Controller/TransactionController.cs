using LabProject.Handler;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetUserTransaction(int id)
        {
            return TransactionHandler.GetUserTransaction(id);
        }
        public static List<TransactionHeader> GetTransactionList()
        {
            return TransactionHandler.GetTransactionList();
        }

        public static List<TransactionDetail> GetTransactionDetail(int id)
        {
            return TransactionHandler.GetTransactionDetail(id);
        }

        public static List<TransactionHeader> GetHandledTransaction()
        {
            return TransactionHandler.GetHandledTransaction();
        }

        public static List<TransactionHeader> GetUnhandledTransaction()
        {
            return TransactionHandler.GetUnhandledTransaction();
        }

        public static void handleTransaction(int id)
        {
            TransactionHandler.handleTransaction(id);
        }

        public static Response<Cart> insertCart(int userId, int makeupId, int quantity)
        {

            if (quantity < 1)
            {
                return new Response<Cart>()
                {
                    Message = "Quantity must be bigger than 1",
                    IsSuccess = false,
                    Payload = null
                };
            }

            Cart cart = TransactionHandler.GetCartByMakeupID(makeupId);
            if(cart != null)
            {
                return new Response<Cart>()
                {
                    Message = "You have already ordered that item",
                    IsSuccess = false,
                    Payload = null,
                };
            }

            String error = "";
            if (error.Equals(""))
            {
                return TransactionHandler.insertCart(userId, makeupId, quantity);
            }
            return new Response<Cart>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static void clearCart(int userID)
        {
            TransactionHandler.clearCart(userID);
            return;
        }

        public static void createTransaction(int userId, DateTime date)
        {
            TransactionHandler.createTransaction(userId, date);
            return;
        }

        public static List<Cart> GetCartList(int UserID)
        {
            return TransactionHandler.GetCartList(UserID);
        }

        public static List<TransactionDetail> getTransactionDetailList(int id)
        {
            return TransactionHandler.getTransactionDetailList(id);
        }

    }
}