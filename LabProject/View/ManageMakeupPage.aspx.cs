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
    public partial class ManageMakeupPage : System.Web.UI.Page
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

            if(user.UserRole != "admin")
            {
                Response.Redirect("HomePage.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Makeup> makeups = MakeupController.GetMakeupList();
            makeupGridView.DataSource = makeups;
            makeupGridView.DataBind();

            List<MakeupType> makeupTypes = MakeupController.GetMakeupTypeList();
            makeupTypeGridView.DataSource = makeupTypes;
            makeupTypeGridView.DataBind();

            List<MakeupBrand> makeupBrands = MakeupController.GetMakeupBrandList();
            makeupBrandGridView.DataSource = makeupBrands;
            makeupBrandGridView.DataBind();
        }

        protected void insertMakeupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertMakeupPage.aspx");
        }

        protected void insertTypebtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertTypePage.aspx");
        }

        protected void insertBrandBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsertBrandPage.aspx");
        }

        protected void makeupGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            MakeupController.removeMakeup(id);

            List<Makeup> makeups = MakeupController.GetMakeupList();
            makeupGridView.DataSource = makeups;
            makeupGridView.DataBind();
        }

        protected void makeupTypeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupTypeGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            MakeupController.removeMakupType(id);

            List<MakeupType> makeupTypes = MakeupController.GetMakeupTypeList();
            makeupTypeGridView.DataSource = makeupTypes;
            makeupTypeGridView.DataBind();
        }

        protected void makeupBrandGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = makeupBrandGridView.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text.ToString());

            MakeupController.removeMakeupBrand(id);

            List<MakeupBrand> makeupBrands = MakeupController.GetMakeupBrandList();
            makeupBrandGridView.DataSource = makeupBrands;
            makeupBrandGridView.DataBind();
        }

        protected void makeupGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = makeupGridView.Rows[e.RowIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeupPage.aspx?ID=" + id);
        }

        protected void makeupTypeGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = makeupTypeGridView.Rows[e.RowIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("updateMakeupTypePage.aspx?ID=" + id);
        }

        protected void makeupBrandGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = makeupBrandGridView.Rows[e.RowIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("UpdateMakeupBrandPage.aspx?ID=" + id);
        }
    }
}