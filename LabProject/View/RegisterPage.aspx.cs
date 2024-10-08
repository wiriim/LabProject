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
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = string.Empty;
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            string username = UserTxt.Text;
            string email = EmailTxt.Text;
            string gender = GenderRB.SelectedValue;
            string password = PassTxt.Text;
            string confPass = ConfTxt.Text;
            DateTime DOB = Calendar.SelectedDate;

            Response<User> response = UserController.Register(username, email, DOB, gender, password, confPass);
            if (response.IsSuccess)
            {
                User user = response.Payload;

                Session["user"] = user;

                Response.Redirect("HomePage.aspx");
            }
            ErrorLbl.Text = response.Message;
        }
    }
}