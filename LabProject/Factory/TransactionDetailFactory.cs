using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionID, int makeupID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail()
            {
                TransactionID = transactionID,
                MakeupID = makeupID,
                Quantity = quantity
            };

            return transactionDetail;
        }
    }
}