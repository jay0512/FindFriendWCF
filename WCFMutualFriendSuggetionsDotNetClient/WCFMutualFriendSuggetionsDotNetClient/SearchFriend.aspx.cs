using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFMutualFriendSuggetionsDotNetClient.ServiceReference1;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class SearchFriend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.StatusCode = 401;
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            String userEmail = Session["username"].ToString();
            String pattern = TextBox1.Text;

            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            User usr = proxy.getUserByEmail(userEmail);
            UserWithCount[] usrcnt = proxy.GetNonFriendsFromQueryString(usr.UserID, pattern);
            UserWithCount[] frndcnt = proxy.GetFriendsFromQueryString(usr.UserID, pattern);

            Session["nonFriendList"] = usrcnt;
            Session["FriendList"] = frndcnt;

            Response.Redirect("SearchFriend.aspx");
        }

    }
}