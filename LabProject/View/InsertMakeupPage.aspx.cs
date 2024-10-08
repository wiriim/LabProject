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
    public partial class InsertMakeupPage : System.Web.UI.Page
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

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string makeupName = makeupNameTxt.Text;
            int price = Convert.ToInt32(priceTxt.Text == ""? "0" : priceTxt.Text);
            int weight = Convert.ToInt32(weightTxt.Text == ""? "0" : weightTxt.Text);
            int typeID = Convert.ToInt32(typeIDTxt.Text == "" ? "0" : typeIDTxt.Text);
            int brandID = Convert.ToInt32(brandIDTxt.Text == "" ? "0" : brandIDTxt.Text);

            Response<Makeup> response = MakeupController.addMakeup(makeupName, price, weight, typeID, brandID);
            if (response.IsSuccess)
            {
                errorLbl.Text = response.Message;
                return;
            }
            errorLbl.Text = response.Message;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }
    }
}