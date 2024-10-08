using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int transactionID, int userID, DateTime transactionDate, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader()
            {
                TransactionID = transactionID,
                UserID = userID,
                TransactionDate = transactionDate,
                Status = status
            };

            return transactionHeader;
        }
    }
}