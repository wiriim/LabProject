using LabProject.Controller;
using LabProject.Handler;
using LabProject.Model;
using LabProject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabProject.View
{
    public partial class OrderMakeupPage : System.Web.UI.Page
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
                Response.Redirect("HomePage.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Makeup> makeups = MakeupController.GetMakeupList();
                makeupsGridView.DataSource = makeups;
                makeupsGridView.DataBind();

                List<Cart> carts = TransactionController.GetCartList(user.UserID);
                cartGridView.DataSource = carts;
                cartGridView.DataBind();
                if (cartGridView.Rows.Count == 0)
                    cartErrorLbl.Text = "Your Cart is Empty.";
                else
                    cartErrorLbl.Text = "";
            }

        }

        protected void order(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = makeupsGridView.Rows[e.RowIndex];
            TextBox tb = (TextBox)row.FindControl("QuantityTxt");

            string makeupID = row.Cells[0].Text;
            int userId = user.UserID;
            int makeupId = Convert.ToInt32(makeupID);
            int quantity;
            if (tb.Text == "")
            {
                quantity = 0;
            }
            else
            {
                quantity = Convert.ToInt32(tb.Text);
            }

            Response<Cart> response = TransactionController.insertCart(userId, makeupId, quantity);
            if (response.IsSuccess)
            {
                List<Cart> carts = TransactionController.GetCartList(user.UserID);
                cartGridView.DataSource = carts;
                cartGridView.DataBind();
                if (cartGridView.Rows.Count == 0)
                    cartErrorLbl.Text = "Your Cart is Empty.";
                else
                    cartErrorLbl.Text = string.Empty;
                ErrorLbl.Text = response.Message;
            }
            ErrorLbl.Text = response.Message;

            tb.Text = string.Empty;
        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            TransactionController.clearCart(user.UserID);
            List<Cart> carts = TransactionController.GetCartList(user.UserID);
            cartGridView.DataSource = carts;
            cartGridView.DataBind();
            if (cartGridView.Rows.Count == 0)
                cartErrorLbl.Text = "Your Cart is Empty.";
            else
                cartErrorLbl.Text = "";
            ErrorLbl.Text = "Cart has been cleared";
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            int userId = user.UserID;
            DateTime date = DateTime.Now;
            List<Cart> carts = TransactionController.GetCartList(user.UserID);
            if (carts == null)
            {
                cartErrorLbl.Text = "Your Cart is Empty.";
            }
            else
            {
                TransactionController.createTransaction(userId, date);
                ErrorLbl.Text = "All cart has been inserted into transaction";
                TransactionController.clearCart(user.UserID);
                carts = TransactionController.GetCartList(userId);
                cartGridView.DataSource = carts;
                cartGridView.DataBind();
                if(cartGridView.Rows.Count == 0)
                {
                    cartErrorLbl.Text = "Your Cart is Empty.";
                }
            }
        }
    }
}