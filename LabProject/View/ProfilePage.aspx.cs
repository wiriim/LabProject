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
    public partial class ProfilePage : System.Web.UI.Page
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
            if (IsPostBack == false)
            {
                CalendarDate.Visible = false;
                ErrorLbl1.Text = string.Empty;
                ErrorLbl2.Text = string.Empty;
                UsernameTxt.Text = user.Username;
                EmailTxt.Text = user.UserEmail;
                DOBTxT.Text = user.UserDOB.ToShortDateString();
                GenderRB.SelectedValue = user.UserGender;
            }
        }

        protected void UpdatePassBtn_Click(object sender, EventArgs e)
        {
            string oldpass = OldPassTxt.Text;
            string newpass = NewPassTxt.Text;

            Response<User> response = UserController.UpdatePassword(user, oldpass, newpass);
            if (response.IsSuccess)
            {
                User user = response.Payload;

                Session["user"] = user;

                Response.Redirect("HomePage.aspx");
            }
            ErrorLbl2.Text = response.Message;
        }

        protected void UpdateProfBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderRB.SelectedValue;
            DateTime DOB = CalendarDate.SelectedDate;
            

            Response<User> response = UserController.UpdateProfile(user, username, email, DOB, gender);
            if (response.IsSuccess)
            {
                User user = response.Payload;

                Session["user"] = user;

                Response.Redirect("HomePage.aspx");
            }
            ErrorLbl1.Text = response.Message;
        }

        protected void CalendarDate_SelectionChanged(object sender, EventArgs e)
        {
            DOBTxT.Text = CalendarDate.SelectedDate.ToShortDateString();
            CalendarDate.Visible = false;
        }

        protected void ImageButtonCalender_Click(object sender, ImageClickEventArgs e)
        {
            if (CalendarDate.Visible)
            {
                CalendarDate.Visible = false;
            }
            else
            {
                CalendarDate.Visible = true;
            }
        }
    }
}