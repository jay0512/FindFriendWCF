using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}