using LabProject.Controller;
using LabProject.Handler;
using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabProject.View
{
    public partial class TransactionHistoryPage : System.Web.UI.Page
    {
        User user;
        void Page_PreInit(Object sender, EventArgs e)
        {
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
            if (user.UserRole == "admin")
            {
                this.MasterPageFile = "~/Master/AdminMaster.Master";
            }
            else
            {
                this.MasterPageFile = "~/Master/CustomerMaster.Master";
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (user.UserRole == "customer")
            {
                int id = user.UserID;
                List<TransactionHeader> transaction = TransactionController.GetUserTransaction(id);
                TransactionGridView.DataSource = transaction;
                TransactionGridView.DataBind();
            }
            else
            {
                List<TransactionHeader> transaction = TransactionController.GetTransactionList();
                TransactionGridView.DataSource = transaction;
                TransactionGridView.DataBind();
            }
        }

        protected void TransactionGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = TransactionGridView.SelectedRow;
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("TransactionDetailPage.aspx?ID=" + id);
        }
    }
}