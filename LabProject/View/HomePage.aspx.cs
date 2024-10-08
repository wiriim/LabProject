using LabProject.Controller;
using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace LabProject.View
{
    public partial class HomePage1 : System.Web.UI.Page
    {
        User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            NameLbl.Text = user.Username + " - ";
            RoleLbl.Text = user.UserRole;
            List<User> users = UserController.GetAllCustomer();
            userGridView.DataSource = users;
            userGridView.DataBind();

            if(user.UserRole == "customer")
            {
                onlyAdmin.Visible = false;
            }

        }

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
    }
}