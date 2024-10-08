using LabProject.Controller;
using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabProject.View
{
    public partial class HandleTransactionPage : System.Web.UI.Page
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

            if (user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TransactionHeader> handled = TransactionController.GetHandledTransaction();
            handledGridView.DataSource = handled;
            handledGridView.DataBind();

            List<TransactionHeader> unhandled = TransactionController.GetUnhandledTransaction();
            unhandledGridView.DataSource = unhandled;
            unhandledGridView.DataBind();
        }

        protected void unhandledGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = unhandledGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            TransactionController.handleTransaction(id);

            List<TransactionHeader> handled = TransactionController.GetHandledTransaction();
            handledGridView.DataSource = handled;
            handledGridView.DataBind();

            List<TransactionHeader> unhandled = TransactionController.GetUnhandledTransaction();
            unhandledGridView.DataSource = unhandled;
            unhandledGridView.DataBind();
        }
    }
}