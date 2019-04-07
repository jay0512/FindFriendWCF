using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFMutualFriendSuggetionsDotNetClient.ServiceReference1;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.StatusCode = 401;
                Response.Redirect("Login.aspx");
            }
            else
            {
                int FriendID = int.Parse(Request.QueryString["id"].ToString());
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                User friend = proxy.getUserByUserID(FriendID);
                Session["FriendProfile"] = friend;

            }

        }
    }
}