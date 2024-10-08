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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = string.Empty;
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = UserTxt.Text;
            string password = PassTxt.Text;

            Response<User> response = UserController.Login(username, password);
            if (response.IsSuccess)
            {
                if (RememberCB.Checked)
                {
                    HttpCookie cookie = UserController.addCookie(response.Payload.UserID);
                    Response.Cookies.Add(cookie);
                }

                User user = response.Payload;

                Session["user"] = user;

                Response.Redirect("HomePage.aspx");
            }
            ErrorLbl.Text = response.Message;
        }
    }
}