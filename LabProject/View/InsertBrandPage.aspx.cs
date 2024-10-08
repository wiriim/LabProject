using LabProject.Controller;
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
    public partial class InsertBrandPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = null;
            errorLbl.Text = string.Empty;
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

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string brandName = brandNameTxt.Text;
            int rating = Convert.ToInt32(brandRatingTxt.Text == "" ? "-1" : brandRatingTxt.Text);

            Response<MakeupBrand> response = MakeupController.addMakeupBrand(brandName, rating);
            if (response.IsSuccess)
            {
                errorLbl.Text = response.Message;
                return;
            }
            errorLbl.Text = response.Message;
        }
    }
}