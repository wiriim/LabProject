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
    public partial class TransacationDetailPage : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("TransactionHistoryPage.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                List<TransactionDetail> transactionDetail = TransactionController.GetTransactionDetail(id);
                TransactionDetailGridView.DataSource = transactionDetail;
                TransactionDetailGridView.DataBind();
            }
        }
    }
}