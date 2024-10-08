using LabProject.Factory;
using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace LabProject.Repository
{
    public class TransactionHeaderRepository
    {
        public static Database1Entities2 db = new Database1Entities2();

        public static List<TransactionHeader> GetUserTransaction(int id)
        {
            return (from Transaction in db.TransactionHeaders where Transaction.UserID == id select Transaction).ToList();
        }

        public static List<TransactionHeader> GetTransactionList()
        {
            return (from Transaction in db.TransactionHeaders select Transaction).ToList();
        }

        public static List<TransactionHeader> GetHandledTransaction()
        {
            return (from Transaction in db.TransactionHeaders where Transaction.Status.Equals("handled") select Transaction).ToList();
        }

        public static List <TransactionHeader> GetUnhandledTransaction()
        {
            return (from Transaction in db.TransactionHeaders where Transaction.Status.Equals("unhandled") select Transaction).ToList();
        }

        public static TransactionHeader GetTransaction(int id)
        {
            TransactionHeader transactionHeader = db.TransactionHeaders.Find(id);
            return transactionHeader;
        }

        public static void handleTransaction(TransactionHeader transactionHeader)
        {
            transactionHeader.Status = "handled";
            db.SaveChanges();
            return;
        }

        public static TransactionHeader GetLastTransaction()
        {
            TransactionHeader t = db.TransactionHeaders.ToList().LastOrDefault();
            return t;
        }

        public static void createTransaction(int userId, DateTime date, int transactionId)
        {
            TransactionHeader th = TransactionHeaderFactory.Create(transactionId, userId, date, "unhandled");
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
            return;
        }

        public static Cart GetCartByMakeupID(int makeupID)
        {
            return (from cart in db.Carts where cart.MakeupID == makeupID select cart).FirstOrDefault();
        }
    }
}