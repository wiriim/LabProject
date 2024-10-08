using LabProject.Controller;
using LabProject.Dataset;
using LabProject.Model;
using LabProject.Report;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabProject.View
{
    public partial class TransactionReport : System.Web.UI.Page
    {
        void Page_PreInit(Object sender, EventArgs e)
        {
            User user = null;
            if (Session["user"] == null && Request.Cookies["user-cred"] == null)
            {
                Response.Redirect("LoginPage.aspx");
            }
            else
            {

                if (Session["user"] == null)
                {
                    var userId = Request.Cookies["user-cred"];
                    user = UserController.GetUserByID(Convert.ToInt32(userId.Value));
                    Session["user"] = user;
                }
                else
                {
                    user = (User)Session["user"];
                }

            }

            if (user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = getData(TransactionController.GetTransactionList());
            report.SetDataSource(data);
        }

        private DataSet1 getData(List<TransactionHeader> transactionHeaders)
        {
            DataSet1 dataSet = new DataSet1();
            var headerTable = dataSet.TransactionHeader;
            var detailTable = dataSet.TransactionDetail;

            foreach(TransactionHeader t in transactionHeaders)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                headerTable.Rows.Add(hrow);

                List<TransactionDetail> transactionDetails = TransactionController.getTransactionDetailList(t.TransactionID);

                foreach (TransactionDetail d in transactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["MakeupID"] = d.MakeupID;
                    drow["Quantity"] = d.Quantity;
                    detailTable.Rows.Add(drow);

                }
                
            }

            return dataSet;
        }
    }
}