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
    public partial class UpdateMakeupPage : System.Web.UI.Page
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
            if (IsPostBack == false)
            {
                if (Request.QueryString["ID"] == null)
                {
                    Response.Redirect("ManageMakeupPage.aspx");
                }
                int id = Convert.ToInt32(Request.QueryString["ID"]);
                Makeup makeup = MakeupController.GetMakeupByID(id);

                makeupNameTxt.Text = makeup.MakeupName;
                priceTxt.Text = makeup.MakeupPrice.ToString();
                weightTxt.Text = makeup.MakeupWeight.ToString();
                string tempTypeID = makeup.MakeupTypeID.ToString();
                typeIDTxt.Text = tempTypeID;
                string tempBrandID = makeup.MakeupBrandID.ToString();
                brandIDTxt.Text = tempBrandID;
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageMakeupPage.aspx");
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            string name = makeupNameTxt.Text;
            int price = Convert.ToInt32(priceTxt.Text == "" ? "0" : priceTxt.Text);
            int weight = Convert.ToInt32(weightTxt.Text == "" ? "0" : weightTxt.Text);
            int typeID = Convert.ToInt32(typeIDTxt.Text == "" ? "0" : typeIDTxt.Text);
            int brandID = Convert.ToInt32(brandIDTxt.Text == "" ? "0" : brandIDTxt.Text);

            Response<Makeup> response = MakeupController.updateMakeup(id, name, price, weight, typeID, brandID);
            if (response.IsSuccess)
            {
                Response.Redirect("ManageMakeupPage.aspx");
            }
            errorLbl.Text = response.Message;
        }
    }
}