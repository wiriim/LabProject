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
    public partial class UpdateMakeupBrandPage : System.Web.UI.Page
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
            errorLbl.Text = string.Empty;
            if(IsPostBack == false)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("ManageMakeupPage.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                MakeupBrand makeupBrand = MakeupController.getMakeupBrandByID(id);

                brandNameTxt.Text = makeupBrand.MakeupBrandName;
                brandRatingTxt.Text = makeupBrand.MakeupBrandRating.ToString();

            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            string name = brandNameTxt.Text;
            int rating = Convert.ToInt32(brandRatingTxt.Text == "" ? "-1" : brandRatingTxt.Text);

            Response<MakeupBrand> response = MakeupController.updateMakeupBrand(id, name, rating);
            if (response.IsSuccess)
            {
                Response.Redirect("ManageMakeupPage.aspx");
            }
            errorLbl.Text = response.Message;
        }
    }
}