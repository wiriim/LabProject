using LabProject.Factory;
using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Repository
{
    public class TransactionDetailRepository
    {
        public static Database1Entities2 db = new Database1Entities2();
        public static List<TransactionDetail> GetTransactionDetail(int id)
        {
            List<TransactionDetail> transaction = (from x in db.TransactionDetails where x.TransactionID == id select x).ToList();
            return transaction;
        }

        public static List<TransactionDetail> getTransactionDetailList(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.TransactionID == id select transaction).ToList();
        }

        public static void createTransactionDetail(int transactionId, int makeupID, int quantity)
        {
            TransactionDetail td = TransactionDetailFactory.Create(transactionId, makeupID, quantity);
            db.TransactionDetails.Add(td);
            db.SaveChanges();
            return;
        }
    }
}