﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFMutualFriendSuggetionsDotNetClient.ServiceReference1;

namespace WCFMutualFriendSuggetionsDotNetClient
{
    public partial class RemoveFriend : System.Web.UI.Page
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
                String userEmail = Session["username"].ToString();
                int FriendID = int.Parse(Request.QueryString["id"].ToString());

                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
                User usr = proxy.getUserByEmail(userEmail);

                int status = proxy.removeFriend(usr.UserID, FriendID);
                if (status != 0)
                {
                    UserWithCount[] usrcnt = proxy.GetNonFriendsFromQueryString(usr.UserID, "");
                    UserWithCount[] frndcnt = proxy.GetFriendsFromQueryString(usr.UserID, "");

                    Session["nonFriendList"] = usrcnt;
                    Session["FriendList"] = frndcnt;
                }

                Response.Redirect("SearchFriend.aspx");
            }
        }
    }
}