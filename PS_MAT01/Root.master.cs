using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using Microsoft.AspNet.Identity;

namespace PS_MAT01 {
    public partial class RootMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            ASPxLabel2.Text = DateTime.Now.Year + Server.HtmlDecode(" &copy; Copyright by PHITSANULOK SUGAR");

            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    pnMenuLogin.Visible = false;
                    lbUser.Text = Session["UserName"].ToString();
                    pnMenuLogin1.Visible = true;
                }
                else
                {
                    pnMenuLogin.Visible = true;
                    pnMenuLogin1.Visible = false;
                }
            }
        }
        protected void HeadLoginStatus_LoggingOut(object sender, LoginCancelEventArgs e) {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        protected void HeaderMenu_ItemClick(object source, MenuItemEventArgs e)
        {
            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();

            Response.Redirect("~/Account/Lockout.aspx");
        }
    }
}